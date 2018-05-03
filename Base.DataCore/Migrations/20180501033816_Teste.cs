using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Base.ExternalData.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CellPhone_Number",
                table: "Prospect",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone_Number",
                table: "Prospect",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone_Number",
                table: "Prospect");

            migrationBuilder.DropColumn(
                name: "HomePhone_Number",
                table: "Prospect");
        }
    }
}
