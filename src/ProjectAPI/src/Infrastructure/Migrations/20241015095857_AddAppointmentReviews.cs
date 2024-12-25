using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppointmentReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverallRating = table.Column<int>(type: "int", nullable: false),
                    ProfessionalismRating = table.Column<int>(type: "int", nullable: false),
                    CommunicationRating = table.Column<int>(type: "int", nullable: false),
                    PunctualityRating = table.Column<int>(type: "int", nullable: false),
                    PropertyKnowledgeRating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ExperienceFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentReviews_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReviews_AppointmentId",
                table: "AppointmentReviews",
                column: "AppointmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentReviews");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appointments");
        }
    }
}
