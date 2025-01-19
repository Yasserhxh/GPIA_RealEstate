using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class perfomanceIndicatorReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId",
                table: "PerformanceIndicators");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId1",
                table: "PerformanceIndicators");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceIndicators_AgentId1",
                table: "PerformanceIndicators");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "PerformanceIndicators");

            migrationBuilder.DropColumn(
                name: "ConversionRate",
                table: "PerformanceIndicators");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "PerformanceIndicators",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ImmeubleTracking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImmeubleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusUpdate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmeubleTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmeubleTracking_Immeubles_ImmeubleId",
                        column: x => x.ImmeubleId,
                        principalTable: "Immeubles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPropertyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUnderConstruction = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitTracking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentPhase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgressDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitTracking_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImmeubleTracking_ImmeubleId",
                table: "ImmeubleTracking",
                column: "ImmeubleId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ProjectId",
                table: "Leads",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UnitId",
                table: "Reservations",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitTracking_UnitId",
                table: "UnitTracking",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId",
                table: "PerformanceIndicators",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceIndicators_AspNetUsers_AgentId",
                table: "PerformanceIndicators");

            migrationBuilder.DropTable(
                name: "ImmeubleTracking");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "UnitTracking");

            migrationBuilder.AlterColumn<string>(
                name: "AgentId",
                table: "PerformanceIndicators",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentId1",
                table: "PerformanceIndicators",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ConversionRate",
                table: "PerformanceIndicators",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceIndicators_AgentId1",
                table: "PerformanceIndicators",
                column: "AgentId1");

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
        }
    }
}
