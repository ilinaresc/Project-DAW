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
    public class UserRepository : IUserRepository
    {
        private readonly TourismGoContext _dbContext;
        public UserRepository(TourismGoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<Users> GetById(int id)
        {
            return await _dbContext
                    .Users
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Users users)
        {
            await _dbContext.Users.AddAsync(users);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Users users)
        {
            _dbContext.Users.Update(users);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findUsers = await _dbContext
                .Users
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();

            if (findUsers == null) return false;

            _dbContext.Users.Remove(findUsers);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
