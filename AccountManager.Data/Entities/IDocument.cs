using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AccountManager.Data.Entities
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId id { get; set; }
    }
}
