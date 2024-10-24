﻿// <auto-generated />
using CoreWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreWebApp.Migrations
{
    [DbContext(typeof(ArtistDbContext))]
    [Migration("20241024084009_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreWebApp.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Medium")
                        .HasColumnType("int");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            ArtistName = "Monsur Sarkar",
                            Email = "mansurmdyousuf@gmail.com",
                            Medium = 1
                        },
                        new
                        {
                            ArtistId = 2,
                            ArtistName = "Sonia Akter",
                            Email = "soniaakterdrama@gmail.com",
                            Medium = 3
                        },
                        new
                        {
                            ArtistId = 3,
                            ArtistName = "Hasina Momtaz",
                            Email = "hasinakhanpinky@gmail.com",
                            Medium = 2
                        },
                        new
                        {
                            ArtistId = 4,
                            ArtistName = "Victor Nelembu",
                            Email = "victor@gmail.com",
                            Medium = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
