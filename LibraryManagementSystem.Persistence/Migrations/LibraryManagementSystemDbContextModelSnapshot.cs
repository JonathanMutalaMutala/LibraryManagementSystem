﻿// <auto-generated />
using LibraryManagementSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.Persistence.Migrations
{
    [DbContext(typeof(LibraryManagementSystemDbContext))]
    partial class LibraryManagementSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagementSystem.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Chinua Achebe",
                            ISBN = 1222303444L,
                            IsActive = true,
                            Title = "Things Fall Apart"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Christian Andersen",
                            ISBN = 599998774412L,
                            IsActive = true,
                            Title = "Fairy tales"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Unknown",
                            ISBN = 599998774412L,
                            IsActive = true,
                            Title = "The Epic Of Gilgamesh"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}