﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabObjeto",
                columns: table => new
                {
                    codigoBancoDados = table.Column<int>(type: "int", nullable: false),
                    codigoObjeto = table.Column<int>(type: "int", nullable: false),
                    serverName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdObjeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoSchema = table.Column<int>(type: "int", nullable: false),
                    descricaoTipoObjeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatabaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabObjeto", x => new { x.serverName, x.codigoBancoDados, x.codigoObjeto });
                });

            migrationBuilder.CreateTable(
                name: "tabPermissao",
                columns: table => new
                {
                    codigoPermissao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoPermissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classePermissao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabPermissao", x => x.codigoPermissao);
                });

            migrationBuilder.CreateTable(
                name: "tabUsuario",
                columns: table => new
                {
                    codigoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loginName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabUsuario", x => x.codigoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "tabCliente",
                columns: table => new
                {
                    codigoCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabCliente", x => x.codigoCliente);
                    table.ForeignKey(
                        name: "FK_tabCliente_tabUsuario_codigoCliente",
                        column: x => x.codigoCliente,
                        principalTable: "tabUsuario",
                        principalColumn: "codigoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tabEmissors",
                columns: table => new
                {
                    codigoEmissor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabEmissors", x => x.codigoEmissor);
                    table.ForeignKey(
                        name: "FK_tabEmissors_tabUsuario_codigoEmissor",
                        column: x => x.codigoEmissor,
                        principalTable: "tabUsuario",
                        principalColumn: "codigoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tabDocumento",
                columns: table => new
                {
                    codigoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientecodigoCliente = table.Column<int>(type: "int", nullable: false),
                    emissorcodigoEmissor = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "codigoEmissor");
                });

            migrationBuilder.CreateTable(
                name: "tabItemDocumento",
                columns: table => new
                {
                    codigoDocumento = table.Column<int>(type: "int", nullable: false),
                    codigoItemDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objetoserverName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    objetocodigoBancoDados = table.Column<int>(type: "int", nullable: false),
                    objetocodigoObjeto = table.Column<int>(type: "int", nullable: false),
                    permissaocodigoPermissao = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_tabItemDocumento_tabObjeto_objetoserverName_objetocodigoBancoDados_objetocodigoObjeto",
                        columns: x => new { x.objetoserverName, x.objetocodigoBancoDados, x.objetocodigoObjeto },
                        principalTable: "tabObjeto",
                        principalColumns: new[] { "serverName", "codigoBancoDados", "codigoObjeto" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabItemDocumento_tabPermissao_permissaocodigoPermissao",
                        column: x => x.permissaocodigoPermissao,
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
                name: "IX_tabItemDocumento_objetoserverName_objetocodigoBancoDados_objetocodigoObjeto",
                table: "tabItemDocumento",
                columns: new[] { "objetoserverName", "objetocodigoBancoDados", "objetocodigoObjeto" });

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_permissaocodigoPermissao",
                table: "tabItemDocumento",
                column: "permissaocodigoPermissao");
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

            migrationBuilder.DropTable(
                name: "tabUsuario");
        }
    }
}