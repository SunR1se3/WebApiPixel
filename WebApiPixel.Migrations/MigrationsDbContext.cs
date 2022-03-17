using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.DataAccess;

namespace WebApiPixel.Migrations
{
    public class MigrationsDbContext : BaseDbContext
    {
        public MigrationsDbContext(DbContextOptions<MigrationsDbContext> options) : base(options)
        {

        }
    }
}
