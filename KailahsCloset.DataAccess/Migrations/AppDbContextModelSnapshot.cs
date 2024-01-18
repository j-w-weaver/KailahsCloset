﻿// <auto-generated />
using KailahsCloset.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KailahsCloset.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KailahsCloset.Models.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            DisplayOrder = 1,
                            Name = "Jacket"
                        },
                        new
                        {
                            CategoryId = 2,
                            DisplayOrder = 2,
                            Name = "Jeans"
                        },
                        new
                        {
                            CategoryId = 3,
                            DisplayOrder = 3,
                            Name = "T-Shirt"
                        },
                        new
                        {
                            CategoryId = 4,
                            DisplayOrder = 4,
                            Name = "Pants"
                        });
                });

            modelBuilder.Entity("KailahsCloset.Models.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Brand = "Nike",
                            CategoryId = 1,
                            Description = "Black Nike zip-Up hoodie",
                            ImageURL = "",
                            Name = "Nike Zip-Up Hoodie",
                            Price = 30.0,
                            Size = "Large"
                        },
                        new
                        {
                            ProductId = 2,
                            Brand = "Levi's",
                            CategoryId = 2,
                            Description = "Dark wash slim-fit jeans for all occasions",
                            ImageURL = "",
                            Name = "Levi's Slim-Fit Jeans",
                            Price = 35.0,
                            Size = "32x32"
                        },
                        new
                        {
                            ProductId = 3,
                            Brand = "Uniqulo",
                            CategoryId = 3,
                            Description = "60% cotton / 40% polyester slim-fit grey tee.",
                            ImageURL = "",
                            Name = "Uniqulo Grey Tee",
                            Price = 12.0,
                            Size = "Large"
                        },
                        new
                        {
                            ProductId = 4,
                            Brand = "ASColour",
                            CategoryId = 3,
                            Description = "65% cotton / 35% polyester slim-fit navy blue tee.",
                            ImageURL = "",
                            Name = "ASColour Navy Blue Tee",
                            Price = 12.0,
                            Size = "Large"
                        },
                        new
                        {
                            ProductId = 5,
                            Brand = "Flag & Anthem",
                            CategoryId = 4,
                            Description = "60% cotton / 40% polyester dark grey chino pants.",
                            ImageURL = "",
                            Name = "Flag & Anthem Oakland Slim Chinos",
                            Price = 38.0,
                            Size = "33x32"
                        });
                });

            modelBuilder.Entity("KailahsCloset.Models.Models.Product", b =>
                {
                    b.HasOne("KailahsCloset.Models.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
