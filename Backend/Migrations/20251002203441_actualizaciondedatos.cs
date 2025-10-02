using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class actualizaciondedatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detalle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ponente = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaHora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    InscripcionAbierta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoInscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInscripciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dni = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposInscripcionesCapacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    TipoInscripcionId = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInscripcionesCapacitaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposInscripcionesCapacitaciones_Capacitaciones_Capacitacion~",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposInscripcionesCapacitaciones_TipoInscripciones_TipoInscr~",
                        column: x => x.TipoInscripcionId,
                        principalTable: "TipoInscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoInscripcionId = table.Column<int>(type: "int", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    Acreditado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Pagado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UsuarioCobroId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_TipoInscripciones_TipoInscripcionId",
                        column: x => x.TipoInscripcionId,
                        principalTable: "TipoInscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_UsuarioCobroId",
                        column: x => x.UsuarioCobroId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Capacitaciones",
                columns: new[] { "Id", "Cupo", "Detalle", "FechaHora", "InscripcionAbierta", "IsDeleted", "Nombre", "Ponente" },
                values: new object[,]
                {
                    { 1, 30, "Aprende los conceptos básicos de programación.", new DateTime(2025, 10, 12, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8731), true, false, "Introducción a la Programación", "Carlos Gómez" },
                    { 2, 25, "Crea aplicaciones web modernas con ASP.NET Core.", new DateTime(2025, 10, 22, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8766), true, false, "Desarrollo Web con ASP.NET Core", "Ana Martínez" },
                    { 3, 20, "Aprende a diseñar y gestionar bases de datos SQL.", new DateTime(2025, 10, 17, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8769), true, false, "Bases de Datos SQL", "Luis Rodríguez" },
                    { 4, 15, "Crea aplicaciones móviles para Android e iOS.", new DateTime(2025, 11, 1, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8772), true, false, "Desarrollo de Aplicaciones Móviles", "Marta Fernández" },
                    { 5, 40, "Protege tus datos y dispositivos con buenas prácticas de ciberseguridad.", new DateTime(2025, 10, 27, 17, 34, 37, 761, DateTimeKind.Local).AddTicks(8776), true, false, "Ciberseguridad Básica", "Javier Sánchez" }
                });

            migrationBuilder.InsertData(
                table: "TipoInscripciones",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Público en general" },
                    { 2, false, "Docentes" },
                    { 3, false, "Estudiantes" },
                    { 4, false, "Jubilados" },
                    { 5, false, "Tecnicos" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "DeleteDate", "Dni", "Email", "IsDeleted", "Nombre", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "Pérez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30111222", "juan.perez@example.com", false, "Juan", 0 },
                    { 2, "Gómez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "28999888", "maria.gomez@example.com", false, "María", 1 },
                    { 3, "Fernández", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32555111", "carlos.fernandez@example.com", false, "Carlos", 2 },
                    { 4, "Martínez", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "33444666", "lucia.martinez@example.com", false, "Lucía", 0 },
                    { 5, "López", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "31222999", "diego.lopez@example.com", false, "Diego", 1 }
                });

            migrationBuilder.InsertData(
                table: "Inscripciones",
                columns: new[] { "Id", "Acreditado", "CapacitacionId", "Importe", "IsDeleted", "Pagado", "TipoInscripcionId", "UsuarioCobroId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, false, 1, 5000m, false, false, 1, 3, 1 },
                    { 2, false, 2, 0m, false, false, 2, null, 2 },
                    { 3, false, 3, 3000m, false, false, 3, 5, 3 },
                    { 4, false, 4, 10000m, false, false, 4, 2, 4 },
                    { 5, false, 5, 0m, false, false, 5, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "TiposInscripcionesCapacitaciones",
                columns: new[] { "Id", "CapacitacionId", "Costo", "IsDeleted", "TipoInscripcionId" },
                values: new object[,]
                {
                    { 1, 1, 10000m, false, 1 },
                    { 2, 1, 5000m, false, 2 },
                    { 3, 1, 3000m, false, 3 },
                    { 4, 1, 2000m, false, 4 },
                    { 5, 2, 12000m, false, 1 },
                    { 6, 2, 6000m, false, 2 },
                    { 7, 2, 4000m, false, 3 },
                    { 8, 2, 3000m, false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_CapacitacionId",
                table: "Inscripciones",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_TipoInscripcionId",
                table: "Inscripciones",
                column: "TipoInscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_UsuarioCobroId",
                table: "Inscripciones",
                column: "UsuarioCobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_UsuarioId",
                table: "Inscripciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposInscripcionesCapacitaciones_CapacitacionId",
                table: "TiposInscripcionesCapacitaciones",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposInscripcionesCapacitaciones_TipoInscripcionId",
                table: "TiposInscripcionesCapacitaciones",
                column: "TipoInscripcionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "TiposInscripcionesCapacitaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Capacitaciones");

            migrationBuilder.DropTable(
                name: "TipoInscripciones");
        }
    }
}
