using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace salesOrderApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Customer",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phoneno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Customer", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mastervariant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariantName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VariantType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mastervariant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_productvariant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Isactive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_productvariant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                columns: table => new
                {
                    Roleid = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.Roleid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SalesHeader",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerName = table.Column<string>(name: "Customer Name", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryAddress = table.Column<string>(type: "ntext", nullable: true),
                    Remarks = table.Column<string>(type: "ntext", nullable: true),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Tax = table.Column<decimal>(type: "numeric(18,4)", nullable: true),
                    NetTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SalesHeader", x => x.InvoiceNo);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SalesProductInfo",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    SalesPrice = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SalesProductInfo", x => new { x.InvoiceNo, x.ProductCode });
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    Userid = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.Userid);
                });

            migrationBuilder.CreateTable(
                name: "tbl_product",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_product", x => x.Code);
                    table.ForeignKey(
                        name: "FK_tbl_product_tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tbl_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_CategoryId",
                table: "tbl_product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Customer");

            migrationBuilder.DropTable(
                name: "tbl_mastervariant");

            migrationBuilder.DropTable(
                name: "tbl_product");

            migrationBuilder.DropTable(
                name: "tbl_productvariant");

            migrationBuilder.DropTable(
                name: "tbl_role");

            migrationBuilder.DropTable(
                name: "tbl_SalesHeader");

            migrationBuilder.DropTable(
                name: "tbl_SalesProductInfo");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "tbl_Category");
        }
    }
}
