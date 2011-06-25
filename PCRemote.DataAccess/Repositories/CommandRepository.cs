using System.Collections.Generic;
using System.Linq;
using SubSonic.Repository;

namespace PCRemote.DataAccess.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        PCRemoteDB _db;
        SimpleRepository _repo;

        public CommandRepository(string connectionString) : this(new PCRemoteDB(connectionString, "System.Data.SQLite"))
        {
        }

        public CommandRepository(PCRemoteDB db)
        {
            _db = db;
            _repo = new SimpleRepository(db.Provider);
        }

        public Command FindOne(string commandName)
        {
            return _repo.Single<Command>(c => c.CommandName == commandName);
        }

        public IList<Command> FindAll()
        {
            return _repo.All<Command>().ToList();
        }

        public object Save(Command command)
        {
            return _repo.Add(command);
        }

        public int Update(Command command)
        {
            return _repo.Update(command);
        }

        public int Delete(string commandName)
        {
            var query = _db.Delete<Command>(c => c.CommandName == commandName);
            return query.Execute();
        }
    }
}