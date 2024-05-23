using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;

namespace TourismGoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingRepository.GetAll();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bookings = await _bookingRepository.GetById(id);
            if (bookings == null)
                return NotFound();

            return Ok(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Bookings bookings)
        {
            var result = await _bookingRepository.Insert(bookings);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Bookings bookings)
        {
            if (id != bookings.Id) return BadRequest();
            var result = await _bookingRepository.Update(bookings);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookingRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}
