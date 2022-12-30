using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs.WalkDTOs;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()

        {
            var data = await walkRepository.GetALLAsync();

            var walkDTO = mapper.Map<List<Models.DTOs.Walk>>(data);
            return Ok(walkDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsnyc")]
        public async Task<IActionResult> GetWalkAsnyc(Guid id)
        {
            var data = await walkRepository.GetWalkAsync(id);

            var data2 = mapper.Map<Models.DTOs.Walk>(data);
            if (data2 == null)
            {
                return NotFound();
            }
            return Ok(data2);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Models.DTOs.AddWalkReques addWalkReques)
        {
            var WalkDomain = new Models.Domain.Walk
            {
                Name = addWalkReques.Name,
                Length = addWalkReques.Length,
                RegionId = addWalkReques.RegionId,
                WalkDifficultyId = addWalkReques.WalkDifficultyId
            };
            var data = await walkRepository.AddWalkAsync(WalkDomain);

            var walkDTO = new Models.DTOs.Walk
            {
                Id = data.Id,
                Name = data.Name,
                Length = data.Length,
                RegionId = data.RegionId,
                WalkDifficultyId = data.WalkDifficultyId
            };
            return CreatedAtAction(nameof(GetWalkAsnyc), new { id = walkDTO.Id }, walkDTO);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.DTOs.WalkDTOs.UpdateWalkRequest updateWalkRequest)
        {
            //update domain to main domain
            var walkDomain = new Models.Domain.Walk
            {
                Name = updateWalkRequest.Name,
                Length = updateWalkRequest.Length,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };
            //send request and get responce
            var result = await walkRepository.UpdateWalkAsync(id, walkDomain);

            if (result == null)
            {
                return NotFound("Data not exsist");
            }
            //convert domain to dto model

            var response = new Models.DTOs.Walk
            {
                Id = result.Id,
                WalkDifficultyId = result.WalkDifficultyId,
                Name = result.Name,
                Length = result.Length,
                RegionId = result.RegionId
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> RemoveWalkAsync(Guid id)
        {
            var result = await walkRepository.DeleteWalkAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
