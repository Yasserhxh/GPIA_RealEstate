using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImmeubleAndProjectsFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Immeubles_ImmeubleId",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ImmeubleFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImmeubleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmeubleFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmeubleFeature_Immeubles_ImmeubleId",
                        column: x => x.ImmeubleId,
                        principalTable: "Immeubles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFeature_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImmeubleFeature_ImmeubleId",
                table: "ImmeubleFeature",
                column: "ImmeubleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFeature_ProjectId",
                table: "ProjectFeature",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Immeubles_ImmeubleId",
                table: "Appointments",
                column: "ImmeubleId",
                principalTable: "Immeubles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Immeubles_ImmeubleId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "ImmeubleFeature");

            migrationBuilder.DropTable(
                name: "ProjectFeature");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Immeubles_ImmeubleId",
                table: "Appointments",
                column: "ImmeubleId",
                principalTable: "Immeubles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
