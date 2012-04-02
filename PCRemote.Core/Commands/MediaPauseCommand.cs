using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

namespace PCRemote.Core.Commands
{
    public class MediaPauseCommand : CommandBase, ICommand
    {
        #region ICommand Members

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PC遥控器#已经帮您暂停播放当前的多媒体文件。");
            InputUtility.Send(InputUtility.Keyboard.MediaPlayPause);
        }

        #endregion
    }
}