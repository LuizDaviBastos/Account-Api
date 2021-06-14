using AccountManager.Data.Entities;
using AccountManager.Data.MongoService;
using MongoDB.Driver;

namespace Account_Api.UnityOfWork
{
    public class Uow
    {
        private readonly IMongoDatabase database;
        public Uow(IMongoDatabase database) => this.database = database;

        private IRepository<Account> account = null;
        public IRepository<Account> Account { get { return GetRepository(ref account); } }

        private IRepository<TDocument> GetRepository<TDocument>(ref IRepository<TDocument> repository) where TDocument : IDocument
        {
            if (repository != null) return repository;
            repository = new Repository<TDocument>(database);
            return repository;
        }
    }
}
