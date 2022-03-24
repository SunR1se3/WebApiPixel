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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Конфигурация таблицы БД заказ
        /// </summary>
        /// <param name="builder"></param>
        void IEntityTypeConfiguration<Order>.Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            //builder.HasOne(o => o.Category);

            builder.HasOne(o => o.Ware);

            builder.HasOne(o => o.OrderHronology)
            .WithOne(o => o.Order)
            .HasForeignKey<OrderHronology>(o => o.IdOrder)
            .HasConstraintName("FK_Order_OrderHronology");

            builder.HasOne(x => x.EmployeeOrder)
                .WithOne(x => x.Order)
                .HasForeignKey<EmployeeOrder>(o => o.OrderId)
                .HasConstraintName("FK_Order_EmployeeOrder");

        }
    }
}
