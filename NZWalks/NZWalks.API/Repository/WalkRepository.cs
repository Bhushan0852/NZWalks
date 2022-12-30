using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteWalkAsync(Guid id)
        {
            var data = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return null;
            }
             nZWalksDbContext.Walks.Remove(data);
           await nZWalksDbContext.SaveChangesAsync();

            return data;

        }

        public async Task<IEnumerable<Walk>> GetALLAsync()
        {
            return await
                 nZWalksDbContext.Walks
                 .Include(x => x.Regions)
                 .Include(x => x.WalkDifficulties)
                 .ToListAsync();
        }

        public async Task<Walk> GetWalkAsync(Guid id)
        {
            return await nZWalksDbContext.Walks
                .Include(x => x.Regions)
                .Include(x => x.WalkDifficulties)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateWalkAsync(Guid id, Walk walk)
        {
            var data = await nZWalksDbContext.Walks.FirstOrDefaultAsync(wl => wl.Id == id);
            if (data != null)
            {
                data.Name = walk.Name;
                data.Length = walk.Length;
                data.RegionId = walk.RegionId;
                data.WalkDifficultyId = walk.WalkDifficultyId;
                await nZWalksDbContext.SaveChangesAsync();
            }

            if (data == null)
            {
                return null;
            }
            return data;
        }
    }
}
