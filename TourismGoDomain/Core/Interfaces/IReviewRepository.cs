using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IReviewRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Reviews>> GetAll();
        Task<Reviews> GetById(int id);
        Task<bool> Insert(Reviews reviews);
        Task<bool> Update(Reviews reviews);
    }
}