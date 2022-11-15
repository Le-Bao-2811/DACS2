using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class suadulieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 8001);

            migrationBuilder.RenameColumn(
                name: "UseVoucher",
                table: "Invoice",
                newName: "useVoucher");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 8008,
                column: "Desc",
                value: "Xóa sản phẩm");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 11, 15, 13, 24, 41, 677, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 11, 15, 13, 24, 41, 677, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 11, 15, 13, 24, 41, 677, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 11, 15, 13, 24, 41, 677, DateTimeKind.Local).AddTicks(1265));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "useVoucher",
                table: "Invoice",
                newName: "UseVoucher");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 8008,
                column: "Desc",
                value: "Xóa đơn hàng");

            migrationBuilder.InsertData(
                table: "MstPerMission",
                columns: new[] { "Id", "Code", "CreateAt", "CreateBy", "DeleteAt", "Desc", "DetleteBy", "DislayOrder", "GroupName", "Table", "UpdateAt" },
                values: new object[] { 8001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Xem chi tiết danh sách đơn hàng", null, null, "Quản lý giỏ hàng", "InvoiceDetails", null });

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 11, 12, 18, 8, 2, 8, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 11, 12, 18, 8, 2, 8, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 11, 12, 18, 8, 2, 8, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 11, 12, 18, 8, 2, 8, DateTimeKind.Local).AddTicks(8032));
        }
    }
}
