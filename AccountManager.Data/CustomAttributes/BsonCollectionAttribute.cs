using System;

namespace AccountManager.Data.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        private string collectionName;
        public BsonCollectionAttribute(string collectionName)
        {
            this.collectionName = collectionName;
        }
        public string CollectionName => collectionName;
    }
}
