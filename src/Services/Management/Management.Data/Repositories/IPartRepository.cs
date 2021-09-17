using Management.Domain.Entities;

namespace Management.Data.Repositories
{
    public interface IPartRepository
    {
        Task<IEnumerable<Part>> GetParts();
        Task<Part> GetPart(string id);
        Task<IEnumerable<Part>> GetPartByName(string name);
        Task<IEnumerable<Part>> GetPartByCategory(string category);

        Task CreatePart(Part part);
        Task<bool> UpdatePart(Part part);
        Task<bool> DeletePart(string id);

    }
}
