using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

namespace PCRemote.Core.Commands
{
    public class MediaPlayCommand : CommandBase, ICommand
    {
        #region ICommand Members

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#正在为您播放当前的多媒体文件。");
            InputUtility.Send(InputUtility.Keyboard.MediaPlayPause);
        }

        #endregion
    }
}