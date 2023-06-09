using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radigate.Server.Migrations
{
    /// <inheritdoc />
    public partial class SortingOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortingOrder",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortingOrder",
                table: "TaskGroups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 5,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 6,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 7,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 8,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 9,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 10,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 11,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 12,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 13,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskGroups",
                keyColumn: "Id",
                keyValue: 14,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "SortingOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "SortingOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "SortingOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 33,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 34,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 35,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 36,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 37,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 38,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 39,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 40,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 41,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 42,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 43,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 44,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 45,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 46,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 47,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 48,
                column: "SortingOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 49,
                column: "SortingOrder",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortingOrder",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SortingOrder",
                table: "TaskGroups");
        }
    }
}
