﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csharp_ecommerce_db;

#nullable disable

namespace csharp_ecommerce_db.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    partial class ECommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("csharp_ecommerce_db.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("OrderId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductOrderQuantityId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductOrderQuantityId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductOrderQuantityId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductOrderQuantityId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("csharp_ecommerce_db.ProductOrderQuantity", b =>
                {
                    b.Property<int>("ProductOrderQuantityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductOrderQuantityId"), 1L, 1);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductOrderQuantityId");

                    b.ToTable("product_order_quantity");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Customer", b =>
                {
                    b.HasOne("csharp_ecommerce_db.Order", "Order")
                        .WithMany("Customers")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Order", b =>
                {
                    b.HasOne("csharp_ecommerce_db.ProductOrderQuantity", null)
                        .WithMany("orders")
                        .HasForeignKey("ProductOrderQuantityId");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Product", b =>
                {
                    b.HasOne("csharp_ecommerce_db.ProductOrderQuantity", null)
                        .WithMany("products")
                        .HasForeignKey("ProductOrderQuantityId");
                });

            modelBuilder.Entity("csharp_ecommerce_db.Order", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("csharp_ecommerce_db.ProductOrderQuantity", b =>
                {
                    b.Navigation("orders");

                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
