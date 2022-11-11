using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class themcot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 25, 25, 688, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 25, 25, 688, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 25, 25, 688, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 25, 25, 688, DateTimeKind.Local).AddTicks(5155));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 13, 18, 43, 114, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 13, 18, 43, 114, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 13, 18, 43, 114, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 13, 18, 43, 114, DateTimeKind.Local).AddTicks(2836));
        }
    }
}
