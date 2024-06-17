﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceFlex_Backend.Data;

#nullable disable

namespace PriceFlex_Backend.Migrations
{
    [DbContext(typeof(ScrapperDbContext))]
    [Migration("20240617174013_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PriceFlex_Backend.Models.OnlineShopScrapper", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Classes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OnlineShopScrappers");
                });

            modelBuilder.Entity("PriceFlex_Backend.Models.ScrapperPrice", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OnlineShopScrapperId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("OnlineShopScrapperId");

                    b.HasIndex("UserId");

                    b.ToTable("ScrapperPrices");
                });

            modelBuilder.Entity("PriceFlex_Backend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PriceFlex_Backend.Models.OnlineShopScrapper", b =>
                {
                    b.HasOne("PriceFlex_Backend.Models.User", null)
                        .WithMany("OnlineShopScrappers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PriceFlex_Backend.Models.ScrapperPrice", b =>
                {
                    b.HasOne("PriceFlex_Backend.Models.OnlineShopScrapper", null)
                        .WithMany("Prices")
                        .HasForeignKey("OnlineShopScrapperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PriceFlex_Backend.Models.User", null)
                        .WithMany("ScrapperPrice")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PriceFlex_Backend.Models.OnlineShopScrapper", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("PriceFlex_Backend.Models.User", b =>
                {
                    b.Navigation("OnlineShopScrappers");

                    b.Navigation("ScrapperPrice");
                });
#pragma warning restore 612, 618
        }
    }
}
