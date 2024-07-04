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

        public async Task<bool> Insert(User user)
        {
            await _dbContext.User.AddAsync(user);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<User> SignIn(string email, string pwd)
        {
            return await _dbContext
                .User
                .Where(x => x.Email == email && x.Password == pwd)
                .FirstOrDefaultAsync();
        }
    }
}
