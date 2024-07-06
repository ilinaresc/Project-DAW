using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Insert(User user);
        Task<User> SignIn(string email, string pwd);
        Task<bool> ChangePassword(string email, string currentPassword, string newPassword);
        
        Task<bool> Update(User user); 
    }
}