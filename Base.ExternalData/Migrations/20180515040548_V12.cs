using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Base.ExternalData.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_LastName",
                table: "Prospect",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name_FirstName",
                table: "Prospect",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "HomePhone_Number",
                table: "Prospect",
                newName: "HomePhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Email_Address",
                table: "Prospect",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "CellPhone_Number",
                table: "Prospect",
                newName: "CellPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "CellPhone_IsWhatsApp",
                table: "Prospect",
                newName: "CellPhoneIsWhatsApp");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Prospect",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Prospect",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomePhoneNumber",
                table: "Prospect",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Prospect",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CellPhoneNumber",
                table: "Prospect",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Prospect",
                newName: "Name_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Prospect",
                newName: "Name_FirstName");

            migrationBuilder.RenameColumn(
                name: "HomePhoneNumber",
                table: "Prospect",
                newName: "HomePhone_Number");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Prospect",
                newName: "Email_Address");

            migrationBuilder.RenameColumn(
                name: "CellPhoneNumber",
                table: "Prospect",
                newName: "CellPhone_Number");

            migrationBuilder.RenameColumn(
                name: "CellPhoneIsWhatsApp",
                table: "Prospect",
                newName: "CellPhone_IsWhatsApp");

            migrationBuilder.AlterColumn<string>(
                name: "Name_LastName",
                table: "Prospect",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name_FirstName",
                table: "Prospect",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomePhone_Number",
                table: "Prospect",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email_Address",
                table: "Prospect",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CellPhone_Number",
                table: "Prospect",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
