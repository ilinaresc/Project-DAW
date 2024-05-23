using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
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