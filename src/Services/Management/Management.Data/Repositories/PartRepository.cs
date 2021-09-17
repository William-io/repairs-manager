using Management.Data.Context;
using Management.Domain.Entities;
using MongoDB.Driver;

namespace Management.Data.Repositories
{
    public class PartRepository : IPartRepository
    {
        private readonly IManagementContext _context;

        public PartRepository(IManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Part>> GetParts()
        {
            return await _context
                        .Parts
                        .Find(p => true)
                        .ToListAsync();
        }

        public async Task<Part> GetPart(string id)
        {
            return await _context
                            .Parts
                            .Find(p => p.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Part>> GetPartByName(string name)
        {
            FilterDefinition<Part> filter = Builders<Part>.Filter.Eq(p => p.Name, name);
            return await _context
                            .Parts
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Part>> GetPartByCategory(string categoryName)
        {
            FilterDefinition<Part> filter = Builders<Part>.Filter.Eq(p => p.Category, categoryName);
            return await _context
                            .Parts
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreatePart(Part part)
        {
            await _context.Parts.InsertOneAsync(part);
        }

        public async Task<bool> UpdatePart(Part part)
        {
            var updateResult = await _context
                                        .Parts
                                        .ReplaceOneAsync(filter: g => g.Id == part.Id, replacement: part);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeletePart(string id)
        {
            FilterDefinition<Part> filter = Builders<Part>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context
                                                .Parts
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}