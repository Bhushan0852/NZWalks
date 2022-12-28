using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var deletedRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (deletedRegion == null)
            {
                return null;
            }

            nZWalksDbContext.Regions.Remove(deletedRegion);
            await nZWalksDbContext.SaveChangesAsync();
            return deletedRegion;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
          var extRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(c => c.Id == id);
            if(extRegion == null)
            {
                return null;
            }

            extRegion.Code = region.Code;
            extRegion.Name = region.Name;
            extRegion.Lat = region.Lat;
            extRegion.Long = region.Long;
            extRegion.Population = region.Population;
            extRegion.Area = region.Area;
            await nZWalksDbContext.SaveChangesAsync();
            return extRegion;

        }
    }
}
