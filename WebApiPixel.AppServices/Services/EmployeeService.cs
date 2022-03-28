using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Employee;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public Task AddAsync(EmployeeDto model)
        {
            var employee = _mapper.Map<Employee>(model);
            return _employeeRepository.AddAsync(employee);
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var result = await _employeeRepository.GetAll().ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<EmployeeDto>>(result) : new List<EmployeeDto>();
        }

        public async Task RemoveAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception($"Не найден сотрудник с id: {id}");
            }
            await _employeeRepository.RemoveAsync(employee);
        }

        public async Task<EmployeeDto> UpdateAsync(EmployeeDto model)
        {
            var employee = _mapper.Map<Employee>(model);
            await _employeeRepository.UpdateAsync(employee);
            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
