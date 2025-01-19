using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NotaryAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NotaryAppointments");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "NotaryAppointments",
                newName: "ReservationId");

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "NotaryAppointments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerCIN",
                table: "NotaryAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerEmail",
                table: "NotaryAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerFirstName",
                table: "NotaryAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerId",
                table: "NotaryAppointments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerLastName",
                table: "NotaryAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerPhoneNumber",
                table: "NotaryAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectedUserId",
                table: "NotaryAppointments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotaireId",
                table: "NotaryAppointments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PropertyPrice",
                table: "NotaryAppointments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TahfidFees",
                table: "NotaryAppointments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxFees",
                table: "NotaryAppointments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_NotaryAppointments_ReservationId",
                table: "NotaryAppointments",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaryAppointments_Reservations_ReservationId",
                table: "NotaryAppointments",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaryAppointments_Reservations_ReservationId",
                table: "NotaryAppointments");

            migrationBuilder.DropIndex(
                name: "IX_NotaryAppointments_ReservationId",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "BuyerCIN",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "BuyerEmail",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "BuyerFirstName",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "BuyerLastName",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "BuyerPhoneNumber",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "ConnectedUserId",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "NotaireId",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "PropertyPrice",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "TahfidFees",
                table: "NotaryAppointments");

            migrationBuilder.DropColumn(
                name: "TaxFees",
                table: "NotaryAppointments");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "NotaryAppointments",
                newName: "SaleId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NotaryAppointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
