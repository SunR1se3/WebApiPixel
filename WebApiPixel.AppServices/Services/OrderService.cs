using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Order;
using WebApiPixel.Contracts.OrderHronology;
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

        public void SendEmailAsync(Guid idOrder, string email)
        {
            MailAddress from = new MailAddress("webapipixel@mail.ru", "info");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Заявка успешно оформлена!";
            m.Body = "Здравствуйте! Ваш уникальный номер заказа " + idOrder.ToString();
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
            smtp.Credentials = new NetworkCredential("webapipixel@mail.ru", "Ya6mhjR7X5dvrBGKV99D");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        public Task AddAsync(OrderDto model)
        {
            var order = _mapper.Map<Order>(model);
            var result = _orderRepository.AddAsync(order);
            //SendEmailAsync(idOrder);
            return result;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var result = await _orderRepository.GetAll()
                .Include(o => o.Ware)
                .ToListAsync();
            var r = result.AsQueryable().Last();
            return result.Count > 0 ? _mapper.Map<List<OrderDto>>(result) : new List<OrderDto>();
        }

        public async Task<OrderDto> GetOrderById(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                throw new Exception($"Не найден заказ с id: {id}");
            }
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> GetLastOrder()
        {
            var result = await _orderRepository.GetAll()
                .Include(o => o.Ware)
                .ToListAsync();
            return _mapper.Map<OrderDto>(result.AsQueryable().LastOrDefault());
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
