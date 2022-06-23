﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaDeliveryApi.Data;

#nullable disable

namespace PizzaDeliveryApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Building")
                        .HasColumnType("int");

                    b.Property<int?>("Entrance")
                        .HasColumnType("int");

                    b.Property<int?>("Flat")
                        .HasColumnType("int");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("House")
                        .HasColumnType("int");

                    b.Property<int>("StreetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryEdgeDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderRegistrationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("OrederId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripiton")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Address", b =>
                {
                    b.HasOne("PizzaDeliveryApi.Data.Models.Street", "Street")
                        .WithMany("Addresses")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Order", b =>
                {
                    b.HasOne("PizzaDeliveryApi.Data.Models.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaDeliveryApi.Data.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaDeliveryApi.Data.Models.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaDeliveryApi.Data.Models.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Customer");

                    b.Navigation("PaymentType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.OrderProduct", b =>
                {
                    b.HasOne("PizzaDeliveryApi.Data.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaDeliveryApi.Data.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.PaymentType", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaDeliveryApi.Data.Models.Street", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
