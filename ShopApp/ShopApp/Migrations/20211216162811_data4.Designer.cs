﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopApp.Data;

namespace ShopApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211216162811_data4")]
    partial class data4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopApp.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shop1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shop2"
                        });
                });

            modelBuilder.Entity("ShopApp.Models.ShopItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopsItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExpiryDate = new DateTime(2021, 12, 26, 18, 28, 10, 946, DateTimeKind.Local).AddTicks(8852),
                            Name = "ShopItem1"
                        },
                        new
                        {
                            Id = 2,
                            ExpiryDate = new DateTime(2022, 3, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(902),
                            Name = "ShopItem2"
                        },
                        new
                        {
                            Id = 3,
                            ExpiryDate = new DateTime(2021, 12, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(947),
                            Name = "ShopItem3"
                        },
                        new
                        {
                            Id = 4,
                            ExpiryDate = new DateTime(2022, 3, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(954),
                            Name = "ShopItem4"
                        },
                        new
                        {
                            Id = 5,
                            ExpiryDate = new DateTime(2021, 12, 26, 18, 28, 10, 950, DateTimeKind.Local).AddTicks(959),
                            Name = "ShopItem5"
                        });
                });

            modelBuilder.Entity("ShopApp.Models.ShopItem", b =>
                {
                    b.HasOne("ShopApp.Models.Shop", "Shop")
                        .WithMany("Items")
                        .HasForeignKey("ShopId");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("ShopApp.Models.Shop", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}