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
    [Migration("20211223170555_tag")]
    partial class tag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopApp.Dtos.ShopItemTag", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("ShopItemId")
                        .HasColumnType("int");

                    b.HasKey("TagId", "ShopItemId");

                    b.HasIndex("ShopItemId");

                    b.ToTable("ShopItemTags");
                });

            modelBuilder.Entity("ShopApp.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shop1",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            Name = "Shop2",
                            isDeleted = false
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
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopsItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExpiryDate = new DateTime(2022, 1, 2, 19, 5, 54, 133, DateTimeKind.Local).AddTicks(9889),
                            Name = "ShopItem1",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            ExpiryDate = new DateTime(2022, 4, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8782),
                            Name = "ShopItem2",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            ExpiryDate = new DateTime(2022, 1, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8860),
                            Name = "ShopItem3",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            ExpiryDate = new DateTime(2022, 4, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8872),
                            Name = "ShopItem4",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 5,
                            ExpiryDate = new DateTime(2022, 1, 2, 19, 5, 54, 145, DateTimeKind.Local).AddTicks(8881),
                            Name = "ShopItem5",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("ShopApp.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ShopApp.Dtos.ShopItemTag", b =>
                {
                    b.HasOne("ShopApp.Models.ShopItem", "ShopItem")
                        .WithMany("ShopItemTags")
                        .HasForeignKey("ShopItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopApp.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShopItem");

                    b.Navigation("Tag");
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

            modelBuilder.Entity("ShopApp.Models.ShopItem", b =>
                {
                    b.Navigation("ShopItemTags");
                });
#pragma warning restore 612, 618
        }
    }
}
