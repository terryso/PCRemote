using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using PCRemote.Core.Utilities;
using Weibo.Contracts;

namespace PCRemote.Core
{
    public class PhotoCommand : ICommand
    {
        private readonly IWeiboClient _client;
        private readonly Control _control;

        public PhotoCommand(IWeiboClient client, Control control)
        {
            _client = client;
            _control = control;
        }

        public void Execute()
        {
            Bitmap bitmap = null;
            EncoderParameters encoderParams = null;
            EncoderParameter parameter = null;
            try
            {
                var temp = Environment.GetEnvironmentVariable("TEMP");
                var picPath = temp + "\\" + Guid.NewGuid() + ".bmp";


                var webcam = new WebCamUtility(_control.Handle, 600, 480);
                webcam.StartWebCam();
                webcam.GrabImage(_control.Handle, picPath);
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

                _client.UploadStatus("我正在使用#PC遥控器#分享我的WebCam抓拍 " + DateTime.Now.ToLongTimeString(), newPicPath);
            }
            finally
            {
                if (parameter != null) parameter.Dispose();
                if (encoderParams != null) encoderParams.Dispose();
                if (bitmap != null) bitmap.Dispose();
            }
        }

        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            var imageEncoders = ImageCodecInfo.GetImageEncoders();
            return imageEncoders.FirstOrDefault(info => info.MimeType == mimeType);
        }
    }
}