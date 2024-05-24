using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;
using TourismGoDomain.Infrastructure.Repositories;

namespace TourismGoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewRepository.GetAll();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reviews = await _reviewRepository.GetById(id);
            if (reviews == null)
                return NotFound();

            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Reviews reviews)
        {
            var result = await _reviewRepository.Insert(reviews);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Reviews reviews)
        {
            if (id != reviews.Id) return BadRequest();
            var result = await _reviewRepository.Update(reviews);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reviewRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}
