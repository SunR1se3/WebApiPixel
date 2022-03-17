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
    /// Конфигурация таблицы БД товар
    /// </summary>
    public class WareConfiguration : IEntityTypeConfiguration<Ware>
    {
        void IEntityTypeConfiguration<Ware>.Configure(EntityTypeBuilder<Ware> builder)
        {
            builder.ToTable(nameof(Ware));

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id).ValueGeneratedOnAdd();

            builder.HasOne(w => w.Category);

            builder.HasOne(o => o.Order)
                .WithOne(w => w.Ware)
                .HasForeignKey<Order>(o => o.WareId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Order_Ware");
        }
    }
}
