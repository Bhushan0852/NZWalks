using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
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

            var regionDTO = mapper.Map<List<Models.DTOs.Region>>(regoins);

            return Ok(regionDTO);
        }


        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var data = await regionRepository.GetAsync(id);

            if(data == null)
            {
                return BadRequest();
            }

            var data1 = mapper.Map<Models.DTOs.Region>(data);
            return Ok(data1);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTOs.RegionDTO regionDTO)
        {
            var region = new Models.Domain.Region()
            {
                Area = regionDTO.Area,
                Name = regionDTO.Name,
                Code = regionDTO.Code,
                Lat = regionDTO.Lat,    
                Long = regionDTO.Long,  
                Population = regionDTO.Population
            };
            region = await regionRepository.AddAsync(region);

            var resRegion = new Models.DTOs.Region
            {
                Area = region.Area,
                Name = region.Name,
                Code = region.Code,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = resRegion.Id }, resRegion);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            return Ok(region);  
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id ,[FromBody] Models.DTOs.UpdateRegion updateRegion)
        {
            var upRegion = new Models.Domain.Region()
            {
                Code = updateRegion.Code,
                Name = updateRegion.Name,
                Area = updateRegion.Area,
                Long = updateRegion.Long,
                Lat = updateRegion.Lat,
                Population = updateRegion.Population
            };

           var res =  await regionRepository.UpdateAsync(id, upRegion);
            if(res == null)
            {
                return NotFound();
            }
            var resRegion = new Models.DTOs.Region
            {
                Area = res.Area,
                Name = res.Name,
                Code = res.Code,
                Lat = res.Lat,
                Long = res.Long,
                Population = res.Population
            };
            return Ok(resRegion);
        }
    }
}
