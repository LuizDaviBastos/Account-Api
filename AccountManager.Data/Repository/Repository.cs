using AccountManager.Data.Entities;
using AccountManager.Data.Lib.ExtensionMethods;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AccountManager.Data.MongoService
{
    public class Repository<TDocument> : IRepository<TDocument> where TDocument : IDocument
    {
        public readonly IMongoDatabase database;
        public readonly IMongoCollection<TDocument> collection;
        public Repository(IMongoDatabase database)
        {
            this.database = database;
            collection = database.GetCollection<TDocument>(typeof(TDocument).GetCollectionName());
        }

        public DeleteResult Delete(Expression<Func<TDocument, bool>> expression) => collection.DeleteOne(expression);

        public IEnumerable<TDocument> Get(Expression<Func<TDocument, bool>> expression) => collection.Find(expression).ToEnumerable();

        public IEnumerable<TDocument> Get() => collection.Find(x => true).ToEnumerable();

        public void Save(TDocument document) => collection.InsertOne(document);

        public ReplaceOneResult Update(TDocument document) => collection.ReplaceOne(x => x.id.Equals(document.id), document);

        public ReplaceOneResult Update(TDocument document, ObjectId id) => collection.ReplaceOne(x => x.id.Equals(id), document);

        public ReplaceOneResult Update(TDocument document, Expression<Func<TDocument, bool>> expression) => collection.ReplaceOne(expression, document);
    }
}
