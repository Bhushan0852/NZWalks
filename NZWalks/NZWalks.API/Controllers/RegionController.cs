using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
            var regoins = await regionRepository.GetAllAsync();

            //var dtoRegion = new List<Models.DTOs.Region>();
            //regoins.ToList().ForEach(r =>
            //{
            //    var dtoReg = new Models.DTOs.Region()
            //    {
            //        Id = r.Id,
            //        Name = r.Name,
            //        Area = r.Area,
            //        Code = r.Code,
            //        Lat = r.Lat,
            //        Long = r.Long,
            //        Population = r.Population
            //    };
            //    dtoRegion.Add(dtoReg);  
            //});



            return Ok(regoins);
        }
    }
}
