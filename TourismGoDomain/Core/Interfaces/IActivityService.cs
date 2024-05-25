using TourismGoDomain.Core.DTO;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDTOList>> GetAll();
        Task<ActivityDTOList> GetById(int id);
    }
}