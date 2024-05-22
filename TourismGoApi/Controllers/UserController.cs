using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;

namespace TourismGoApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var users = await _userRepository.GetById(id);
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Users users)
        {
            var result = await _userRepository.Insert(users);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Users users)
        {
            if (id != users.Id) return BadRequest();
            var result = await _userRepository.Update(users);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}
