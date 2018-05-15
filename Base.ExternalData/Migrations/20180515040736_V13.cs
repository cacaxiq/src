using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Base.ExternalData.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intention_Prospect_ProspectId",
                table: "Intention");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prospect",
                table: "Prospect");

            migrationBuilder.DropColumn(
                name: "CellPhoneIsWhatsApp",
                table: "Prospect");

            migrationBuilder.DropColumn(
                name: "CellPhoneNumber",
                table: "Prospect");

            migrationBuilder.DropColumn(
                name: "HomePhoneNumber",
                table: "Prospect");

            migrationBuilder.RenameTable(
                name: "Prospect",
                newName: "User");

            migrationBuilder.AddColumn<string>(
                name: "AccessKey",
                table: "User",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "User",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Prospect",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CellPhoneIsWhatsApp = table.Column<bool>(nullable: false),
                    CellPhoneNumber = table.Column<string>(maxLength: 11, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    HomePhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospect", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Intention_Prospect_ProspectId",
                table: "Intention",
                column: "ProspectId",
                principalTable: "Prospect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intention_Prospect_ProspectId",
                table: "Intention");

            migrationBuilder.DropTable(
                name: "Prospect");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AccessKey",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Prospect");

            migrationBuilder.AddColumn<bool>(
                name: "CellPhoneIsWhatsApp",
                table: "Prospect",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CellPhoneNumber",
                table: "Prospect",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhoneNumber",
                table: "Prospect",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prospect",
                table: "Prospect",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Intention_Prospect_ProspectId",
                table: "Intention",
                column: "ProspectId",
                principalTable: "Prospect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
