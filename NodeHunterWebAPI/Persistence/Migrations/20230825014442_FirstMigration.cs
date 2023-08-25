using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeHunterWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabCliente",
                columns: table => new
                {
                    codigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoUsuario = table.Column<int>(type: "int", nullable: false),
                    nomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loginName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEmissor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabCliente", x => x.codigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "tabEmissors",
                columns: table => new
                {
                    codigoEmissor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoUsuario = table.Column<int>(type: "int", nullable: false),
                    nomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loginName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isEmissor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabEmissors", x => x.codigoEmissor);
                });

            migrationBuilder.CreateTable(
                name: "tabObjeto",
                columns: table => new
                {
                    codigoObjeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoBancoDados = table.Column<int>(type: "int", nullable: false),
                    codigoSchema = table.Column<int>(type: "int", nullable: false),
                    descricaoTipoObjeto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabObjeto", x => x.codigoObjeto);
                });

            migrationBuilder.CreateTable(
                name: "tabPermissao",
                columns: table => new
                {
                    codigoPermissao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoPermissao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabPermissao", x => x.codigoPermissao);
                });

            migrationBuilder.CreateTable(
                name: "tabDocumento",
                columns: table => new
                {
                    codigoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientecodigoCliente = table.Column<int>(type: "int", nullable: false),
                    emissorcodigoEmissor = table.Column<int>(type: "int", nullable: false),
                    isOpen = table.Column<bool>(type: "bit", nullable: false),
                    isCanceled = table.Column<bool>(type: "bit", nullable: false),
                    dataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabDocumento", x => x.codigoDocumento);
                    table.ForeignKey(
                        name: "FK_tabDocumento_tabCliente_clientecodigoCliente",
                        column: x => x.clientecodigoCliente,
                        principalTable: "tabCliente",
                        principalColumn: "codigoCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabDocumento_tabEmissors_emissorcodigoEmissor",
                        column: x => x.emissorcodigoEmissor,
                        principalTable: "tabEmissors",
                        principalColumn: "codigoEmissor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tabItemDocumento",
                columns: table => new
                {
                    codigoDocumento = table.Column<int>(type: "int", nullable: false),
                    codigoItemDocumento = table.Column<int>(type: "int", nullable: false),
                    tabObjetocodigoObjeto = table.Column<int>(type: "int", nullable: false),
                    tabPermissaocodigoPermissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabItemDocumento", x => new { x.codigoDocumento, x.codigoItemDocumento });
                    table.ForeignKey(
                        name: "FK_tabItemDocumento_tabDocumento_codigoDocumento",
                        column: x => x.codigoDocumento,
                        principalTable: "tabDocumento",
                        principalColumn: "codigoDocumento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabItemDocumento_tabObjeto_tabObjetocodigoObjeto",
                        column: x => x.tabObjetocodigoObjeto,
                        principalTable: "tabObjeto",
                        principalColumn: "codigoObjeto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabItemDocumento_tabPermissao_tabPermissaocodigoPermissao",
                        column: x => x.tabPermissaocodigoPermissao,
                        principalTable: "tabPermissao",
                        principalColumn: "codigoPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabDocumento_clientecodigoCliente",
                table: "tabDocumento",
                column: "clientecodigoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tabDocumento_emissorcodigoEmissor",
                table: "tabDocumento",
                column: "emissorcodigoEmissor");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_tabObjetocodigoObjeto",
                table: "tabItemDocumento",
                column: "tabObjetocodigoObjeto");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_tabPermissaocodigoPermissao",
                table: "tabItemDocumento",
                column: "tabPermissaocodigoPermissao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabItemDocumento");

            migrationBuilder.DropTable(
                name: "tabDocumento");

            migrationBuilder.DropTable(
                name: "tabObjeto");

            migrationBuilder.DropTable(
                name: "tabPermissao");

            migrationBuilder.DropTable(
                name: "tabCliente");

            migrationBuilder.DropTable(
                name: "tabEmissors");
        }
    }
}
