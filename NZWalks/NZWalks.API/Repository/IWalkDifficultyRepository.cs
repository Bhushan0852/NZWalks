using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();

        Task<WalkDifficulty> GetWalkDifficultyAsync(Guid id);

        Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> UpdateWalkDiffAsync(Guid id, WalkDifficulty updateWalkDifficulty);

        Task<WalkDifficulty> DeleteWalkDiffAsync(Guid id);

    }
}
