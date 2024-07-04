using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Insert(User user);
        Task<User> SignIn(string email, string pwd);
    }
}