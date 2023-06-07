using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Radigate.Server.Migrations
{
    /// <inheritdoc />
    public partial class TaskStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TaskGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskGroups_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    TaskGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskGroups_Id",
                        column: x => x.Id,
                        principalTable: "TaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TPCBool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Check = table.Column<bool>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    TaskGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPCBool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPCBool_TaskGroups_TaskGroupId",
                        column: x => x.TaskGroupId,
                        principalTable: "TaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TPCDouble",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<double>(type: "REAL", nullable: false),
                    TaskGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPCDouble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPCDouble_TaskGroups_TaskGroupId",
                        column: x => x.TaskGroupId,
                        principalTable: "TaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TPCText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    TaskGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPCText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPCText_TaskGroups_TaskGroupId",
                        column: x => x.TaskGroupId,
                        principalTable: "TaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "FirstName", "Identifier", "LastName" },
                values: new object[,]
                {
                    { 1, "Ryan", "", "Stiles" },
                    { 2, "Greg", "", "Proops" },
                    { 3, "Colin", "", "Mocharie" },
                    { 4, "Wayne", "", "Bradey" },
                    { 5, "Aishia", "", "Taylor" },
                    { 6, "Clive", "", "Owen" },
                    { 7, "Drew", "", "Carey" }
                });

            migrationBuilder.InsertData(
                table: "TaskGroups",
                columns: new[] { "Id", "Label", "PatientId" },
                values: new object[,]
                {
                    { 1, "Standard", 1 },
                    { 2, "Standard", 2 },
                    { 3, "Physics Checks", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Comments", "Label", "TaskGroupId", "Type", "Value" },
                values: new object[,]
                {
                    { 1, "", "Approved", 1, 0, "false" },
                    { 2, "", "Physics Approved", 1, 0, "true" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_PatientId",
                table: "TaskGroups",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TPCBool_TaskGroupId",
                table: "TPCBool",
                column: "TaskGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TPCDouble_TaskGroupId",
                table: "TPCDouble",
                column: "TaskGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TPCText_TaskGroupId",
                table: "TPCText",
                column: "TaskGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TPCBool");

            migrationBuilder.DropTable(
                name: "TPCDouble");

            migrationBuilder.DropTable(
                name: "TPCText");

            migrationBuilder.DropTable(
                name: "TaskGroups");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Patients");
        }
    }
}
