using Management.Domain.Entities;
using MongoDB.Driver;

namespace Management.Data.Context
{
    public interface IManagementContext
    {
        IMongoCollection<Part> Parts { get; }
    }
}
