using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedLikedProjectsConfigForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedProjects_AspNetUsers_UserId",
                table: "LikedProjects");

            migrationBuilder.DropIndex(
                name: "IX_LikedProjects_UserId",
                table: "LikedProjects");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikedProjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikedProjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_LikedProjects_UserId",
                table: "LikedProjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProjects_AspNetUsers_UserId",
                table: "LikedProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
