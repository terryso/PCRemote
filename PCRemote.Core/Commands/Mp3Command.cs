#region using

using System;
using System.IO;
using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

#endregion

namespace PCRemote.Core.Commands
{
    public class Mp3Command : CommandBase, ICommand
    {
        #region Implementation of ICommand

        public void Execute(CommandContext context)
        {
            var parameters = context.CommandParameter.Split('|');

            if (parameters.Length == 0)
                throw new ArgumentNullException();

            var song = string.Empty;
            var singer = string.Empty;

            switch (parameters.Length)
            {
                case 1:
                    song = parameters[0].Trim();
                    break;
                case 2:
                    song = parameters[0].Trim();
                    singer = parameters[1].Trim();
                    break;
            }

            var graber = new BaiduMp3Graber();
            var result = graber.Grab(song, singer);

            if (result.Count == 0)
            {
                SendComment(context, "很抱歉，没有找到您需要的歌曲。");
                return;
            }

            string downUrl;
            if (result.DLinks.Count != 0 && !string.IsNullOrEmpty(result.DLinks[0].Encode))
                downUrl = result.DLinks[0].TrueDownloadUrl;
            else
                downUrl = result.Links[0].TrueDownloadUrl;

            SendComment(context, string.Format("#PC遥控器# 开始帮您下载歌曲：{0}, 下载地址为：{1}", song, downUrl));
            DonwloadMp3(context.DownloadPath, downUrl, song, singer);
            SendComment(context, "歌曲下载完成...");
        }

        private static void DonwloadMp3(string downloadPath, string downUrl, string song, string singer)
        {
            var downDirectory = string.IsNullOrEmpty(singer) ? string.Format("{0}\\Music", downloadPath) 
                                                             : string.Format("{0}\\Music\\{1}", downloadPath, singer);

            if (!Directory.Exists(downDirectory))
                Directory.CreateDirectory(downDirectory);

            var filePath = string.Format("{0}\\{1}.mp3", downDirectory, song);
            var downPara = new DownloadParameter
                               {
                                   FilePath = filePath,
                                   Url = downUrl
                               };


            NetworkUtility.DownloadFile(downPara);
        }

        #endregion
    }
}