using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class datathanhcong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 16, 13, 17, 229, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 16, 13, 17, 229, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 16, 13, 17, 229, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 16, 13, 17, 229, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "CreateAt", "CreateBy", "DeleteAt", "DetleteBy", "DislayOrder", "StatusName", "UpdateAt" },
                values: new object[] { 5, new DateTime(2022, 12, 2, 16, 13, 17, 229, DateTimeKind.Local).AddTicks(7497), null, null, null, null, "Giao hàng không thành công", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 11, 24, 58, 901, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 11, 24, 58, 901, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 11, 24, 58, 901, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 11, 24, 58, 901, DateTimeKind.Local).AddTicks(7205));
        }
    }
}
