using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyModel>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<CompanyModel> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetById(id);
            if (company == null)
            {
                throw new ArgumentException("Company not found");
            }
            return company;
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(company);
        }

        public async Task CreateAsync(CompamyCreationDto companyDto)
        {
            var entity = new CompanyModel()
            {
                Name = companyDto.Name
            };

            await _companyRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(CompanyUpdateDto company)
        {
            CompanyModel entity = new CompanyModel
            {
                Id = company.Id,
                Name = company.Name
            };

            await _companyRepository.UpdateAsync(entity);

        }
    }
}
