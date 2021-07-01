﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalService.Infrastructure.Data;

namespace RentalService.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210701014002_InitialProductionDb")]
    partial class InitialProductionDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RentalService.AppCore.Core.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("BeginTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("begin_time");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("end_time");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("boolean")
                        .HasColumnName("is_returned");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<decimal>("RentalCost")
                        .HasColumnType("numeric")
                        .HasColumnName("rental_cost");

                    b.Property<DateTime>("ReturnDueTime")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("return_due_time");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_rentals");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_rentals_id");

                    b.ToTable("Rentals", "prod");
                });
#pragma warning restore 612, 618
        }
    }
}