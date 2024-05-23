using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismGoDomain.Core.Entities;
using TourismGoDomain.Infrastructure.Data;

namespace TourismGoDomain.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly TourismGoContext _dbContext;

        public ReviewRepository(TourismGoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Reviews>> GetAll()
        {
            return await _dbContext.Reviews.ToListAsync();
        }

        public async Task<Reviews> GetById(int id)
        {
            return await _dbContext
                .Reviews
                .FindAsync(id);
        }

        public async Task<bool> Insert(Reviews reviews)
        {
            await _dbContext.Reviews.AddAsync(reviews);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Reviews reviews)
        {
            _dbContext.Reviews.Update(reviews);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findReviews = await _dbContext
                .Reviews
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (findReviews == null) return false;

            _dbContext.Reviews.Remove(findReviews);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
