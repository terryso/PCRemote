using Ninject.Modules;
using PCRemote.Core.Commands;
using PCRemote.Core.Contracts;

namespace PCRemote.Core.NinjectModules
{
    public class CommandModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<ICommand>().To<LockCommand>().Named("lock");
            Bind<ICommand>().To<LockCommand>().Named("Ëø¶¨");
        }
    }
}