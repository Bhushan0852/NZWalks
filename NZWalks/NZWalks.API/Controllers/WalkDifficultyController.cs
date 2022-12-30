using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walkDiff = await walkDifficultyRepository.GetAllAsync();
            var WalkDiffDTO = mapper.Map<List<Models.DTOs.WalkDifficulty>>(walkDiff);
            return Ok(WalkDiffDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkDiffById(Guid id)
        {
            var data = await walkDifficultyRepository.GetWalkDifficultyAsync(id);
            var data1 = mapper.Map<Models.DTOs.WalkDifficulty>(data);
            return Ok(data1);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDiff([FromBody] Models.DTOs.WalkDifficultyReques walkDifficultyReques)
        {
            var data = new WalkDifficulty
            {
                Code = walkDifficultyReques.Code
            };
            var data1 = await walkDifficultyRepository.AddWalkDifficultyAsync(data);

            var data2 = mapper.Map<Models.DTOs.WalkDifficulty>(data1);

            return Ok(data2);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute]Guid id, [FromBody]Models.DTOs.WalkDifficulty walkDifficulty)
        {
            var data = new WalkDifficulty
            {
                Code = walkDifficulty.Code
            };
            var data1 = await walkDifficultyRepository.UpdateWalkDiffAsync(id, data);

            var response = mapper.Map<Models.DTOs.WalkDifficulty>(data1);
            return Ok(response);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDiffAsync(Guid id)
        {
            var res = await walkDifficultyRepository.DeleteWalkDiffAsync(id);
            return Ok(res);
        }
    }
}
