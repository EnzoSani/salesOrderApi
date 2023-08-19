﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using salesOrderApi.DataAccess;

#nullable disable

namespace salesOrderApi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("salesOrderApi.Models.TblCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Category");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblCustomer", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifyUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phoneno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("tbl_Customer");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblMastervariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("VariantName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VariantType")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("tbl_mastervariant");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblProduct", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.HasIndex("CategoryId");

                    b.ToTable("tbl_product");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblProductvariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<bool?>("Isactive")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Remarks")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_productvariant");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblRole", b =>
                {
                    b.Property<string>("Roleid")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Roleid");

                    b.ToTable("tbl_role");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblSalesHeader", b =>
                {
                    b.Property<string>("InvoiceNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Customer Name");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("ntext");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("NetTotal")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<string>("Remarks")
                        .HasColumnType("ntext");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("numeric(18, 4)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("numeric(18, 2)");

                    b.HasKey("InvoiceNo");

                    b.ToTable("tbl_SalesHeader");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblSalesProductInfo", b =>
                {
                    b.Property<string>("InvoiceNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Qty")
                        .HasColumnType("int");

                    b.Property<decimal?>("SalesPrice")
                        .HasColumnType("numeric(18, 3)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("numeric(18, 2)");

                    b.HasKey("InvoiceNo", "ProductCode");

                    b.ToTable("tbl_SalesProductInfo");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblUser", b =>
                {
                    b.Property<string>("Userid")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Userid");

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("salesOrderApi.Models.TblProduct", b =>
                {
                    b.HasOne("salesOrderApi.Models.TblCategory", "Category")
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
