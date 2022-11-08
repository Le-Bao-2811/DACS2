using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class thenmcotnuane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pathImgP",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 15, 33, 2, 203, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 15, 33, 2, 203, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 15, 33, 2, 203, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 15, 33, 2, 203, DateTimeKind.Local).AddTicks(6646));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathImgP",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 13, 14, 40, 574, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 13, 14, 40, 574, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 13, 14, 40, 574, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 11, 4, 13, 14, 40, 574, DateTimeKind.Local).AddTicks(1344));
        }
    }
}
