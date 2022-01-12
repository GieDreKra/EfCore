﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoomCleanerApp.Data;

#nullable disable

namespace RoomCleanerApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220112113720_RoomCleaner")]
    partial class RoomCleaner
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RoomCleanerApp.Models.Cleaner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cleaners");
                });

            modelBuilder.Entity("RoomCleanerApp.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Perkūno g. 1",
                            City = "Kaunas",
                            TotalRooms = 5
                        },
                        new
                        {
                            Id = 2,
                            Address = "Jonavos g. 1",
                            City = "Kaunas",
                            TotalRooms = 2
                        });
                });

            modelBuilder.Entity("RoomCleanerApp.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Booked")
                        .HasColumnType("bit");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RoomCleanerApp.Models.RoomCleaner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Cleaned")
                        .HasColumnType("bit");

                    b.Property<int>("CleanerId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CleanerId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomCleaner");
                });

            modelBuilder.Entity("RoomCleanerApp.Models.Room", b =>
                {
                    b.HasOne("RoomCleanerApp.Models.Hotel", null)
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoomCleanerApp.Models.RoomCleaner", b =>
                {
                    b.HasOne("RoomCleanerApp.Models.Cleaner", "Cleaner")
                        .WithMany("RoomCleaners")
                        .HasForeignKey("CleanerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoomCleanerApp.Models.Room", "Room")
                        .WithMany("RoomCleaners")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cleaner");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RoomCleanerApp.Models.Cleaner", b =>
                {
                    b.Navigation("RoomCleaners");
                });

            modelBuilder.Entity("RoomCleanerApp.Models.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("RoomCleanerApp.Models.Room", b =>
                {
                    b.Navigation("RoomCleaners");
                });
#pragma warning restore 612, 618
        }
    }
}
