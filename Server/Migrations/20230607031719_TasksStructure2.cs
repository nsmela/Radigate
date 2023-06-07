using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Radigate.Server.Migrations
{
    /// <inheritdoc />
    public partial class TasksStructure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskBool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskBool_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskText_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaskGroups",
                columns: new[] { "Id", "Label", "PatientId" },
                values: new object[,]
                {
                    { 1, "Standard", 1 },
                    { 2, "Standard", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Comments", "Label", "TaskGroupId" },
                values: new object[,]
                {
                    { 1, "", "Approved", 1 },
                    { 2, "", "Assigned RO", 2 }
                });

            migrationBuilder.InsertData(
                table: "TaskBool",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1, false });

            migrationBuilder.InsertData(
                table: "TaskText",
                columns: new[] { "Id", "Value" },
                values: new object[] { 2, "None." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskBool");

            migrationBuilder.DropTable(
                name: "TaskText");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
