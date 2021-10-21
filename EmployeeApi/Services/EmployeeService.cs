using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<UpdateEmployeeDto>> GetAllAsync()
        {
            
            var employeeEntities = await _employeeRepository.GetAsync();
            var dtos = employeeEntities.Select(e => new UpdateEmployeeDto()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                CompanyId = e.CompanyId,
                GenderType = e.GenderType.ToString()

            });

            return dtos.ToList();
        }

        public async Task<EmployeeModel> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task <int> AddAsync(CreationEmployeeDto creationEmployeeDto)
        {

            var genderType = Enum.Parse<GenderType>(creationEmployeeDto.GenderType ?? "Unspecified");
            var entity = new EmployeeModel()
            {
                FirstName = creationEmployeeDto.FirstName,
                LastName = creationEmployeeDto.LastName,
                GenderType = genderType,
                CompanyId = creationEmployeeDto.CompanyId
            };


            if (creationEmployeeDto.CompanyId.HasValue)
            {
                var company = await _companyRepository.GetById(creationEmployeeDto.CompanyId.Value);
                if (company == null)
                {
                    throw new ArgumentException("Employee does not exist");
                }
            }

            await _employeeRepository.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }

        public async Task UpdateAsync(UpdateEmployeeDto employee)
        {
            var genderType = Enum.Parse<GenderType>(employee.GenderType ?? "Unspecified");
            EmployeeModel entity = new EmployeeModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                GenderType = genderType,
                CompanyId = employee.CompanyId

            };

            await _employeeRepository.UpdateAsync(entity);

        }
    }
}
