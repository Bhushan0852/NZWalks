using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetALLAsync();
        Task<Walk> GetWalkAsync(Guid id);
        Task<Walk> AddWalkAsync(Walk walk);
        Task<Walk> UpdateWalkAsync(Guid id, Walk walk);

        Task<Walk> DeleteWalkAsync(Guid id);
    }
}
