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
    /// Конфигурация таблицы БД сотрудник
    /// </summary>
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));
            
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();


            builder.HasOne(x => x.EmployeeOrder)
            .WithOne(x => x.Employee)
            .HasForeignKey<EmployeeOrder>(e => e.EmployeeId)
            .HasConstraintName("FK_Employee_EmployeeOrder");
        }
    }
}
