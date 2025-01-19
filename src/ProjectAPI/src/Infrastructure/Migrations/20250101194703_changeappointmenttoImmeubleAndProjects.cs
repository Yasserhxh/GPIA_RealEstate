using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeappointmenttoImmeubleAndProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // REMOVE or COMMENT OUT the following if it already exists in DB:
            // migrationBuilder.AddColumn<Guid>(
            //     name: "ImmeubleId",
            //     table: "Appointments",
            //     type: "uniqueidentifier",
            //     nullable: false,
            //     defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            // REMOVE or COMMENT OUT the index creation:
            // migrationBuilder.CreateIndex(
            //     name: "IX_Appointments_ImmeubleId",
            //     table: "Appointments",
            //     column: "ImmeubleId");

            // Keep the foreign key if it doesn’t exist yet:
            // If the FK also already exists in DB, comment that out too.
            /*migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Immeubles_ImmeubleId",
                table: "Appointments",
                column: "ImmeubleId",
                principalTable: "Immeubles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Projects_ProjectId",
                table: "Appointments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Immeubles_ImmeubleId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Projects_ProjectId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ImmeubleId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ImmeubleId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Immeubles_ProjectId",
                table: "Appointments",
                column: "ProjectId",
                principalTable: "Immeubles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
