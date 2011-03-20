using System;
using System.Diagnostics;
using NUnit.Framework;
using PCRemote.Core.Utilities;

namespace PCRemote.Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void TaskListCommand_Test()
        {
            var result = DosCommandUtility.RunCmd("tasklist");

            Console.WriteLine(result.ToString());
        }
    }
}