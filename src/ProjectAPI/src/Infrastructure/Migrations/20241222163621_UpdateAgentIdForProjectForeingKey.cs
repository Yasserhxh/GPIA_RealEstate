using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgentIdForProjectForeingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceIndicator_AspNetUsers_AgentId1",
                table: "PerformanceIndicator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformanceIndicator",
                table: "PerformanceIndicator");

            migrationBuilder.RenameTable(
                name: "PerformanceIndicator",
                newName: "PerformanceIndicators");

            migrationBuilder.RenameIndex(
                name: "IX_PerformanceIndicator_AgentId1",
                table: "PerformanceIndicators",
                newName: "IX_PerformanceIndicators_AgentId1");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "AgentId1",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "PerformanceIndicators",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformanceIndicators",
                table: "PerformanceIndicators",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AgentId",
                table: "Projects",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AgentId1",
                table: "Appointments",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceIndicators_AgentId",
                table: "PerformanceIndicators",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_AgentId1",
                table: "Appointments",
                column: "AgentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId",
                table: "PerformanceIndicators",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId1",
                table: "PerformanceIndicators",
                column: "AgentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AgentId",
                table: "Projects",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_AgentId1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId",
                table: "PerformanceIndicators");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId1",
                table: "PerformanceIndicators");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AgentId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AgentId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AgentId1",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerformanceIndicators",
                table: "PerformanceIndicators");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceIndicators_AgentId",
                table: "PerformanceIndicators");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "PerformanceIndicators",
                newName: "PerformanceIndicator");

            migrationBuilder.RenameIndex(
                name: "IX_PerformanceIndicators_AgentId1",
                table: "PerformanceIndicator",
                newName: "IX_PerformanceIndicator_AgentId1");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "PerformanceIndicator",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerformanceIndicator",
                table: "PerformanceIndicator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceIndicator_AspNetUsers_AgentId1",
                table: "PerformanceIndicator",
                column: "AgentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
