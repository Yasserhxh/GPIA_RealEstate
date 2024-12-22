using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUnitAndProjectEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Units");

            migrationBuilder.AlterColumn<double>(
                name: "TotalSurface",
                table: "Units",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBedrooms",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBathrooms",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "ApartmentSurface",
                table: "Units",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "LatestPrice",
                table: "Units",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceSaleableValue",
                table: "Units",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceSaleableValue1",
                table: "Units",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaleableValue",
                table: "Units",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SaleableValue1",
                table: "Units",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Projects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Projects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Projects",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Images",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AgentId1",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Module3DLink",
                table: "Projects",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAvailableUnites",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSoldUnites",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResidencyType",
                table: "Projects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellsPercentage",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PerformanceIndicator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LeadsGenerated = table.Column<int>(type: "int", nullable: false),
                    AppointmentsScheduled = table.Column<int>(type: "int", nullable: false),
                    SuccessfulSales = table.Column<int>(type: "int", nullable: false),
                    ConversionRate = table.Column<double>(type: "float", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceIndicator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceIndicator_AspNetUsers_AgentId1",
                        column: x => x.AgentId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AgentId1",
                table: "Projects",
                column: "AgentId1");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceIndicator_AgentId1",
                table: "PerformanceIndicator",
                column: "AgentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AgentId1",
                table: "Projects",
                column: "AgentId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AgentId1",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "PerformanceIndicator");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AgentId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LatestPrice",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PriceSaleableValue",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "PriceSaleableValue1",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SaleableValue",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SaleableValue1",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Module3DLink",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NumberOfAvailableUnites",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "NumberOfSoldUnites",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ResidencyType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SellsPercentage",
                table: "Projects");

            migrationBuilder.AlterColumn<double>(
                name: "TotalSurface",
                table: "Units",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBedrooms",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfBathrooms",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ApartmentSurface",
                table: "Units",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Units",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Projects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Images",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
