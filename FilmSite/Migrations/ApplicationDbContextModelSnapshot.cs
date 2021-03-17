﻿// <auto-generated />
using System;
using FilmSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FilmSite.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("FilmSite.Models.Film", b =>
                {
                    b.Property<int>("FilmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<bool>("currentFilm")
                        .HasColumnType("bit");

                    b.HasKey("FilmID");

                    b.HasIndex("CartID");

                    b.HasIndex("UserID");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("FilmSite.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("customerCartCartID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("customerCartCartID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FilmSite.Models.Film", b =>
                {
                    b.HasOne("FilmSite.Models.Cart", null)
                        .WithMany("Films")
                        .HasForeignKey("CartID");

                    b.HasOne("FilmSite.Models.User", null)
                        .WithMany("purchasedFilms")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("FilmSite.Models.User", b =>
                {
                    b.HasOne("FilmSite.Models.Cart", "customerCart")
                        .WithMany()
                        .HasForeignKey("customerCartCartID");

                    b.Navigation("customerCart");
                });

            modelBuilder.Entity("FilmSite.Models.Cart", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("FilmSite.Models.User", b =>
                {
                    b.Navigation("purchasedFilms");
                });
#pragma warning restore 612, 618
        }
    }
}