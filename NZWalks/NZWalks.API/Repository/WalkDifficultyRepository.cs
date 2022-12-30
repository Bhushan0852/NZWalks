using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty)
        {
            var data = new WalkDifficulty
            {
                Id = Guid.NewGuid(),
                Code = walkDifficulty.Code
            };
            await nZWalksDbContext.WalkDifficulties.AddAsync(data);
            await nZWalksDbContext.SaveChangesAsync();
            return data;
        }

        public async Task<WalkDifficulty> DeleteWalkDiffAsync(Guid id)
        {
            var data = await nZWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(c => c.Id == id);
             nZWalksDbContext.WalkDifficulties.Remove(data);
            await nZWalksDbContext.SaveChangesAsync();
            return data;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
          return await nZWalksDbContext.WalkDifficulties.ToListAsync();
        }

        public async Task<WalkDifficulty> GetWalkDifficultyAsync(Guid id)
        {
            return await nZWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<WalkDifficulty> UpdateWalkDiffAsync(Guid id, WalkDifficulty updateWalkDifficulty)
        {
            var data = await nZWalksDbContext.WalkDifficulties.FirstOrDefaultAsync(v => v.Id == id);
            if(data != null)
            {
                data.Code = updateWalkDifficulty.Code;
                await nZWalksDbContext.SaveChangesAsync();
            }
            return data;
        }
    }
}
