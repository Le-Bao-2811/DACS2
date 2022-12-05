using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class nullrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "IdRole",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Color",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2022, 12, 5, 10, 15, 21, 259, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2022, 12, 5, 10, 15, 21, 259, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2022, 12, 5, 10, 15, 21, 259, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2022, 12, 5, 10, 15, 21, 259, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2022, 12, 5, 10, 15, 21, 259, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User",
                column: "IdRole",
                principalTable: "Role",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "IdRole",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Color",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2022, 12, 2, 16, 13, 17, 229, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_IdRole",
                table: "User",
                column: "IdRole",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
