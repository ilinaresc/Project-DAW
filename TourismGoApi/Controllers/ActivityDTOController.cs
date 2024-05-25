using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;
using TourismGoDomain.Infrastructure.Repositories;

namespace TourismGoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityDTOController : ControllerBase
    {

        private readonly IActivityService _activityService;
        public ActivityDTOController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activityService.GetAll();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activities = await _activityService.GetById(id);
            if (activities == null)
                return NotFound();

            return Ok(activities);
        }

    }
}
