using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Contracts.CalculatorDocuments;
using WebApiPixel.Domain.Entities;
using WebApiPixel.Infrastructure.Repository;

namespace WebApiPixel.AppServices.Services
{
    public class CalculatorDocumentsService : ICalculatorDocumentsService
    {
        //private readonly IRepository<CalculatorDocuments> _calculatorDocumentsRepository;
        private readonly IRepository<DocumentSettings> _documentSettingsRepository;

        private List<CalculatorDocuments> db = new List<CalculatorDocuments>();

        public CalculatorDocumentsService(IRepository<DocumentSettings> documentSettingsRepository, IMapper mapper)
        {
            _documentSettingsRepository = documentSettingsRepository;
        }

        public float GetPrice(CalculatorDocuments model)
        {
            try
            {
                db.Add(model);
                return CalculatePriceDocument();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public float CalculatePriceDocument()
        {

            float result = 0;
            DateTime currentDate = DateTime.Now;
            DateTime nextDay = currentDate.AddDays(1);

            int userCount = 0;
            string userDate = "";
            List<Guid> userSettings = new List<Guid>();

            foreach (var item in db)
            {
                userSettings.Add(item.IdSize);
                userSettings.Add(item.IdMaterial);
                userSettings.Add(item.IdDensity);
                userSettings.Add(item.IdColor);
                userCount = item.Count;
                userDate = item.Deadline;
            }

            foreach (var setting in _documentSettingsRepository.GetAll().ToList())
            {
                foreach(var item in userSettings)
                {
                    if (setting.Id == item) result += setting.Price;
                }
            }

            if (userDate == nextDay.ToString("yyyy-MM-dd")) return (result * userCount) + ((result * userCount) / 2);
            if (userDate == currentDate.ToString("yyyy-MM-dd")) return result * userCount * 2;
            return result * userCount;
        }
    }
}
