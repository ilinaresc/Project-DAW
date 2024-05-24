using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;
using TourismGoDomain.Infrastructure.Repositories;

namespace TourismGoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activityRepository.GetAll();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activities = await _activityRepository.GetById(id);
            if (activities == null)
                return NotFound();

            return Ok(activities);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Activities activities)
        {
            var result = await _activityRepository.Insert(activities);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Activities activities)
        {
            if (id != activities.Id) return BadRequest();
            var result = await _activityRepository.Update(activities);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _activityRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}
