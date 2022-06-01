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
    public class OfferMainPageConfiguration : IEntityTypeConfiguration<OfferMainPage>
    {
        public void Configure(EntityTypeBuilder<OfferMainPage> builder)
        {
            builder.ToTable(nameof(OfferMainPage));

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).ValueGeneratedOnAdd();
        }
    }
}
