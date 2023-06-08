using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Radigate.Server.Migrations
{
    /// <inheritdoc />
    public partial class TaskSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Label", "PatientId" },
                values: new object[] { "Physics Checks", 1 });

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Label", "PatientId" },
                values: new object[] { "Standard", 2 });

            migrationBuilder.InsertData(
                table: "TaskGroups",
                columns: new[] { "Id", "Label", "PatientId" },
                values: new object[,]
                {
                    { 4, "Physics Checks", 2 },
                    { 5, "Standard", 3 },
                    { 6, "Physics Checks", 3 },
                    { 7, "Standard", 4 },
                    { 8, "Physics Checks", 4 },
                    { 9, "Standard", 5 },
                    { 10, "Physics Checks", 5 },
                    { 11, "Standard", 6 },
                    { 12, "Physics Checks", 6 },
                    { 13, "Standard", 7 },
                    { 14, "Physics Checks", 7 }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Label", "Type", "Value" },
                values: new object[] { "Assigned RO", 1, "No one" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Label", "Type", "Value" },
                values: new object[] { "Approved by RO", 0, "false" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: "2,Waiting,Assigned,Treating,Finished");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Label",
                value: "Assigned Physicist");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Comments", "Label", "TaskGroupId", "Type", "Value" },
                values: new object[,]
                {
                    { 8, "", "Assigned RO", 3, 1, "No one" },
                    { 9, "", "Approved by RO", 3, 0, "false" },
                    { 10, "", "Mass Volume", 3, 2, "150.0" },
                    { 11, "", "Patient Status", 3, 3, "1,Waiting,Assigned,Treating,Finished" },
                    { 12, "", "Approved by RO", 4, 0, "false" },
                    { 13, "", "Assigned Physicist", 4, 1, "No one" },
                    { 14, "", "Mass Volume", 4, 2, "12.55" },
                    { 15, "", "Assigned RO", 5, 1, "No one" },
                    { 16, "", "Approved by RO", 5, 0, "false" },
                    { 17, "", "Mass Volume", 5, 2, "150.0" },
                    { 18, "", "Patient Status", 5, 3, "1,Waiting,Assigned,Treating,Finished" },
                    { 19, "", "Approved by RO", 6, 0, "false" },
                    { 20, "", "Assigned Physicist", 6, 1, "No one" },
                    { 21, "", "Mass Volume", 6, 2, "12.55" },
                    { 22, "", "Assigned RO", 7, 1, "No one" },
                    { 23, "", "Approved by RO", 7, 0, "false" },
                    { 24, "", "Mass Volume", 7, 2, "150.0" },
                    { 25, "", "Patient Status", 7, 3, "2,Waiting,Assigned,Treating,Finished" },
                    { 26, "", "Approved by RO", 8, 0, "false" },
                    { 27, "", "Assigned Physicist", 8, 1, "No one" },
                    { 28, "", "Mass Volume", 8, 2, "12.55" },
                    { 29, "", "Assigned RO", 9, 1, "No one" },
                    { 30, "", "Approved by RO", 9, 0, "false" },
                    { 31, "", "Mass Volume", 9, 2, "150.0" },
                    { 32, "", "Patient Status", 9, 3, "3,Waiting,Assigned,Treating,Finished" },
                    { 33, "", "Approved by RO", 10, 0, "false" },
                    { 34, "", "Assigned Physicist", 10, 1, "No one" },
                    { 35, "", "Mass Volume", 10, 2, "12.55" },
                    { 36, "", "Assigned RO", 11, 1, "No one" },
                    { 37, "", "Approved by RO", 11, 0, "false" },
                    { 38, "", "Mass Volume", 11, 2, "150.0" },
                    { 39, "", "Patient Status", 11, 3, "3,Waiting,Assigned,Treating,Finished" },
                    { 40, "", "Approved by RO", 12, 0, "false" },
                    { 41, "", "Assigned Physicist", 12, 1, "No one" },
                    { 42, "", "Mass Volume", 12, 2, "12.55" },
                    { 43, "", "Assigned RO", 13, 1, "No one" },
                    { 44, "", "Approved by RO", 13, 0, "false" },
                    { 45, "", "Mass Volume", 13, 2, "150.0" },
                    { 46, "", "Patient Status", 13, 3, "2,Waiting,Assigned,Treating,Finished" },
                    { 47, "", "Approved by RO", 14, 0, "false" },
                    { 48, "", "Assigned Physicist", 14, 1, "No one" },
                    { 49, "", "Mass Volume", 14, 2, "1.26" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Label", "PatientId" },
                values: new object[] { "Standard", 2 });

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Label", "PatientId" },
                values: new object[] { "Physics Checks", 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Label", "Type", "Value" },
                values: new object[] { "Approved by RO", 0, "false" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Label", "Type", "Value" },
                values: new object[] { "Assigned RO", 1, "No one" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: "1,Waiting,Assigned,Treating,Finished");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Label",
                value: "Assigned RO");
        }
    }
}
