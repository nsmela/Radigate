using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radigate.Server.Migrations
{
    /// <inheritdoc />
    public partial class PatientArchived : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "Patients",
                newName: "Archived");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Archived",
                table: "Patients",
                newName: "Visible");
        }
    }
}
