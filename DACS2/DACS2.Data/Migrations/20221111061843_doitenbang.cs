using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DACS2.Data.Migrations
{
    public partial class doitenbang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ Designs_Product_IdProduct",
                table: " Designs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ Designs",
                table: " Designs");

            migrationBuilder.RenameTable(
                name: " Designs",
                newName: "Designs");

            migrationBuilder.RenameIndex(
                name: "IX_ Designs_IdProduct",
                table: "Designs",
                newName: "IX_Designs_IdProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designs",
                table: "Designs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5001,
                column: "Table",
                value: "Designs");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5003,
                column: "Table",
                value: "Designs");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5004,
                column: "Table",
                value: "Designs");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5008,
                column: "Table",
                value: "Designs");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Designs_Product_IdProduct",
                table: "Designs",
                column: "IdProduct",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designs_Product_IdProduct",
                table: "Designs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Designs",
                table: "Designs");

            migrationBuilder.RenameTable(
                name: "Designs",
                newName: " Designs");

            migrationBuilder.RenameIndex(
                name: "IX_Designs_IdProduct",
                table: " Designs",
                newName: "IX_ Designs_IdProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ Designs",
                table: " Designs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5001,
                column: "Table",
                value: " Designs");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5003,
                column: "Table",
                value: " Designs");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5004,
                column: "Table",
                value: " Designs");

            migrationBuilder.UpdateData(
                table: "MstPerMission",
                keyColumn: "Id",
                keyValue: 5008,
                column: "Table",
                value: " Designs");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ Designs_Product_IdProduct",
                table: " Designs",
                column: "IdProduct",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
