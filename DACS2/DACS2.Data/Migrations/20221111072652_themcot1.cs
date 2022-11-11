using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class themcot1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberPhone",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 26, 51, 744, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 26, 51, 744, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 26, 51, 744, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 11, 11, 14, 26, 51, 744, DateTimeKind.Local).AddTicks(8569));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberPhone",
                table: "Invoice");

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
    }
}
