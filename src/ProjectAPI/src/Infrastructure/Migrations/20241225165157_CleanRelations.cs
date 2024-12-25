using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CleanRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_AgentId1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Immeubles_AspNetUsers_AgentId",
                table: "Immeubles");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AgentId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Immeubles_AspNetUsers_AgentId",
                table: "Immeubles",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Immeubles_AspNetUsers_AgentId",
                table: "Immeubles");

            migrationBuilder.AddColumn<string>(
                name: "AgentId1",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AgentId1",
                table: "Appointments",
                column: "AgentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_AgentId1",
                table: "Appointments",
                column: "AgentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Immeubles_AspNetUsers_AgentId",
                table: "Immeubles",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
