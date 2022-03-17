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
    /// Конфигурация таблицы БД категории
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.HasMany(c => c.Wares)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .HasConstraintName("FK_Category_Ware");

            /*builder.HasOne(o => o.Order)
                .WithOne(c => c.Category)
                .HasForeignKey<Order>(c => c.CategoryId)
                .HasConstraintName("FK_Order_Category");*/
        }
    }
}
