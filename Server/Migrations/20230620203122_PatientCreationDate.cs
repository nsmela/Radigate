using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radigate.Server.Migrations
{
    /// <inheritdoc />
    public partial class PatientCreationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Patients",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Archived", "CreationDate" },
                values: new object[] { false, new DateTime(2023, 6, 20, 13, 31, 22, 317, DateTimeKind.Local).AddTicks(1577) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Archived", "CreationDate" },
                values: new object[] { false, new DateTime(2023, 6, 20, 13, 31, 22, 317, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Archived", "CreationDate" },
                values: new object[] { false, new DateTime(2023, 6, 20, 13, 31, 22, 317, DateTimeKind.Local).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Archived", "CreationDate" },
                values: new object[] { false, new DateTime(2023, 6, 20, 13, 31, 22, 317, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Archived", "CreationDate" },
                values: new object[] { false, new DateTime(2023, 6, 20, 13, 31, 22, 317, DateTimeKind.Local).AddTicks(1627) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Archived", "CreationDate" },
                values: new object[] { false, new DateTime(2023, 6, 20, 13, 31, 22, 317, DateTimeKind.Local).AddTicks(1629) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Archived", "CreationDate" },
                values: new object[] { false, new DateTime(2023, 6, 20, 13, 31, 22, 317, DateTimeKind.Local).AddTicks(1631) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Archived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Archived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Archived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Archived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Archived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6,
                column: "Archived",
                value: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7,
                column: "Archived",
                value: true);
        }
    }
}
