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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly TourismGoContext _dbContext;
        public CompanyRepository(TourismGoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Companies>> GetAll()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Companies> GetById(int id)
        {
            return await _dbContext
                    .Companies
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Companies companies)
        {
            await _dbContext.Companies.AddAsync(companies);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Companies companies)
        {
            _dbContext.Companies.Update(companies);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findCompanies = await _dbContext
                .Companies
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (findCompanies == null) return false;

            _dbContext.Companies.Remove(findCompanies);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
