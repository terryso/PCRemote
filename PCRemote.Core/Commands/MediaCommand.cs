#region using

using PCRemote.Core.Contracts;
using PCRemote.Core.Utilities;

#endregion

namespace PCRemote.Core.Commands
{
    public enum MediaKey
    {
        PlayPause = 0,
        Next = 1,
        Previous = 2,
        Stop = 3,
        VolumeUp,
        VolumeDown,
        Mute
    }

    public class MediaCommand : ICommand
    {
        readonly MediaKey _mediaKey;

        public MediaCommand(MediaKey mediaKey)
        {
            _mediaKey = mediaKey;
        }

        #region ICommand Members

        public void Execute()
        {
            switch (_mediaKey)
            {
                case MediaKey.PlayPause:
                    InputUtility.Send(InputUtility.Keyboard.MediaPlayPause);
                    break;
                case MediaKey.Next:
                    InputUtility.Send(InputUtility.Keyboard.MediaNextTrack);
                    break;
                case MediaKey.Previous:
                    InputUtility.Send(InputUtility.Keyboard.MediaPreviousTrack);
                    break;
                case MediaKey.Stop:
                    InputUtility.Send(InputUtility.Keyboard.MediaStop);
                    break;
                case MediaKey.VolumeUp:
                    InputUtility.Send(InputUtility.Keyboard.VolumeUp);
                    break;
                    ;
                case MediaKey.VolumeDown:
                    InputUtility.Send(InputUtility.Keyboard.VolumeDown);
                    break;
                case MediaKey.Mute:
                    InputUtility.Send(InputUtility.Keyboard.VolumeMute);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}