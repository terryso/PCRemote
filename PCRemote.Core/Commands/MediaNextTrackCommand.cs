using PCRemote.Core.Contracts;
using PCRemote.Core.Entities;
using PCRemote.Core.Utilities;

namespace PCRemote.Core.Commands
{
    public class MediaNextTrackCommand : CommandBase, ICommand
    {
        #region ICommand Members

        public void Execute(CommandContext context)
        {
            SendComment(context, "#PCң����#����Ϊ��������һ����ý���ļ���");
            InputUtility.Send(InputUtility.Keyboard.MediaNextTrack);
        }

        #endregion
    }
}