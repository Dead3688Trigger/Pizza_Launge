﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

#nullable disable

namespace PizzaLaunge.Migrations
{
    [DbContext(typeof(PizzaContext))]
    partial class PizzaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.CUSTOMER", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Order_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Payment_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PaymentID");

                    b.ToTable("CUSTOMERs");
                });

            modelBuilder.Entity("WebApplication1.Models.ORDER", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Order_Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Price")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("ORDERs");
                });

            modelBuilder.Entity("WebApplication1.Models.PAYMENT", b =>
                {
                    b.Property<string>("PaymentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Bill")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Payment_Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentID");

                    b.ToTable("PAYMENTs");
                });

            modelBuilder.Entity("WebApplication1.Models.PIZZA", b =>
                {
                    b.Property<string>("PizzaID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Order_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pizza_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("PizzaID");

                    b.HasIndex("OrderId");

                    b.ToTable("PIZZAs");
                });

            modelBuilder.Entity("WebApplication1.Models.TOPPING", b =>
                {
                    b.Property<string>("ToppingID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PizzaID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Pizza_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topping_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topping_Price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToppingID");

                    b.HasIndex("PizzaID");

                    b.ToTable("TOPPINGS");
                });

            modelBuilder.Entity("WebApplication1.Models.CUSTOMER", b =>
                {
                    b.HasOne("WebApplication1.Models.ORDER", "ORDER")
                        .WithMany("CUSTOMERs")
                        .HasForeignKey("OrderId");

                    b.HasOne("WebApplication1.Models.PAYMENT", "PAYMENT")
                        .WithMany("CUSTOMERs")
                        .HasForeignKey("PaymentID");

                    b.Navigation("ORDER");

                    b.Navigation("PAYMENT");
                });

            modelBuilder.Entity("WebApplication1.Models.PIZZA", b =>
                {
                    b.HasOne("WebApplication1.Models.ORDER", "ORDER")
                        .WithMany("PIZZAs")
                        .HasForeignKey("OrderId");

                    b.Navigation("ORDER");
                });

            modelBuilder.Entity("WebApplication1.Models.TOPPING", b =>
                {
                    b.HasOne("WebApplication1.Models.PIZZA", "PIZZA")
                        .WithMany("TOPPINGS")
                        .HasForeignKey("PizzaID");

                    b.Navigation("PIZZA");
                });

            modelBuilder.Entity("WebApplication1.Models.ORDER", b =>
                {
                    b.Navigation("CUSTOMERs");

                    b.Navigation("PIZZAs");
                });

            modelBuilder.Entity("WebApplication1.Models.PAYMENT", b =>
                {
                    b.Navigation("CUSTOMERs");
                });

            modelBuilder.Entity("WebApplication1.Models.PIZZA", b =>
                {
                    b.Navigation("TOPPINGS");
                });
#pragma warning restore 612, 618
        }
    }
}
