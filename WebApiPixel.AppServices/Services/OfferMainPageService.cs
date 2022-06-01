using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class OfferMainPageService : IOfferMainPageService
    {
        private readonly IRepository<OfferMainPage> _offerMainPageRepository;
        private readonly IMapper _mapper;

        public OfferMainPageService(IRepository<OfferMainPage> offerMainPageRepository, IMapper mapper)
        {
            _offerMainPageRepository = offerMainPageRepository;
            _mapper = mapper;
        }
        public Task AddAsync(OfferMainPage model)
        {
            var offer = _mapper.Map<OfferMainPage>(model);
            return _offerMainPageRepository.AddAsync(offer);
        }

        public async Task<List<OfferMainPage>> GetOffers()
        {
            var result = await _offerMainPageRepository.GetAll().ToListAsync();

            return result.Count > 0 ? result : new List<OfferMainPage>();

        }

        public async Task RemoveAsync(Guid id)
        {
            var offer = await _offerMainPageRepository.GetByIdAsync(id);
            if (offer == null)
            {
                throw new Exception($"Не найдена услуга с id: {id}");
            }
            await _offerMainPageRepository.RemoveAsync(offer);

        }

        public async Task<OfferMainPage> UpdateAsync(OfferMainPage model)
        {
            var offer = model;
            await _offerMainPageRepository.UpdateAsync(offer);
            return offer;
        }
    }
}
