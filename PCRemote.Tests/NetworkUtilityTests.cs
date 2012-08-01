#region using

using NUnit.Framework;
using PCRemote.Core.Utilities;

#endregion

namespace PCRemote.Tests
{
    [TestFixture]
    public class NetworkUtilityTests
    {
        [Test]
        public void download_file_test()
        {
            var param = new DownloadParameter
                            {
                                Url = "http://mp3.baidu.com/j?j=2&url=http%3A%2F%2Fzhangmenshiting2.baidu.com%2Fdata2%2Fmusic%2F1975289%2F1975289.mp3%3Fxcode%3Dca40cf05e05d213005efbff149ebffea",
                                FilePath = @"c:\bad_day.mp3"
                            };

            NetworkUtility.DownloadFile(param);
        }
    }
}