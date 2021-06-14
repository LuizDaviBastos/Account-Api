using AccountManager.Data.CustomAttributes;
using MongoDB.Bson;

namespace AccountManager.Data.Entities
{
    [BsonCollection("Contas")]
    public class Account : IDocument
    {
        public ObjectId id { get; set; }
    }
}
