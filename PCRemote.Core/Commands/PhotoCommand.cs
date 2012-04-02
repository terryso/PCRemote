#region using

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

#endregion

namespace PCRemote.Core.Commands
{
    public class PhotoCommand : CommandBase, ICommand
    {
        public PhotoCommand()
        {
            
        }

        public PhotoCommand(IWeiboService client, Control control)
        {
        }

        #region ICommand Members

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PCң����#�����ϴ����WebCamץ�ģ�һ�Ὣ��������������΢���С�");

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

                context.WeiboService.SendWeiboWithPicture("������ʹ��#PCң����#�����ҵ�WebCamץ�� " + DateTime.Now.ToLongTimeString(), newPicPath);
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
    }
}