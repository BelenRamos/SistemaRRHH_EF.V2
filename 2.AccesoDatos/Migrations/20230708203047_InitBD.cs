using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class InitBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "consultor",
                columns: table => new
                {
                    Legajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOfertaLaboral = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultor", x => x.Legajo);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denominacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "perfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "psicologos",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_psicologos", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "tiposEvaluciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiposEvaluciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entrevistaPerfiles",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfilResultadoId = table.Column<int>(type: "int", nullable: false),
                    perfilResultado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrevistaPerfiles", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_entrevistaPerfiles_perfiles_PerfilResultadoId",
                        column: x => x.PerfilResultadoId,
                        principalTable: "perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entrevistaPerfiles_perfiles_perfilResultado",
                        column: x => x.perfilResultado,
                        principalTable: "perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "turnos",
                columns: table => new
                {
                    Fecha_Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NroEntrevista = table.Column<int>(type: "int", nullable: false),
                    PsicologoEntrevista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    EntrevistaPerfilNumero = table.Column<int>(type: "int", nullable: false),
                    PsicologoMatricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turnos", x => x.Fecha_Horario);
                    table.ForeignKey(
                        name: "FK_turnos_entrevistaPerfiles_EntrevistaPerfilNumero",
                        column: x => x.EntrevistaPerfilNumero,
                        principalTable: "entrevistaPerfiles",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_turnos_psicologos_PsicologoMatricula",
                        column: x => x.PsicologoMatricula,
                        principalTable: "psicologos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOfertaLaboral = table.Column<int>(type: "int", nullable: false),
                    OfertaLaboralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientesTelefonos",
                columns: table => new
                {
                    Telefono = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdOfertaLaboral = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientesTelefonos", x => new { x.Telefono, x.IdCliente });
                    table.ForeignKey(
                        name: "FK_clientesTelefonos_clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_clientesTelefonos_clientes_IdOfertaLaboral",
                        column: x => x.IdOfertaLaboral,
                        principalTable: "clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "evalaciones",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEvaluacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profesional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEvalucionId = table.Column<int>(type: "int", nullable: false),
                    PostulanteNroPostulante = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evalaciones", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_evalaciones_tiposEvaluciones_TipoEvalucionId",
                        column: x => x.TipoEvalucionId,
                        principalTable: "tiposEvaluciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ofertasLaborales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdRequisito = table.Column<int>(type: "int", nullable: false),
                    NroPostulante = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    IdOfertaLaboral = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ofertasLaborales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ofertasLaborales_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ofertasLaborales_consultor_IdOfertaLaboral",
                        column: x => x.IdOfertaLaboral,
                        principalTable: "consultor",
                        principalColumn: "Legajo");
                    table.ForeignKey(
                        name: "FK_ofertasLaborales_estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "estados",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postulantes",
                columns: table => new
                {
                    NroPostulante = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    esCandidato = table.Column<bool>(type: "bit", nullable: false),
                    PerfilAsignado = table.Column<int>(type: "int", nullable: false),
                    NumeroEvalucion = table.Column<int>(type: "int", nullable: false),
                    NumeroEvaluacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postulantes", x => x.NroPostulante);
                    table.ForeignKey(
                        name: "FK_postulantes_evalaciones_NumeroEvaluacion",
                        column: x => x.NumeroEvaluacion,
                        principalTable: "evalaciones",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postulantes_ofertasLaborales_NroPostulante",
                        column: x => x.NroPostulante,
                        principalTable: "ofertasLaborales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postulantes_perfiles_PerfilAsignado",
                        column: x => x.PerfilAsignado,
                        principalTable: "perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requisitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfertaLaboralId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requisitos_ofertasLaborales_OfertaLaboralId",
                        column: x => x.OfertaLaboralId,
                        principalTable: "ofertasLaborales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_clientes_OfertaLaboralId",
                table: "clientes",
                column: "OfertaLaboralId");

            migrationBuilder.CreateIndex(
                name: "IX_clientesTelefonos_IdCliente",
                table: "clientesTelefonos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_clientesTelefonos_IdOfertaLaboral",
                table: "clientesTelefonos",
                column: "IdOfertaLaboral");

            migrationBuilder.CreateIndex(
                name: "IX_entrevistaPerfiles_perfilResultado",
                table: "entrevistaPerfiles",
                column: "perfilResultado");

            migrationBuilder.CreateIndex(
                name: "IX_entrevistaPerfiles_PerfilResultadoId",
                table: "entrevistaPerfiles",
                column: "PerfilResultadoId");

            migrationBuilder.CreateIndex(
                name: "IX_evalaciones_PostulanteNroPostulante",
                table: "evalaciones",
                column: "PostulanteNroPostulante");

            migrationBuilder.CreateIndex(
                name: "IX_evalaciones_TipoEvalucionId",
                table: "evalaciones",
                column: "TipoEvalucionId");

            migrationBuilder.CreateIndex(
                name: "IX_ofertasLaborales_ClienteId",
                table: "ofertasLaborales",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ofertasLaborales_IdEstado",
                table: "ofertasLaborales",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_ofertasLaborales_IdOfertaLaboral",
                table: "ofertasLaborales",
                column: "IdOfertaLaboral");

            migrationBuilder.CreateIndex(
                name: "IX_ofertasLaborales_IdRequisito",
                table: "ofertasLaborales",
                column: "IdRequisito");

            migrationBuilder.CreateIndex(
                name: "IX_postulantes_NumeroEvaluacion",
                table: "postulantes",
                column: "NumeroEvaluacion");

            migrationBuilder.CreateIndex(
                name: "IX_postulantes_PerfilAsignado",
                table: "postulantes",
                column: "PerfilAsignado");

            migrationBuilder.CreateIndex(
                name: "IX_requisitos_OfertaLaboralId",
                table: "requisitos",
                column: "OfertaLaboralId");

            migrationBuilder.CreateIndex(
                name: "IX_turnos_EntrevistaPerfilNumero",
                table: "turnos",
                column: "EntrevistaPerfilNumero");

            migrationBuilder.CreateIndex(
                name: "IX_turnos_PsicologoMatricula",
                table: "turnos",
                column: "PsicologoMatricula");

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_ofertasLaborales_OfertaLaboralId",
                table: "clientes",
                column: "OfertaLaboralId",
                principalTable: "ofertasLaborales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_evalaciones_postulantes_PostulanteNroPostulante",
                table: "evalaciones",
                column: "PostulanteNroPostulante",
                principalTable: "postulantes",
                principalColumn: "NroPostulante");

            migrationBuilder.AddForeignKey(
                name: "FK_ofertasLaborales_requisitos_IdRequisito",
                table: "ofertasLaborales",
                column: "IdRequisito",
                principalTable: "requisitos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientes_ofertasLaborales_OfertaLaboralId",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_postulantes_ofertasLaborales_NroPostulante",
                table: "postulantes");

            migrationBuilder.DropForeignKey(
                name: "FK_requisitos_ofertasLaborales_OfertaLaboralId",
                table: "requisitos");

            migrationBuilder.DropForeignKey(
                name: "FK_postulantes_perfiles_PerfilAsignado",
                table: "postulantes");

            migrationBuilder.DropForeignKey(
                name: "FK_evalaciones_postulantes_PostulanteNroPostulante",
                table: "evalaciones");

            migrationBuilder.DropTable(
                name: "clientesTelefonos");

            migrationBuilder.DropTable(
                name: "turnos");

            migrationBuilder.DropTable(
                name: "entrevistaPerfiles");

            migrationBuilder.DropTable(
                name: "psicologos");

            migrationBuilder.DropTable(
                name: "ofertasLaborales");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "consultor");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "requisitos");

            migrationBuilder.DropTable(
                name: "perfiles");

            migrationBuilder.DropTable(
                name: "postulantes");

            migrationBuilder.DropTable(
                name: "evalaciones");

            migrationBuilder.DropTable(
                name: "tiposEvaluciones");
        }
    }
}
