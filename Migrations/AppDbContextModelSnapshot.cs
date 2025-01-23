﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaFabriqueaBriques.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.ToTable("Legos");
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

            modelBuilder.Entity("LaFabriqueaBriques.Models.UserLego", b =>
                {
                    b.HasOne("LaFabriqueaBriques.Models.Lego", "Lego")
                        .WithMany("UserLegos")
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

            modelBuilder.Entity("LaFabriqueaBriques.Models.Lego", b =>
                {
                    b.Navigation("UserLegos");
                });

            modelBuilder.Entity("LaFabriqueaBriques.Models.User", b =>
                {
                    b.Navigation("UserLegos");
                });
#pragma warning restore 612, 618
        }
    }
}
