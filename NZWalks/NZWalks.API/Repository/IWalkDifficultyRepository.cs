using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();

    }
}
