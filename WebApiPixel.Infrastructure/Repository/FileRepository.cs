using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.Infrastructure.Repository
{
    public class FileRepository : Repository<Files>, IFileRepository
    {
        public FileRepository(DbContext context) : base(context) { }

        public async Task SaveFile(Files file)
        {
            await AddAsync(file);
        }
    }
}
