using PCRemote.Core.Entities;

namespace PCRemote.Core.Contracts
{
    public interface ICommand
    {
        void Execute(CommandContext context);
    }
}