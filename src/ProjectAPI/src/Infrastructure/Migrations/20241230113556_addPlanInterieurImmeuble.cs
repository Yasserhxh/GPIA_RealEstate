using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPlanInterieurImmeuble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ImmeublePlanInterieurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImmeubleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhotoLinks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmeublePlanInterieurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmeublePlanInterieurs_Immeubles_ImmeubleId",
                        column: x => x.ImmeubleId,
                        principalTable: "Immeubles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImmeublePlanInterieurs_ImmeubleId",
                table: "ImmeublePlanInterieurs",
                column: "ImmeubleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImmeublePlanInterieurs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");
        }
    }
}
