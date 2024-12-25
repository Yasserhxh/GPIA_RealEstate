using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class notary_Appointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDelivery_Sale_SaleId",
                table: "PropertyDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDelivery_Units_UnitId",
                table: "PropertyDelivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyDelivery",
                table: "PropertyDelivery");

            migrationBuilder.RenameTable(
                name: "PropertyDelivery",
                newName: "PropertyDeliveries");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDelivery_UnitId",
                table: "PropertyDeliveries",
                newName: "IX_PropertyDeliveries_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDelivery_SaleId",
                table: "PropertyDeliveries",
                newName: "IX_PropertyDeliveries_SaleId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PropertyDeliveries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "PropertyDeliveries",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyDeliveries",
                table: "PropertyDeliveries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaryAppointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaryAppointments", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDeliveries_Sale_SaleId",
                table: "PropertyDeliveries",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDeliveries_Units_UnitId",
                table: "PropertyDeliveries",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDeliveries_Sale_SaleId",
                table: "PropertyDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyDeliveries_Units_UnitId",
                table: "PropertyDeliveries");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "NotaryAppointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyDeliveries",
                table: "PropertyDeliveries");

            migrationBuilder.RenameTable(
                name: "PropertyDeliveries",
                newName: "PropertyDelivery");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDeliveries_UnitId",
                table: "PropertyDelivery",
                newName: "IX_PropertyDelivery_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyDeliveries_SaleId",
                table: "PropertyDelivery",
                newName: "IX_PropertyDelivery_SaleId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PropertyDelivery",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "PropertyDelivery",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyDelivery",
                table: "PropertyDelivery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDelivery_Sale_SaleId",
                table: "PropertyDelivery",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyDelivery_Units_UnitId",
                table: "PropertyDelivery",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
