using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class taobang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNewsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstPerMission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstPerMission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pathImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoryNew = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_CategoryNews_IdCategoryNew",
                        column: x => x.IdCategoryNew,
                        principalTable: "CategoryNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MStPermissionId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_MstPerMission_MStPermissionId",
                        column: x => x.MStPermissionId,
                        principalTable: "MstPerMission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportPrice = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProductCategory = table.Column<int>(type: "int", nullable: false),
                    IdSuplier = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CategoryProduct_IdProductCategory",
                        column: x => x.IdProductCategory,
                        principalTable: "CategoryProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_IdSuplier",
                        column: x => x.IdSuplier,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdInvoice = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Designs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => new { x.Id, x.IdInvoice });
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoice_IdInvoice",
                        column: x => x.IdInvoice,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: " Designs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ Designs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ Designs_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Color_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    pathImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => new { x.Id, x.IdProduct });
                    table.ForeignKey(
                        name: "FK_Image_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetleteBy = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DislayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MstPerMission",
                columns: new[] { "Id", "Code", "CreatedDate", "Desc", "GroupName", "Table" },
                values: new object[,]
                {
                    { 1001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách tài khoản", "Quản lý tài khoản", "User" },
                    { 1002, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem tài khoản", "Quản lý tài khoản", "User" },
                    { 1003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm tài khoản", "Quản lý tài khoản", "User" },
                    { 1004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa tài khoản", "Quản lý tài khoản", "User" },
                    { 1005, "UPDATE_PWD", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đổi mật khẩu", "Quản lý tài khoản", "User" },
                    { 1006, "BLOCK", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khóa tài khoản", "Quản lý tài khoản", "User" },
                    { 1007, "UNBLOCK", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mở khóa tài khoản", "Quản lý tài khoản", "User" },
                    { 1008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa tài khoản", "Quản lý tài khoản", "User" },
                    { 1901, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách phản hồi", "Quản lý nhà cung cấp", "Supplier" },
                    { 1902, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem phản hồi", "Quản lý nhà cung cấp", "Supplier" },
                    { 1903, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm phản hồi", "Quản lý nhà cung cấp", "Supplier" },
                    { 1904, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa phản hồi", "Quản lý nhà cung cấp", "Supplier" },
                    { 1908, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa nhà cung cấp", "Quản lý nhà cung cấp", "Supplier" },
                    { 2001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách thể loại tin thức", "Quản lý Thể loại tin tức", "CategoryNews" },
                    { 2003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm thể loại tin thức", "Quản lý Thể loại tin tức", "CategoryNews" },
                    { 2004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa thể loại tin thức", "Quản lý Thể loại tin tức", "CategoryNews" },
                    { 2008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa thể loại tin thức", "Quản lý Thể loại tin tức", "CategoryNews" },
                    { 3001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách thể loại sản phẩm", "Quản lý thể loại sản phẩm", "CategoryProduct" },
                    { 3003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm thể loại sản phẩm", "Quản lý thể loại sản phẩm", "CategoryProduct" },
                    { 3004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa thể loại sản phẩm", "Quản lý thể loại sản phẩm", "CategoryProduct" },
                    { 3008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa thể loại sản phẩm", "Quản lý thể loại sản phẩm", "CategoryProduct" },
                    { 4001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách màu sản phẩm", "Quản lý màu sản phẩm", "Color" },
                    { 4003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm màu sản phẩm", "Quản lý màu sản phẩm", "Color" },
                    { 4004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa màu sản phẩm", "Quản lý màu sản phẩm", "Color" },
                    { 4008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa màu sản phẩm", "Quản lý màu sản phẩm", "Color" },
                    { 5001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách kiểu dáng sản phẩm", "Quản lý kiểu dáng sản phẩm", " Designs" },
                    { 5003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm  kiểu dáng sản phẩm", "Quản lý kiểu dáng sản phẩm", " Designs" },
                    { 5004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa kiểu dáng sản phẩm", "Quản lý kiểu dáng sản phẩm", " Designs" },
                    { 5008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa kiểu dáng sản phẩm", "Quản lý kiểu dáng sản phẩm", " Designs" },
                    { 6001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách hình ảnh sản phẩm", "Quản lý hình sản phẩm", "Image" },
                    { 6003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm  hình ảnh sản phẩm", "Quản lý hình sản phẩm", "Image" },
                    { 6004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa hình ảnh sản phẩm", "Quản lý hình sản phẩm", "Image" },
                    { 6008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa hình ảnh sản phẩm", "Quản lý hình sản phẩm", "Image" },
                    { 7001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách đơn hàng", "Quản lý giỏ hàng", "Invoice" },
                    { 7002, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem  đơn hàng", "Quản lý giỏ hàng", "Invoice" },
                    { 7004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa đơn hàng", "Quản lý giỏ hàng", "Invoice" },
                    { 7008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa đơn hàng", "Quản lý giỏ hàng", "Invoice" },
                    { 8001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem chi tiết danh sách đơn hàng", "Quản lý giỏ hàng", "InvoiceDetails" },
                    { 8008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa đơn hàng", "Quản lý giỏ hàng", "InvoiceDetails" },
                    { 9001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách tin tức", "Quản lý tin tức", "News" },
                    { 9002, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem tin tức", "Quản lý tin tức", "News" },
                    { 9003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm tin tức", "Quản lý tin tức", "News" }
                });

            migrationBuilder.InsertData(
                table: "MstPerMission",
                columns: new[] { "Id", "Code", "CreatedDate", "Desc", "GroupName", "Table" },
                values: new object[,]
                {
                    { 9004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa tin tức", "Quản lý tin tức", "News" },
                    { 9008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa tin tức", "Quản lý tin tức", "News" },
                    { 9101, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách sản phẩm", "Quản lý tin tức", "Product" },
                    { 9102, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem sản phẩm", "Quản lý tin tức", "Product" },
                    { 9103, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm sản phẩm", "Quản lý tin tức", "Product" },
                    { 9104, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa sản phẩm", "Quản lý tin tức", "Product" },
                    { 9108, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa sản phẩm", "Quản lý tin tức", "Product" },
                    { 9201, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách quyền", "Quản lý phân quyền", "Role" },
                    { 9202, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem chi tiết quyền", "Quản lý phân quyền", "Role" },
                    { 9203, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm quyền", "Quản lý phân quyền", "Role" },
                    { 9204, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa quyền", "Quản lý phân quyền", "Role" },
                    { 9208, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa quyền", "Quản lý phân quyền", "Role" },
                    { 9401, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sáchSize", "Quản lý Size", "Size" },
                    { 9402, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem Size", "Quản lý Size", "Size" },
                    { 9403, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm Size", "Quản lý Size", "Size" },
                    { 9404, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa Size", "Quản lý Size", "Size" },
                    { 9408, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa Size", "Quản lý Size", "Size" },
                    { 9501, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách mã", "Quản lý tin tức", "Voucher" },
                    { 9502, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem mã giảm giá", "Quản lý tin tức", "Voucher" },
                    { 9503, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm mã giảm giá", "Quản lý tin tức", "Voucher" },
                    { 9504, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa Mã giảm giá", "Quản lý tin tức", "Voucher" },
                    { 9508, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa mã giảm giá", "Quản lý tin tức", "Voucher" },
                    { 9701, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách chính sách", "Quản lý chính sách", "Policy" },
                    { 9703, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm chính sách", "Quản lý chính sách", "Policy" },
                    { 9704, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa chính sách", "Quản lý chính sách", "Policy" },
                    { 9708, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa chính sách", "Quản lý chính sách", "Policy" },
                    { 9801, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem danh sách nhà cung cấp", "Quản lý nhà cung cấp", "Supplier" },
                    { 9803, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm nhà cung cấp", "Quản lý nhà cung cấp", "Supplier" },
                    { 9804, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa nhà cung cấp", "Quản lý nhà cung cấp", "Supplier" },
                    { 9808, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa nhà cung cấp", "Quản lý nhà cung cấp", "Supplier" },
                    { 9902, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xem thông tin", "Quản lý system", "System" },
                    { 9903, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thêm thông tin web", "Quản lý system", "System" },
                    { 9904, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sửa thông tin", "Quản lý system", "System" },
                    { 9908, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xóa thông tin", "Quản lý system", "System" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreateAt", "CreateBy", "DeleteAt", "DetleteBy", "DislayOrder", "StatusName", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 30, 15, 43, 34, 893, DateTimeKind.Local).AddTicks(9129), null, null, null, null, "Đang chờ xử lý", null },
                    { 2, new DateTime(2022, 9, 30, 15, 43, 34, 893, DateTimeKind.Local).AddTicks(9129), null, null, null, null, "Đang lấy hàng", null },
                    { 3, new DateTime(2022, 9, 30, 15, 43, 34, 893, DateTimeKind.Local).AddTicks(9129), null, null, null, null, "Đang giao hàng", null },
                    { 4, new DateTime(2022, 9, 30, 15, 43, 34, 893, DateTimeKind.Local).AddTicks(9129), null, null, null, null, "Giao hàng thành công", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ Designs_IdProduct",
                table: " Designs",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Color_IdProduct",
                table: "Color",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IdProduct",
                table: "Image",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_StatusId",
                table: "Invoice",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_IdInvoice",
                table: "InvoiceDetails",
                column: "IdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_News_IdCategoryNew",
                table: "News",
                column: "IdCategoryNew");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdProductCategory",
                table: "Product",
                column: "IdProductCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdSuplier",
                table: "Product",
                column: "IdSuplier");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_MStPermissionId",
                table: "RolePermission",
                column: "MStPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_IdProduct",
                table: "Size",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRole",
                table: "User",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " Designs");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "System");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "CategoryNews");

            migrationBuilder.DropTable(
                name: "MstPerMission");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
