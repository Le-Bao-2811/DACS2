using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class themcongimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pathImg",
                table: "CategoryProduct",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pathImg",
                table: "CategoryProduct");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 10, 21, 22, 5, 36, 339, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 10, 21, 22, 5, 36, 339, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 10, 21, 22, 5, 36, 339, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 10, 21, 22, 5, 36, 339, DateTimeKind.Local).AddTicks(5583));
        }
    }
}
