using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class bangcatenews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductNewsName",
                table: "CategoryNews",
                newName: "NewsName");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 10, 14, 0, 43, 4, 527, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 10, 14, 0, 43, 4, 527, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 10, 14, 0, 43, 4, 527, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 10, 14, 0, 43, 4, 527, DateTimeKind.Local).AddTicks(765));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewsName",
                table: "CategoryNews",
                newName: "ProductNewsName");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 10, 7, 11, 57, 53, 503, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 10, 7, 11, 57, 53, 503, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 10, 7, 11, 57, 53, 503, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 10, 7, 11, 57, 53, 503, DateTimeKind.Local).AddTicks(7004));
        }
    }
}
