using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.AppServices.Services
{
    public class CategoryService : ICategoryService
    {
        private List<Category> _db = new List<Category>();

        public bool Add(Category model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                _db.Add(model);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Category> GetCategories()
        {
            return _db;
        }

        public bool Remove(Guid id)
        {
            var category = _db.FirstOrDefault(category => category.Id == id);
            if (category == null) return false;
            _db.Remove(category);
            return true;
        }

        public Category Update(Category model)
        {
            var category = _db.FirstOrDefault(category => category.Id == model.Id);
            if (category == null) return null;
            category.Title = model.Title;
            category.IsAvailable = model.IsAvailable;
            return category;
        }
    }
}
