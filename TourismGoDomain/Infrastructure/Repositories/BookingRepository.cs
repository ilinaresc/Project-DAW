using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Core.Interfaces;
using TourismGoDomain.Infrastructure.Data;

namespace TourismGoDomain.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TourismGoContext _dbContext;

        public BookingRepository(TourismGoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Bookings>> GetAll()
        {
            return await _dbContext.Bookings.ToListAsync();
        }

        public async Task<Bookings> GetById(int id)
        {
            return await _dbContext
                .Bookings
                .FindAsync(id);
        }

        public async Task<bool> Insert(Bookings bookings)
        {
            await _dbContext.Bookings.AddAsync(bookings);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Bookings bookings)
        {
            _dbContext.Bookings.Update(bookings);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findBookings = await _dbContext
                .Bookings
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (findBookings == null) return false;

            _dbContext.Bookings.Remove(findBookings);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
