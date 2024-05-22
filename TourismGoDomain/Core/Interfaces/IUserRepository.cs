using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Users>> GetAll();
        Task<Users> GetById(int id);
        Task<bool> Insert(Users users);
        Task<bool> Update(Users users);
    }
}