using TourismGoDomain.Core.DTO;
using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> Insert(User user);
        Task<UserResponseAuthDTO> SignIn(string email, string pwd);
        Task<bool> ChangePassword(string email, string currentPassword, string newPassword);
    }
}