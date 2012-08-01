using System;
using NUnit.Framework;
using PCRemote.Core.Utilities;

namespace PCRemote.Tests
{
    [TestFixture]
    public class BaiduMp3GraberTests
    {
        [Test]
        [TestCase("天与地", "黄贯中", 3)]
        [TestCase("my heart will go on", "celine dion", 5)]
        public void grab_should_return_the_correct_download_link(string song, string singer, int count)
        {
            var graber = new BaiduMp3Graber();

            var result = graber.Grab(song, singer);
            
            Assert.AreEqual(count, result.Count);
        }
    }
}