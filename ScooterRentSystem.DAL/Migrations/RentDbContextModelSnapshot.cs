﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScooterRentSystem.DAL.Data;

namespace ScooterRentSystem.DAL.Migrations
{
    [DbContext(typeof(RentDbContext))]
    partial class RentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GpsPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("ScooterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ScooterId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.Scooter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GpsPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Scooters");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.Person", b =>
                {
                    b.HasOne("ScooterRentSystem.DAL.Entities.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.Rent", b =>
                {
                    b.HasOne("ScooterRentSystem.DAL.Entities.Person", "Person")
                        .WithMany("Rents")
                        .HasForeignKey("PersonId");

                    b.HasOne("ScooterRentSystem.DAL.Entities.Scooter", "Scooter")
                        .WithMany("Rents")
                        .HasForeignKey("ScooterId");

                    b.Navigation("Person");

                    b.Navigation("Scooter");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.Person", b =>
                {
                    b.Navigation("Rents");
                });

            modelBuilder.Entity("ScooterRentSystem.DAL.Entities.Scooter", b =>
                {
                    b.Navigation("Rents");
                });
#pragma warning restore 612, 618
        }
    }
}
