using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;


namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;
        private CompanyRepository _companyRepository;
        public EmployeeService(EmployeeRepository employeeRepository, CompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }
        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            return await _employeeRepository.GetAsync();
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(EmployeeModel employee)
        {
            if (employee.CompanyId.HasValue)
            {
                var company = await _companyRepository.GetById(employee.CompanyId.Value);
                if (company == null)
                {
                    throw new ArgumentException("Employee does not exist");
                }
            }

            await _employeeRepository.AddAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task UpdateAsync(UpdateEmployeeDto employee)
        {
            EmployeeModel entity = new EmployeeModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Sex = employee.Sex,
                CompanyId = employee.CompanyId

            };

            await _employeeRepository.UpdateAsync(entity);

        }
    }
}
