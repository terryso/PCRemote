#region using

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

#endregion

namespace PCRemote.Core.Commands
{
    public class PhotoCommand : CommandBase, ICommand
    {
        #region ICommand Members

        public void Execute(CommandContext context)
        {
            Bitmap bitmap = null;
            EncoderParameters encoderParams = null;
            EncoderParameter parameter = null;
            try
            {
                var temp = Environment.GetEnvironmentVariable("TEMP");
                var picPath = temp + "\\" + Guid.NewGuid() + ".bmp";

                var webcam = new WebCamUtility(context.Handle, 600, 480);
                webcam.StartWebCam();
                webcam.GrabImage(context.Handle, picPath);
                webcam.CloseWebcam();

                bitmap = new Bitmap(picPath);
                var codecInfo = GetCodecInfo("image/jpeg");
                var quality = Encoder.Quality;
                encoderParams = new EncoderParameters(1);
                const long num = 0x5fL;
                parameter = new EncoderParameter(quality, num);
                encoderParams.Param[0] = parameter;

                var newPicPath = picPath.Replace("bmp", "jpg");
                bitmap.Save(newPicPath, codecInfo, encoderParams);

                if (context.SendPhotoByEmail)
                {
                    SendComment(context, "#PC遥控器#正在发送你的WebCam抓拍到你的指定Email中，请过一会去查收。");
                    SendPhotoByEmail(context, newPicPath);
                }
                else
                {
                    SendComment(context, "#PC遥控器#正在上传你的WebCam抓拍，一会将会出现在你的最新微博中。");
                    context.WeiboService.SendWeiboWithPicture("我正在使用#PC遥控器#分享我的WebCam抓拍 " + DateTime.Now.ToLongTimeString(), newPicPath);
                }

            }
            finally
            {
                if (parameter != null) parameter.Dispose();
                if (encoderParams != null) encoderParams.Dispose();
                if (bitmap != null) bitmap.Dispose();
            }
        }

        #endregion

        static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            var imageEncoders = ImageCodecInfo.GetImageEncoders();
            return imageEncoders.FirstOrDefault(info => info.MimeType == mimeType);
        }

        static void SendPhotoByEmail(CommandContext context, string picPath)
        {
            var title = "我的WebCam抓拍@" + DateTime.Now;
            var body = "此图由<a href='http://weibo.com/k/PC%25E9%2581%25A5%25E6%258E%25A7%25E5%2599%25A8?refer=Index_mark'>#PC遥控器#</a>自动发送，请不要回复。<br/>" +
                        "请问题请<a href='http://weibo.com/suchuanyi'>@四眼蒙面侠</a>";
            var to = context.MailUtility.Account.AccountName;

            context.MailUtility.Send(to, title, body, picPath);
        }
    }
}