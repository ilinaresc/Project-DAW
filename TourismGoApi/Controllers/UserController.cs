using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourismGoDomain.Core.DTO;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;

namespace TourismGoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserRequestAuthDTO userRequest)
        {
            var user = new User()
            {
                Email = userRequest.Email,
                Password = userRequest.Password,
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Country = userRequest.Country,
                DateOfBirth = userRequest.DateOfBirth,
                Address = userRequest.Address,
                IsActive = true,
                Type = "U"
            };

            var result = await _userService.Insert(user);
            if (!result) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserAuthDTO authDTO)
        {
            //TODO: Validar email
            var result = await _userService.SignIn(authDTO.Email, authDTO.Password);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Nuevo método para cambiar la contraseña
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.CurrentPassword) || string.IsNullOrEmpty(request.NewPassword))
            {
                return BadRequest("Los datos son inválidos.");
            }

            var result = await _userService.ChangePassword(request.Email, request.CurrentPassword, request.NewPassword);
            if (!result) return Unauthorized("Email o contraseña actual incorrectos.");
            return Ok("Contraseña cambiada con éxito.");
        }

        // Para Agregar un nuevo usuario
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserRequestAuthDTO userRequest)
        {
            if (userRequest == null || string.IsNullOrEmpty(userRequest.Email) || string.IsNullOrEmpty(userRequest.Password))
            {
                return BadRequest("Los datos del usuario son inválidos.");
            }

            var user = new User()
            {
                Email = userRequest.Email,
                Password = userRequest.Password,
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Country = userRequest.Country,
                DateOfBirth = userRequest.DateOfBirth,
                Address = userRequest.Address,
                IsActive = true,
                Type = "U"
            };

            var result = await _userService.Insert(user);
            if (!result) return BadRequest("No se pudo crear el usuario.");
            return Ok("Usuario creado con éxito.");
        }


    }
}
