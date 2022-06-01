using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.OrderHronology;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class OrderHronologyService : IOrderHronologyService
    {
        private readonly IRepository<OrderHronology> _orderHronologyRepository;
        private readonly IMapper _mapper;

        public OrderHronologyService(IRepository<OrderHronology> orderHronologyRepository, IMapper mapper)
        {
            _orderHronologyRepository = orderHronologyRepository;
            _mapper = mapper;
        }

        public Task AddAsync(OrderHronologyDto model)
        {
            var orderHronology = _mapper.Map<OrderHronology>(model);
            return _orderHronologyRepository.AddAsync(orderHronology);
        }

        public async Task<List<OrderHronologyDto>> GetOrderHronologys()
        {
            var result = await _orderHronologyRepository.GetAll().ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<OrderHronologyDto>>(result) : new List<OrderHronologyDto>();
        }

        public async Task<List<OrderHronologyDto>> GetOrderHronologyById(Guid id)
        {
            var result = await _orderHronologyRepository.GetAll()
                .Where(x => x.IdOrder == id)
                .ToListAsync();
            return result.Count > 0 ? _mapper.Map<List<OrderHronologyDto>>(result) : new List<OrderHronologyDto>();
        }

        public async Task RemoveAsync(Guid id)
        {
            var employee = await _orderHronologyRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new Exception($"Не найдена хронология с id: {id}");
            }
            await _orderHronologyRepository.RemoveAsync(employee);
        }

        public async Task<OrderHronologyDto> UpdateAsync(OrderHronologyDto model)
        {
            var orderHronology = _mapper.Map<OrderHronology>(model);
            await _orderHronologyRepository.UpdateAsync(orderHronology);
            return _mapper.Map<OrderHronologyDto>(orderHronology);
        }
    }
}
