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
            SendComment(context, "#PCң����#�Ѿ�������ͣ���ŵ�ǰ�Ķ�ý���ļ���");
            InputUtility.Send(InputUtility.Keyboard.MediaPlayPause);
        }

        #endregion
    }
}