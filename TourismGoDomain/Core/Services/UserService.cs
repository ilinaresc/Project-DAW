using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourismGoDomain.Core.DTO;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;

namespace TourismGoDomain.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jWTService;
        public UserService(IUserRepository userRepository, IJWTService jWTService)
        {
            _userRepository = userRepository;
            _jWTService = jWTService;
        }



        public async Task<UserResponseAuthDTO> SignIn(string email, string pwd)
        {
            var user = await _userRepository.SignIn(email, pwd);
            if (user == null)
                return null;

            //TODO: implementar token & email
            var token = _jWTService.GenerateJWToken(user);
            var sendEmail = false;

            var userResponseAuth = new UserResponseAuthDTO()
            {
                Id = user.Id,
                Email = email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth,
                Token = token,
                IsEmailSent = sendEmail,
                Address = user.Address
            };
            return userResponseAuth;
        }

        public async Task<bool> Insert(User user)
        {
            return await _userRepository.Insert(user);
        }

        public async Task<bool> ChangePassword(string email, string currentPassword, string newPassword)
        {
            var user = await _userRepository.SignIn(email, currentPassword);
            if (user == null)
                return false;

            user.Password = newPassword;
            return await _userRepository.Update(user);
        }

        public async Task<bool> AddUser(UserRequestAuthDTO userRequest)
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

            return await _userRepository.Insert(user);
        }



    }
}
