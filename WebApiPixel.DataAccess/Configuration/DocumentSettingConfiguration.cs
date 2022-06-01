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
    /// Конфигурация таблицы БД параметров товара тиражирования
    /// </summary>
    public class DocumentSettingConfiguration : IEntityTypeConfiguration<DocumentSettings>
    {
        public void Configure(EntityTypeBuilder<DocumentSettings> builder)
        {
            builder.ToTable(nameof(DocumentSettings));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(w => w.Ware);
        }
    }
}
