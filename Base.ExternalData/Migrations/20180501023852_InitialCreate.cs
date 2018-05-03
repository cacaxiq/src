using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Base.ExternalData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prospect",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CellPhone_IsWhatsApp = table.Column<bool>(nullable: false),
                    Email_Address = table.Column<string>(nullable: true),
                    Name_FirstName = table.Column<string>(nullable: true),
                    Name_LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intention",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Bedroom = table.Column<int>(nullable: false),
                    PropertySituation = table.Column<int>(nullable: false),
                    PropertyType = table.Column<int>(nullable: false),
                    ProspectId = table.Column<Guid>(nullable: true),
                    Rent = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    Place_City = table.Column<string>(nullable: true),
                    Place_Neighborhood = table.Column<string>(nullable: true),
                    Place_State = table.Column<int>(nullable: false),
                    PriceRange_LowestPrice = table.Column<decimal>(nullable: false),
                    PriceRange_MaximumPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intention", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intention_Prospect_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intention_ProspectId",
                table: "Intention",
                column: "ProspectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intention");

            migrationBuilder.DropTable(
                name: "Prospect");
        }
    }
}
