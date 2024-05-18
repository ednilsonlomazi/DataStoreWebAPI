using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m07345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tabObjeto",
                columns: table => new
                {
                    IdObjeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoBancoDados = table.Column<int>(type: "int", nullable: false),
                    codigoObjeto = table.Column<int>(type: "int", nullable: false),
                    codigoSchema = table.Column<int>(type: "int", nullable: false),
                    descricaoTipoObjeto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serverName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatabaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabObjeto", x => x.IdObjeto);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tabDocumento",
                columns: table => new
                {
                    codigoDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    avaliadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isOpen = table.Column<bool>(type: "bit", nullable: false),
                    isCanceled = table.Column<bool>(type: "bit", nullable: false),
                    dataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabDocumento", x => x.codigoDocumento);
                    table.ForeignKey(
                        name: "FK_tabDocumento_AspNetUsers_avaliadorId",
                        column: x => x.avaliadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tabDocumento_AspNetUsers_clienteId",
                        column: x => x.clienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tabAvaliador",
                columns: table => new
                {
                    codigoAvaliador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabAvaliador", x => x.codigoAvaliador);
                    table.ForeignKey(
                        name: "FK_tabAvaliador_tabUsuario_codigoAvaliador",
                        column: x => x.codigoAvaliador,
                        principalTable: "tabUsuario",
                        principalColumn: "codigoUsuario",
                        onDelete: ReferentialAction.Cascade);
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
                name: "tabItemDocumento",
                columns: table => new
                {
                    codigoDocumento = table.Column<int>(type: "int", nullable: false),
                    codigoItemDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoPermissao = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "tabAvaliacao",
                columns: table => new
                {
                    codigoAvaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resultado = table.Column<bool>(type: "bit", nullable: false),
                    justificativa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtaAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TabItemDocumentocodigoDocumento = table.Column<int>(type: "int", nullable: true),
                    TabItemDocumentocodigoItemDocumento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabAvaliacao", x => x.codigoAvaliacao);
                    table.ForeignKey(
                        name: "FK_tabAvaliacao_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                        columns: x => new { x.TabItemDocumentocodigoDocumento, x.TabItemDocumentocodigoItemDocumento },
                        principalTable: "tabItemDocumento",
                        principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" });
                });

            migrationBuilder.CreateTable(
                name: "tabItemDocumentoObjeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tabItemDocumentocodigoDocumento = table.Column<int>(type: "int", nullable: false),
                    tabItemDocumentocodigoItemDocumento = table.Column<int>(type: "int", nullable: false),
                    tabObjetoIdObjeto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabItemDocumentoObjeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tabItemDocumentoObjeto_tabItemDocumento_tabItemDocumentocodigoDocumento_tabItemDocumentocodigoItemDocumento",
                        columns: x => new { x.tabItemDocumentocodigoDocumento, x.tabItemDocumentocodigoItemDocumento },
                        principalTable: "tabItemDocumento",
                        principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabItemDocumentoObjeto_tabObjeto_tabObjetoIdObjeto",
                        column: x => x.tabObjetoIdObjeto,
                        principalTable: "tabObjeto",
                        principalColumn: "IdObjeto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tabItemDocumentoPermissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tabItemDocumentocodigoDocumento = table.Column<int>(type: "int", nullable: false),
                    tabItemDocumentocodigoItemDocumento = table.Column<int>(type: "int", nullable: false),
                    tabPermissaocodigoPermissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabItemDocumentoPermissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tabItemDocumentoPermissao_tabItemDocumento_tabItemDocumentocodigoDocumento_tabItemDocumentocodigoItemDocumento",
                        columns: x => new { x.tabItemDocumentocodigoDocumento, x.tabItemDocumentocodigoItemDocumento },
                        principalTable: "tabItemDocumento",
                        principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabItemDocumentoPermissao_tabPermissao_tabPermissaocodigoPermissao",
                        column: x => x.tabPermissaocodigoPermissao,
                        principalTable: "tabPermissao",
                        principalColumn: "codigoPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tabAvaliacao_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabAvaliacao",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_tabDocumento_avaliadorId",
                table: "tabDocumento",
                column: "avaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_tabDocumento_clienteId",
                table: "tabDocumento",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumentoObjeto_tabItemDocumentocodigoDocumento_tabItemDocumentocodigoItemDocumento",
                table: "tabItemDocumentoObjeto",
                columns: new[] { "tabItemDocumentocodigoDocumento", "tabItemDocumentocodigoItemDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumentoObjeto_tabObjetoIdObjeto",
                table: "tabItemDocumentoObjeto",
                column: "tabObjetoIdObjeto");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumentoPermissao_tabItemDocumentocodigoDocumento_tabItemDocumentocodigoItemDocumento",
                table: "tabItemDocumentoPermissao",
                columns: new[] { "tabItemDocumentocodigoDocumento", "tabItemDocumentocodigoItemDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumentoPermissao_tabPermissaocodigoPermissao",
                table: "tabItemDocumentoPermissao",
                column: "tabPermissaocodigoPermissao");

            migrationBuilder.CreateIndex(
                name: "IX_tabObjeto_serverName_codigoBancoDados_codigoObjeto",
                table: "tabObjeto",
                columns: new[] { "serverName", "codigoBancoDados", "codigoObjeto" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tabAvaliacao");

            migrationBuilder.DropTable(
                name: "tabAvaliador");

            migrationBuilder.DropTable(
                name: "tabCliente");

            migrationBuilder.DropTable(
                name: "tabItemDocumentoObjeto");

            migrationBuilder.DropTable(
                name: "tabItemDocumentoPermissao");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tabUsuario");

            migrationBuilder.DropTable(
                name: "tabObjeto");

            migrationBuilder.DropTable(
                name: "tabItemDocumento");

            migrationBuilder.DropTable(
                name: "tabPermissao");

            migrationBuilder.DropTable(
                name: "tabDocumento");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
