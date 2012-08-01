using System;
using NUnit.Framework;
using PCRemote.Core.Utilities;

namespace PCRemote.Tests
{
    [TestFixture]
    public class InstagramGraberTests
    {
        [Test]
        public void grab_test()
        {
            var graber = new InstagramGraber();
            var results = graber.Grab("burberry");

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}