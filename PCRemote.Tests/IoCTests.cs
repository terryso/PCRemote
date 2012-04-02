using Ninject;
using NUnit.Framework;
using PCRemote.Core.Commands;
using PCRemote.Core.Contracts;
using PCRemote.Core.NinjectModules;

namespace PCRemote.Tests
{
    [TestFixture]
    public class IoCTests
    {
        IKernel _kernel;

        [SetUp]
        public void Init()
        {
            _kernel = new StandardKernel(new CommandModule());
        }

        [Test]
        public void get_object_by_name_test()
        {
            // Arrange

            // Act
            var command = _kernel.TryGet<ICommand>("lock");

            // Assert
            Assert.IsNotNull(command);
            Assert.IsTrue(command is LockCommand);

        }  

        [Test]
        public void Inject_With_Parameter_Test()
        {
            // Arrange

            // Act
            var command = _kernel.TryGet<ICommand>("play");

            // Assert
            Assert.IsNotNull(command);

        }

        [Test]
        public void get_a_object_with_the_wrong_name_should_return_null()
        {
            // Arrange

            // Act
            var command = _kernel.TryGet<ICommand>("hello");

            // Assert
            Assert.IsNull(command);

        }
    }
}