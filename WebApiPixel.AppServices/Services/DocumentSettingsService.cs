using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.DocumentSettings;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class DocumentSettingsService : IDocumentSettingsService
    {
        private readonly IRepository<DocumentSettings> _documentSettingsRepository;
        private readonly IMapper _mapper;

        public DocumentSettingsService(IRepository<DocumentSettings> documentSettingsRepository, IMapper mapper)
        {
            _documentSettingsRepository = documentSettingsRepository;
            _mapper = mapper;
        }
        public Task AddAsync(DocumentSettingsDto model)
        {
            var settings = _mapper.Map<DocumentSettings>(model);
            return _documentSettingsRepository.AddAsync(settings);
        }

        public async Task<List<DocumentSettingsDto>> GetDocumentSettings()
        {
            var result = await _documentSettingsRepository.GetAll().ToListAsync();

            return result.Count > 0 ? _mapper.Map<List<DocumentSettingsDto>>(result) : new List<DocumentSettingsDto>();
        }

        public async Task<DocumentSettingsDto> GetDocumentSettingsById(Guid id)
        {
            var setting = await _documentSettingsRepository.GetByIdAsync(id);
            if (setting == null)
            {
                throw new Exception($"Не найден параметр с id: {id}");
            }
            return _mapper.Map<DocumentSettingsDto>(setting);
        }

        public async Task RemoveAsync(Guid id)
        {
            var settings = await _documentSettingsRepository.GetByIdAsync(id);
            if (settings == null)
            {
                throw new Exception($"Не найден параметр с id: {id}");
            }
            await _documentSettingsRepository.RemoveAsync(settings);
        }

        public async Task<DocumentSettingsDto> UpdateAsync(DocumentSettingsDto model)
        {
            var settings = _mapper.Map<DocumentSettings>(model);
            await _documentSettingsRepository.UpdateAsync(settings);
            return _mapper.Map<DocumentSettingsDto>(settings);
        }
    }
}
