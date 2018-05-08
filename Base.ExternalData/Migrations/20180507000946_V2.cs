using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Base.ExternalData.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceRange_MaximumPrice",
                table: "Intention",
                newName: "MaximumPrice");

            migrationBuilder.RenameColumn(
                name: "PriceRange_LowestPrice",
                table: "Intention",
                newName: "LowestPrice");

            migrationBuilder.RenameColumn(
                name: "Place_State",
                table: "Intention",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Place_Neighborhood",
                table: "Intention",
                newName: "Neighborhood");

            migrationBuilder.RenameColumn(
                name: "Place_City",
                table: "Intention",
                newName: "City");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumPrice",
                table: "Intention",
                type: "decimal(6, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "LowestPrice",
                table: "Intention",
                type: "decimal(6, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Neighborhood",
                table: "Intention",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Intention",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaximumPrice",
                table: "Intention",
                newName: "PriceRange_MaximumPrice");

            migrationBuilder.RenameColumn(
                name: "LowestPrice",
                table: "Intention",
                newName: "PriceRange_LowestPrice");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Intention",
                newName: "Place_State");

            migrationBuilder.RenameColumn(
                name: "Neighborhood",
                table: "Intention",
                newName: "Place_Neighborhood");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Intention",
                newName: "Place_City");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceRange_MaximumPrice",
                table: "Intention",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceRange_LowestPrice",
                table: "Intention",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Place_Neighborhood",
                table: "Intention",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Place_City",
                table: "Intention",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
