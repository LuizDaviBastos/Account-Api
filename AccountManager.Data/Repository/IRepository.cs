using AccountManager.Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AccountManager.Data.MongoService
{
    public interface IRepository<TDocument> where TDocument : IDocument
    {
        public void Save(TDocument document);
        public ReplaceOneResult Update(TDocument document);
        public ReplaceOneResult Update(TDocument document, ObjectId id);
        public ReplaceOneResult Update(TDocument document, Expression<Func<TDocument, bool>> expression);
        public DeleteResult Delete(Expression<Func<TDocument, bool>> expression);

        public IEnumerable<TDocument> Get(Expression<Func<TDocument, bool>> expression);
        public IEnumerable<TDocument> Get();

    }
}
