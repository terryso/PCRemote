using NUnit.Framework;
using PCRemote.Core.Configuration;

namespace PCRemote.Tests
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void Get_Commands_Test()
        {
            // Arrange

            // Act
            var commands = CommandConfiguration.GetConfig().Commands;

            // Assert
            Assert.Greater(commands.Count, 0);
        }
        
    }
}