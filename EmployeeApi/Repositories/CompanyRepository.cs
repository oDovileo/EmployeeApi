using EmployeeApi.Data;
using EmployeeApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public class CompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CompanyModel>> GetAllAsync()
        {
            return await _context.Companies.Include(e => e.Employees).ToListAsync();
        }

        public async Task<CompanyModel> GetById(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(pl => pl.Id == id);
        }

        public async Task CreateAsync(CompanyModel company)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CompanyModel company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(CompanyModel company)
        {
            _context.Update(company);
            await _context.SaveChangesAsync();
        }
           
    }
}
