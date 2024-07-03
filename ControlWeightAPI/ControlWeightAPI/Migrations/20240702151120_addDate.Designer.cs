﻿// <auto-generated />
using System;
using ControlWeightAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControlWeightAPI.Migrations
{
    [DbContext(typeof(ControlWeightDbContext))]
    [Migration("20240702151120_addDate")]
    partial class addDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControlWeightAPI.Entities.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Arm")
                        .HasColumnType("float");

                    b.Property<double>("Chest")
                        .HasColumnType("float");

                    b.Property<double>("Hips")
                        .HasColumnType("float");

                    b.Property<DateTime>("MeasureDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Thigh")
                        .HasColumnType("float");

                    b.Property<double>("Waist")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Measures");
                });
#pragma warning restore 612, 618
        }
    }
}