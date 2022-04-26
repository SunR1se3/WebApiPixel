using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.EmployeeOrderDto;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class EmployeeOrderService : IEmployeeOrderService
    {
        private readonly IRepository<EmployeeOrder> _employeeOrderRepository;
        private readonly IMapper _mapper;

        public EmployeeOrderService(IRepository<EmployeeOrder> employeeOrderRepository, IMapper mapper)
        {
            _employeeOrderRepository = employeeOrderRepository;
            _mapper = mapper;
        }
        public Task AddAsync(EmployeeOrderDto model)
        {
            var employeeOrder = _mapper.Map<EmployeeOrder>(model);
            return _employeeOrderRepository.AddAsync(employeeOrder);
        }

        public async Task<List<EmployeeOrderDto>> GetEmployeeOrders()
        {
            var result = await _employeeOrderRepository.GetAll()
                .Include(e => e.Employee)
                .ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<EmployeeOrderDto>>(result) : new List<EmployeeOrderDto>();

        }

        public async Task RemoveAsync(Guid id)
        {
            var employeeOrder = await _employeeOrderRepository.GetByIdAsync(id);
            if (employeeOrder == null)
            {
                throw new Exception($"Не найдена запись с id: {id}");
            }
            await _employeeOrderRepository.RemoveAsync(employeeOrder);

        }

        public async Task<EmployeeOrderDto> UpdateAsync(EmployeeOrderDto model)
        {
            var employeeOrder = _mapper.Map<EmployeeOrder>(model);
            await _employeeOrderRepository.UpdateAsync(employeeOrder);
            return _mapper.Map<EmployeeOrderDto>(employeeOrder);
        }
    }
}
