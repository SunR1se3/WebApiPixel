using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.Ware;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class WareService : IWareService
    {
        private readonly IRepository<Ware> _wareRepository;
        private readonly IMapper _mapper;

        public WareService(IRepository<Ware> wareRepository, IMapper mapper)
        {
            _wareRepository = wareRepository;
            _mapper = mapper;
        }

        public Task AddAsync(WareDto model)
        {
            var ware = _mapper.Map<Ware>(model);
            return _wareRepository.AddAsync(ware);
        }

        public async Task<List<WareDto>> GetWares()
        {
            var result = await _wareRepository.GetAll().ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<WareDto>>(result) : new List<WareDto>();
        }

        public async Task RemoveAsync(Guid id)
        {
            var ware = await _wareRepository.GetByIdAsync(id);
            if (ware == null)
            {
                throw new Exception($"Не найден товар с id: {id}");
            }
            await _wareRepository.RemoveAsync(ware);
        }

        public async Task<WareDto> UpdateAsync(WareDto model)
        {
            var ware = _mapper.Map<Ware>(model);
            await _wareRepository.UpdateAsync(ware);
            return _mapper.Map<WareDto>(ware);
        }
    }
}
