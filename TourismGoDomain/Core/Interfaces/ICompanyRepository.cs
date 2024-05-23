using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Companies>> GetAll();
        Task<Companies> GetById(int id);
        Task<bool> Insert(Companies companies);
        Task<bool> Update(Companies companies);
    }
}