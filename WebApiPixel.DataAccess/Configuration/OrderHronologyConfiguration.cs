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
    /// Конфигурация таблицы БД хронология заказа
    /// </summary>
    public class OrderHronologyConfiguration : IEntityTypeConfiguration<OrderHronology>
    {
        public void Configure(EntityTypeBuilder<OrderHronology> builder)
        {
            builder.ToTable(nameof(OrderHronology));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(o => o.Order);
        }
    }
}
