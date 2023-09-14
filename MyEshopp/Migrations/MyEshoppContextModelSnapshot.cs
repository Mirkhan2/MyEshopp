﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEshopp.Data;

namespace MyEshopp.Migrations
{
    [DbContext(typeof(MyEshoppContext))]
    partial class MyEshoppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyEshopp.Models.Catagory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catagories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Asp.Net Core 3",
                            Name = "Asp.Net Core"
                        },
                        new
                        {
                            Id = 2,
                            Description = "گروه لباس ورزشی",
                            Name = "لباس ورزشی"
                        },
                        new
                        {
                            Id = 3,
                            Description = "گروه ساعت مچی",
                            Name = "ساعت مچی"
                        },
                        new
                        {
                            Id = 4,
                            Description = "گروه لوازم منزل",
                            Name = "لوازم منزل"
                        });
                });

            modelBuilder.Entity("MyEshopp.Models.CatagoryToProduct", b =>
                {
                    b.Property<int>("CatagoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CatagoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CatagoryToProducts");

                    b.HasData(
                        new
                        {
                            CatagoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            CatagoryId = 2,
                            ProductId = 1
                        },
                        new
                        {
                            CatagoryId = 3,
                            ProductId = 1
                        },
                        new
                        {
                            CatagoryId = 4,
                            ProductId = 1
                        },
                        new
                        {
                            CatagoryId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            CatagoryId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            CatagoryId = 3,
                            ProductId = 2
                        },
                        new
                        {
                            CatagoryId = 4,
                            ProductId = 2
                        },
                        new
                        {
                            CatagoryId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            CatagoryId = 2,
                            ProductId = 3
                        },
                        new
                        {
                            CatagoryId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            CatagoryId = 4,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("MyEshopp.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 854.0m,
                            QuantityInStock = 5
                        },
                        new
                        {
                            Id = 2,
                            Price = 3302.0m,
                            QuantityInStock = 8
                        },
                        new
                        {
                            Id = 3,
                            Price = 2500m,
                            QuantityInStock = 3
                        });
                });

            modelBuilder.Entity("MyEshopp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinaly")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyEshopp.Models.OrderDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MyEshopp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "آموزش Asp.Net Core 3 پروژه محور ASP.NET Core بر پایه‌ی NET Core.استوار است و نگارشی از NET.محسوب می شود که مستقل از سیستم عامل و بدون واسط برنامه نویسی ویندوز عمل می کند.ویندوز هنوز هم سیستم عاملی برتر به حساب می آید ولی برنامه های وب نه تنها روز به روز از کاربرد و اهمیت بیشتری برخوردار می‌شوند بلکه باید بر روی سکوهای دیگری مانند فضای ابری(Cloud) هم بتوانند میزبانی(Host) شوند، مایکروسافت با معرفی ASP.NET Core گستره کارکرد NET.را افزایش داده است.به این معنی که می‌توان برنامه‌های کاربردی ASP.NET Core را بر روی بازه‌ی گسترده ای از محیط‌های مختلف میزبانی کرد هم‌اکنون می‌توانید پروژه های وب را برای Linux یا macOS هم تولید کنید.",
                            ItemId = 1,
                            Name = "آموزش Asp.Net Core 3 پروژه محور"
                        },
                        new
                        {
                            Id = 2,
                            Description = "در سال های گذشته ، کمپانی مایکروسافت با معرفی تکنولوژی های جدید و حرفه ای در زمینه های مختلف ، عرصه را برای سایر کمپانی ها تنگ تر کرده است. اخیرا این غول فناوری با معرفی فریم ورک های ASP.NET Core و همینطور Blazor قدرت خود در زمینه ی وب را به اثبات رسانده است.",
                            ItemId = 2,
                            Name = "آموزش Blazor از مقدماتی تا پیشرفته"
                        },
                        new
                        {
                            Id = 3,
                            Description = "آموزش اپلیکیشن های وب پیش رونده ( PWA ) آموزش PWA از مقدماتی تا پیشرفته وب اپلیکیشن‌های پیش رونده(PWA) نسل جدید اپلیکیشن‌های تحت وب هستند که می‌توانند آینده‌ی اپلیکیشن‌های موبایل را متحول کنند.در این دوره به طور جامع به بررسی آن‌ها خواهیم پرداخت. مزایا و فاکتور هایی که یک وب اپلیکیشن دارا می باشد به صورت زیر می باشد : ریسپانسیو :  رکن اصلی سایت برای PWA ریسپانسیو بودن اپلیکیشن هستش که برای صفحه نمایش کاربران مختلف موبایل و تبلت خود را وفق دهند.",
                            ItemId = 3,
                            Name = "آموزش اپلیکیشن های وب پیش رونده ( PWA )"
                        });
                });

            modelBuilder.Entity("MyEshopp.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("MyEshopp.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Registerdate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyEshopp.Models.CatagoryToProduct", b =>
                {
                    b.HasOne("MyEshopp.Models.Catagory", "Catagory")
                        .WithMany("CatagoryToProducts")
                        .HasForeignKey("CatagoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEshopp.Models.Product", "Product")
                        .WithMany("CatagoryToProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catagory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyEshopp.Models.Order", b =>
                {
                    b.HasOne("MyEshopp.Models.Users", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MyEshopp.Models.OrderDetail", b =>
                {
                    b.HasOne("MyEshopp.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyEshopp.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyEshopp.Models.Product", b =>
                {
                    b.HasOne("MyEshopp.Models.Item", "Item")
                        .WithOne("Product")
                        .HasForeignKey("MyEshopp.Models.Product", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("MyEshopp.Models.Catagory", b =>
                {
                    b.Navigation("CatagoryToProducts");
                });

            modelBuilder.Entity("MyEshopp.Models.Item", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyEshopp.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MyEshopp.Models.Product", b =>
                {
                    b.Navigation("CatagoryToProducts");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MyEshopp.Models.Users", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
