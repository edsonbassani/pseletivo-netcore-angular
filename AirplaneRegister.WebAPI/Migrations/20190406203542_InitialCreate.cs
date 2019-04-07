using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneRegister.WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirplaneTypes",
                columns: table => new
                {
                    AirplaneTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirplaneTypeName = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneTypes", x => x.AirplaneTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AirplaneRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirplaneTypeId = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirplaneRegisters_AirplaneTypes_AirplaneTypeId",
                        column: x => x.AirplaneTypeId,
                        principalTable: "AirplaneTypes",
                        principalColumn: "AirplaneTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirplaneRegisters_AirplaneTypeId",
                table: "AirplaneRegisters",
                column: "AirplaneTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirplaneRegisters");

            migrationBuilder.DropTable(
                name: "AirplaneTypes");
        }
    }
}
