using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radigate.Server.Migrations.TemplatesData
{
    /// <inheritdoc />
    public partial class GroupPublicView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "GroupTemplates",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Public",
                table: "GroupTemplates");
        }
    }
}
