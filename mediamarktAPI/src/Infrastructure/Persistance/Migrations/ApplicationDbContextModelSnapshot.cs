﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductFamilyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductFamilyId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("afdafaf7-a558-4bbb-80dd-acb01442e251"),
                            Description = "LG TV Description",
                            Name = "LG OLED65C35LA, OLED 4K",
                            Price = 1599.0,
                            ProductFamilyId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
                        },
                        new
                        {
                            Id = new Guid("9a798e06-63f7-4443-9377-a261746ecdf8"),
                            Description = "Delonghi Dedica Description",
                            Name = "Delonghi Dedica EC685.BK",
                            Price = 199.99000000000001,
                            ProductFamilyId = new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6")
                        },
                        new
                        {
                            Id = new Guid("05f55fe5-10c2-47f6-b697-894bf97a74d7"),
                            Description = "iPhone 15 Pro Max Description",
                            Name = "iPhone 15 Pro Max",
                            Price = 1449.99,
                            ProductFamilyId = new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6")
                        });
                });

            modelBuilder.Entity("Domain.Products.ProductFamily", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductFamily");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            Name = "Coffe machines"
                        },
                        new
                        {
                            Id = new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            Name = "Smartphones"
                        },
                        new
                        {
                            Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                            Name = "TV"
                        });
                });

            modelBuilder.Entity("Domain.Products.Product", b =>
                {
                    b.HasOne("Domain.Products.ProductFamily", "ProductFamily")
                        .WithMany("Products")
                        .HasForeignKey("ProductFamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductFamily");
                });

            modelBuilder.Entity("Domain.Products.ProductFamily", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
