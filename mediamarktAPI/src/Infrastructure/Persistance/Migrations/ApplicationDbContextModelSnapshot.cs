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

            modelBuilder.Entity("Domain.Planet.Planet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Planets");
                });

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
                });

            modelBuilder.Entity("Domain.Planet.Planet", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Orbit", "Orbit", b1 =>
                        {
                            b1.Property<Guid>("PlanetId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("OrbitalPeriod")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("float")
                                .HasDefaultValue(0.0);

                            b1.Property<double>("OrbitalRadius")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("float")
                                .HasDefaultValue(0.0);

                            b1.Property<double>("RotationPeriod")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("float")
                                .HasDefaultValue(0.0);

                            b1.HasKey("PlanetId");

                            b1.ToTable("Planets");

                            b1.WithOwner()
                                .HasForeignKey("PlanetId");
                        });

                    b.Navigation("Orbit")
                        .IsRequired();
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
