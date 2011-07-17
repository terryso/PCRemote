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
            SendComment(context, "#PCң����#����Ϊ�����ŵ�ǰ�Ķ�ý���ļ���");
            InputUtility.Send(InputUtility.Keyboard.MediaPlayPause);
        }

        #endregion
    }
}