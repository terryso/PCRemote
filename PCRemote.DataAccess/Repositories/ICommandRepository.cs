using System.Collections.Generic;

namespace PCRemote.DataAccess.Repositories
{
    public interface ICommandRepository
    {
        Command FindOne(string commandName);
        IList<Command> FindAll();
        object Save(Command command);
        int Update(Command command);
        int Delete(string commandName);
    }
}