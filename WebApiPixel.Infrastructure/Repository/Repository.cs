using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiPixel.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        public Repository (DbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public Task Add(TEntity model)
        {
            DbSet.AddAsync(model);
            return SaveChanges();
        }

        public Task<List<TEntity>> GetAll()
        {
            return DbSet.ToListAsync();
        }

        public ValueTask<TEntity> GetById(Guid id)
        {
            return DbSet.FindAsync(id);
        }

        public Task Remove(TEntity model)
        {
            DbSet.Remove(model);
            return SaveChanges();
        }

        public Task SaveChanges()
        {
            return DbContext.SaveChangesAsync();
        }

        public Task Update(TEntity model)
        {
            DbSet.Update(model);
            return SaveChanges();
        }
    }
}
