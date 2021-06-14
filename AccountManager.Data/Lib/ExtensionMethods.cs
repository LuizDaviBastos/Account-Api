using AccountManager.Data.CustomAttributes;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Linq;

namespace AccountManager.Data.Lib.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string GetCollectionName(this Type attribute)
        {
            return (attribute.GetType().GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault() as BsonCollectionAttribute).CollectionName;
        }

        public static IServiceCollection AddMongoClient(this IServiceCollection services, string connectionString, string baseName)
        {
            return services.AddScoped<IMongoDatabase>(x => new MongoClient(connectionString).GetDatabase(baseName));
        }
    }
}
