using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Order;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task AddAsync(OrderDto model)
        {
            var order = _mapper.Map<Order>(model);
            return _orderRepository.AddAsync(order);
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var result = await _orderRepository.GetAll().ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<OrderDto>>(result) : new List<OrderDto>();
        }

        public async Task RemoveAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception($"Не найден заказ с id: {id}");
            }
            await _orderRepository.RemoveAsync(order);
        }

        public async Task<OrderDto> UpdateAsync(OrderDto model)
        {
            var order = _mapper.Map<Order>(model);
            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
