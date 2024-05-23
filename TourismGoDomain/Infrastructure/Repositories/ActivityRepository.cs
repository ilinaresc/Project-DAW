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
    public class ActivityRepository : IActivityRepository
    {
        private readonly TourismGoContext _dbContext;

        public ActivityRepository(TourismGoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Activities>> GetAll()
        {
            return await _dbContext.Activities.ToListAsync();
        }

        public async Task<Activities> GetById(int id)
        {
            return await _dbContext
                .Activities
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Activities activities)
        {
            await _dbContext.Activities.AddAsync(activities);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Activities activities)
        {
            _dbContext.Activities.Update(activities);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findActivity = await _dbContext
                .Activities
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (findActivity == null) return false;

            _dbContext.Activities.Remove(findActivity);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
