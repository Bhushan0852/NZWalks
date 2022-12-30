using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repository;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository,IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
       public  async Task<IActionResult> GetAllAsync()
        {
           var walkDiff = await walkDifficultyRepository.GetAllAsync();
            var WalkDiffDTO = mapper.Map<Models.DTOs.WalkDifficulty>(walkDiff);
            return Ok(WalkDiffDTO);
        }
    }
}
