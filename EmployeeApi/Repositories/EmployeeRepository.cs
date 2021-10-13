using EmployeeApi.Data;
using EmployeeApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using EmployeeApi.Services;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeModel>> GetAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(EmployeeModel employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EmployeeModel employee)
        {
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        } 

        public async Task UpdateAsync(EmployeeModel employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
      
    }

}
