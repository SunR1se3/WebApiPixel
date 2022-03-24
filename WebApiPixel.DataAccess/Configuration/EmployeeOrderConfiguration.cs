using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPixel.Domain.Entities;

namespace WebApiPixel.DataAccess.Configuration
{
    /// <summary>
    /// Конфигурация таблицы БД СотрудникЗаказ
    /// </summary>
    public class EmployeeOrderConfiguration : IEntityTypeConfiguration<EmployeeOrder>
    {
        public void Configure(EntityTypeBuilder<EmployeeOrder> builder)
        {
            builder.ToTable(nameof(EmployeeOrder));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Employee);

            builder.HasOne(x => x.Order);
        }
    }
}
