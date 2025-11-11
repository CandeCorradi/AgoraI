using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FechaInscripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaHora",
                value: new DateTime(2025, 11, 20, 0, 51, 43, 201, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaHora",
                value: new DateTime(2025, 11, 30, 0, 51, 43, 201, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaHora",
                value: new DateTime(2025, 11, 25, 0, 51, 43, 201, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaHora",
                value: new DateTime(2025, 12, 10, 0, 51, 43, 201, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaHora",
                value: new DateTime(2025, 12, 5, 0, 51, 43, 201, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "TipoInscripciones",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nombre",
                value: "Asistente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaHora",
                value: new DateTime(2025, 10, 12, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8731));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaHora",
                value: new DateTime(2025, 10, 22, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaHora",
                value: new DateTime(2025, 10, 17, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8769));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaHora",
                value: new DateTime(2025, 11, 1, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Capacitaciones",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaHora",
                value: new DateTime(2025, 10, 27, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "TipoInscripciones",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nombre",
                value: "Estudiantes");
        }
    }
}
