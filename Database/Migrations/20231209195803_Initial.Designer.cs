﻿// <auto-generated />
using System;
using DataManager.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(PaymentContext))]
    [Migration("20231209195803_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataManager.Models.PaymentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Agent")
                        .HasColumnType("int");

                    b.Property<DateTime>("CustomDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PayDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceNo")
                        .HasColumnType("int");

                    b.Property<long>("TransactionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UsedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PaymentItems");
                });
#pragma warning restore 612, 618
        }
    }
}
