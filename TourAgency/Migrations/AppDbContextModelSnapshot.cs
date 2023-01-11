﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourAgency.Data;

#nullable disable

namespace TourAgency.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TourAgency.Models.About", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("abouts");
                });

            modelBuilder.Entity("TourAgency.Models.Aircompany", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("airportid")
                        .HasColumnType("int");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ticketTypeid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("airportid");

                    b.HasIndex("ticketTypeid");

                    b.ToTable("aircompanies");
                });

            modelBuilder.Entity("TourAgency.Models.Airport", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cityid")
                        .HasColumnType("int");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("cityid");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("TourAgency.Models.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("countryid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("countryid");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("TourAgency.Models.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TourAgency.Models.HolidayType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("HolidayTypes");
                });

            modelBuilder.Entity("TourAgency.Models.Hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("qualityid")
                        .HasColumnType("int");

                    b.Property<bool>("recomended")
                        .HasColumnType("bit");

                    b.Property<int>("regionid")
                        .HasColumnType("int");

                    b.Property<int?>("roomServiceid")
                        .HasColumnType("int");

                    b.Property<int?>("roomid")
                        .HasColumnType("int");

                    b.Property<int?>("transferid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("qualityid");

                    b.HasIndex("regionid");

                    b.HasIndex("roomServiceid");

                    b.HasIndex("roomid");

                    b.HasIndex("transferid");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TourAgency.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TourAgency.Models.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("orderID")
                        .HasColumnType("int");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("ProductID");

                    b.HasIndex("orderID");

                    b.ToTable("orderDetails");
                });

            modelBuilder.Entity("TourAgency.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("aboutid")
                        .HasColumnType("int");

                    b.Property<decimal>("duration")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("holidayTypeid")
                        .HasColumnType("int");

                    b.Property<int>("hotelid")
                        .HasColumnType("int");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.Property<int>("tripid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("aboutid");

                    b.HasIndex("holidayTypeid");

                    b.HasIndex("hotelid");

                    b.HasIndex("tripid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TourAgency.Models.Quality", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("super")
                        .HasColumnType("bit");

                    b.Property<int>("value")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Qualities");
                });

            modelBuilder.Entity("TourAgency.Models.Region", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("countryid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("countryid");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("TourAgency.Models.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TourAgency.Models.RoomService", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("roomServices");
                });

            modelBuilder.Entity("TourAgency.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ShopCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productid");

                    b.ToTable("shopCartItems");
                });

            modelBuilder.Entity("TourAgency.Models.TicketType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ticketTypes");
                });

            modelBuilder.Entity("TourAgency.Models.Transfer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("TourAgency.Models.Trip", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("aircompanyid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("aircompanyid");

                    b.ToTable("trips");
                });

            modelBuilder.Entity("TourAgency.Models.Aircompany", b =>
                {
                    b.HasOne("TourAgency.Models.Airport", "airport")
                        .WithMany()
                        .HasForeignKey("airportid");

                    b.HasOne("TourAgency.Models.TicketType", "ticketType")
                        .WithMany()
                        .HasForeignKey("ticketTypeid");

                    b.Navigation("airport");

                    b.Navigation("ticketType");
                });

            modelBuilder.Entity("TourAgency.Models.Airport", b =>
                {
                    b.HasOne("TourAgency.Models.City", "city")
                        .WithMany()
                        .HasForeignKey("cityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("TourAgency.Models.City", b =>
                {
                    b.HasOne("TourAgency.Models.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("TourAgency.Models.Hotel", b =>
                {
                    b.HasOne("TourAgency.Models.Quality", "quality")
                        .WithMany()
                        .HasForeignKey("qualityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency.Models.RoomService", "roomService")
                        .WithMany()
                        .HasForeignKey("roomServiceid");

                    b.HasOne("TourAgency.Models.Room", "room")
                        .WithMany()
                        .HasForeignKey("roomid");

                    b.HasOne("TourAgency.Models.Transfer", "transfer")
                        .WithMany()
                        .HasForeignKey("transferid");

                    b.Navigation("quality");

                    b.Navigation("region");

                    b.Navigation("room");

                    b.Navigation("roomService");

                    b.Navigation("transfer");
                });

            modelBuilder.Entity("TourAgency.Models.OrderDetail", b =>
                {
                    b.HasOne("TourAgency.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency.Models.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("TourAgency.Models.Product", b =>
                {
                    b.HasOne("TourAgency.Models.About", "about")
                        .WithMany()
                        .HasForeignKey("aboutid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency.Models.HolidayType", "holidayType")
                        .WithMany()
                        .HasForeignKey("holidayTypeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency.Models.Hotel", "hotel")
                        .WithMany()
                        .HasForeignKey("hotelid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourAgency.Models.Trip", "trip")
                        .WithMany()
                        .HasForeignKey("tripid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("about");

                    b.Navigation("holidayType");

                    b.Navigation("hotel");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("TourAgency.Models.Region", b =>
                {
                    b.HasOne("TourAgency.Models.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("TourAgency.Models.ShopCartItem", b =>
                {
                    b.HasOne("TourAgency.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("TourAgency.Models.Trip", b =>
                {
                    b.HasOne("TourAgency.Models.Aircompany", "aircompany")
                        .WithMany()
                        .HasForeignKey("aircompanyid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aircompany");
                });

            modelBuilder.Entity("TourAgency.Models.Order", b =>
                {
                    b.Navigation("orderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
