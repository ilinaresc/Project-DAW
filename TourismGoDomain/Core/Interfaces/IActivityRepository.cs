using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Infrastructure.Repositories
{
    public interface IActivityRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Activities>> GetAll();
        Task<Activities> GetById(int id);
        Task<bool> Insert(Activities activities);
        Task<bool> Update(Activities activities);
    }
}