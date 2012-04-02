using NUnit.Framework;
using PCRemote.Core.Utilities;

namespace PCRemote.Tests
{
    [TestFixture]
    public class ThunderTests
    {
        [Test]
        public void Download_By_Thunder_Test()
        {
            // Arrange
            var thunder = new ThunderUtility("c:\\test.jpg", "http://ww2.sinaimg.cn/large/62ca3fd6jw1dj8q17kranj.jpg",
                                             "");

            // Act

            // Assert
        }
    }
}