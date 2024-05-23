using TourismGoDomain.Core.Entities;

namespace TourismGoDomain.Core.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Bookings>> GetAll();
        Task<Bookings> GetById(int id);
        Task<bool> Insert(Bookings bookings);
        Task<bool> Update(Bookings bookings);
    }
}