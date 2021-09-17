using Management.Data.Context;
using Management.Data.Persistence;
using Management.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Management.Data.Settings
{
    public class ManagementSettings : IManagementContext
    {
        public ManagementSettings(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var dataBase = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Parts = dataBase.GetCollection<Part>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            ManagementSeed.SeedDataBase(Parts);
        }

        public IMongoCollection<Part> Parts { get; }
    }
}



