﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiPixel.Migrations;

#nullable disable

namespace WebApiPixel.Migrations.Migrations
{
    [DbContext(typeof(MigrationsDbContext))]
    [Migration("20220526121917_Change_OrderHronology")]
    partial class Change_OrderHronology
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.DocumentSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WareId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WareId");

                    b.ToTable("DocumentSettings");
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.EmployeeOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("EmployeeOrder", (string)null);
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WareId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WareId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.OrderHronology", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAcceptionOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<DateTime>("DateCreationOrder")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdOrder")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Production")
                        .HasColumnType("bit");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder")
                        .IsUnique();

                    b.ToTable("OrderHronology", (string)null);
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Ware", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Ware", (string)null);
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.DocumentSettings", b =>
                {
                    b.HasOne("WebApiPixel.Domain.Entities.Ware", "Ware")
                        .WithMany("DocumentSettings")
                        .HasForeignKey("WareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Ware_DocumentSettings");

                    b.Navigation("Ware");
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.EmployeeOrder", b =>
                {
                    b.HasOne("WebApiPixel.Domain.Entities.Employee", "Employee")
                        .WithOne("EmployeeOrder")
                        .HasForeignKey("WebApiPixel.Domain.Entities.EmployeeOrder", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Employee_EmployeeOrder");

                    b.HasOne("WebApiPixel.Domain.Entities.Order", "Order")
                        .WithOne("EmployeeOrder")
                        .HasForeignKey("WebApiPixel.Domain.Entities.EmployeeOrder", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_EmployeeOrder");

                    b.Navigation("Employee");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Order", b =>
                {
                    b.HasOne("WebApiPixel.Domain.Entities.Ware", "Ware")
                        .WithMany("Orders")
                        .HasForeignKey("WareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_Ware");

                    b.Navigation("Ware");
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.OrderHronology", b =>
                {
                    b.HasOne("WebApiPixel.Domain.Entities.Order", "Order")
                        .WithOne("OrderHronology")
                        .HasForeignKey("WebApiPixel.Domain.Entities.OrderHronology", "IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_OrderHronology");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Ware", b =>
                {
                    b.HasOne("WebApiPixel.Domain.Entities.Category", "Category")
                        .WithMany("Wares")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Category_Ware");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Category", b =>
                {
                    b.Navigation("Wares");
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeOrder")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Order", b =>
                {
                    b.Navigation("EmployeeOrder")
                        .IsRequired();

                    b.Navigation("OrderHronology")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiPixel.Domain.Entities.Ware", b =>
                {
                    b.Navigation("DocumentSettings");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
