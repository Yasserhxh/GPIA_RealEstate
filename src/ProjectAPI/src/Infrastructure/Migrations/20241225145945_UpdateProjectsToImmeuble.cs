using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectsToImmeuble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Project",
                table: "Appointments");

            /*migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Projects",
                table: "Assignments");*/

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Projects",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AgentId",
                table: "Projects");

         /*   migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_AgentId1",
                table: "Projects");*/

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Projects_ProjectId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AgentId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Projects");

           /* migrationBuilder.DropColumn(
                name: "AgentId1",
                table: "Projects");*/

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MaxSellableSurfaceRange",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MinSellableSurfaceRange",
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
                name: "NumberOfUnits",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ResidencyType",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "SellsPercentage",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Projects",
                type: "nvarchar(250)",
                maxLength: 250,
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

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Projects",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Immeubles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResidencyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MinPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Module3DLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfUnits = table.Column<int>(type: "int", nullable: false),
                    NumberOfSoldUnites = table.Column<int>(type: "int", nullable: false),
                    NumberOfAvailableUnites = table.Column<int>(type: "int", nullable: false),
                    SellsPercentage = table.Column<int>(type: "int", nullable: false),
                    MinSellableSurfaceRange = table.Column<int>(type: "int", nullable: false),
                    MaxSellableSurfaceRange = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immeubles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Immeubles_AspNetUsers_AgentId",
                        column: x => x.AgentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Immeubles_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Immeubles_AgentId",
                table: "Immeubles",
                column: "AgentId");

          

            migrationBuilder.CreateIndex(
                name: "IX_Immeubles_ProjectId",
                table: "Immeubles",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Immeubles_ProjectId",
                table: "Appointments",
                column: "ProjectId",
                principalTable: "Immeubles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        /*    migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Immeubles_ProjectId",
                table: "Assignments",
                column: "ProjectId",
                principalTable: "Immeubles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Immeubles_ProjectId",
                table: "Feedbacks",
                column: "ProjectId",
                principalTable: "Immeubles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Immeubles_ProjectId",
                table: "Units",
                column: "ProjectId",
                principalTable: "Immeubles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Immeubles_ProjectId",
                table: "Appointments");

           /* migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Immeubles_ProjectId",
                table: "Assignments");*/

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Immeubles_ProjectId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Immeubles_ProjectId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Immeubles");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Projects",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Images",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

          

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Projects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxPrice",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaxSellableSurfaceRange",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MinPrice",
                table: "Projects",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MinSellableSurfaceRange",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUnits",
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

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Projects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AgentId",
                table: "Projects",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Projects_ProjectId",
                table: "Appointments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Projects_ProjectId",
                table: "Assignments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Projects_ProjectId",
                table: "Feedbacks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");


            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_AgentId",
                table: "Projects",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Projects_ProjectId",
                table: "Units",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
