using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radigate.Server.Migrations.TemplatesData
{
    /// <inheritdoc />
    public partial class InitialTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Tasks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTemplatePatientTemplate",
                columns: table => new
                {
                    GroupTemplatesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientTemplatesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTemplatePatientTemplate", x => new { x.GroupTemplatesId, x.PatientTemplatesId });
                    table.ForeignKey(
                        name: "FK_GroupTemplatePatientTemplate_GroupTemplates_GroupTemplatesId",
                        column: x => x.GroupTemplatesId,
                        principalTable: "GroupTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTemplatePatientTemplate_PatientTemplates_PatientTemplatesId",
                        column: x => x.PatientTemplatesId,
                        principalTable: "PatientTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupTemplatePatientTemplate_PatientTemplatesId",
                table: "GroupTemplatePatientTemplate",
                column: "PatientTemplatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTemplatePatientTemplate");

            migrationBuilder.DropTable(
                name: "GroupTemplates");

            migrationBuilder.DropTable(
                name: "PatientTemplates");
        }
    }
}
