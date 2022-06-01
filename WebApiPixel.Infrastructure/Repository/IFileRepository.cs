using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.Infrastructure.Repository
{
    public interface IFileRepository
    {
        Task SaveFile(Files file);
    }
}
