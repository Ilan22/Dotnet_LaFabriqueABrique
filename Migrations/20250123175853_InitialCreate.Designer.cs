﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaFabriqueaBriques.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250123175853_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("LaFabriqueaBriques.Models.Lego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("ImageUrls")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NbPiece")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Legos");
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.UserLego", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LegoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "LegoId");

                    b.HasIndex("LegoId");

                    b.ToTable("UserLego");
                });

            modelBuilder.Entity("LegoOrder", b =>
                {
                    b.Property<int>("LegosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LegosId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("LegoOrder");
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.Lego", b =>
                {
                    b.HasOne("LaFabriqueaBriques.Models.User", null)
                        .WithMany("Cart")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.Order", b =>
                {
                    b.HasOne("LaFabriqueaBriques.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.UserLego", b =>
                {
                    b.HasOne("LaFabriqueaBriques.Models.Lego", "Lego")
                        .WithMany()
                        .HasForeignKey("LegoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaFabriqueaBriques.Models.User", "User")
                        .WithMany("UserLegos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lego");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LegoOrder", b =>
                {
                    b.HasOne("LaFabriqueaBriques.Models.Lego", null)
                        .WithMany()
                        .HasForeignKey("LegosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaFabriqueaBriques.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Orders");

                    b.Navigation("UserLegos");
                });
#pragma warning restore 612, 618
        }
    }
}
