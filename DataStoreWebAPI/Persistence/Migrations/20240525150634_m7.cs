using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
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
                name: "tabStatusDocumentos",
                columns: table => new
                {
                    codigoStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    indAtivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabStatusDocumentos", x => x.codigoStatus);
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
                    idCliente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idAvaliador = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    codigoStatusDocumento = table.Column<int>(type: "int", nullable: false),
                    dataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabDocumento", x => x.codigoDocumento);
                    table.ForeignKey(
                        name: "FK_tabDocumento_AspNetUsers_idAvaliador",
                        column: x => x.idAvaliador,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tabDocumento_AspNetUsers_idCliente",
                        column: x => x.idCliente,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tabDocumento_tabStatusDocumentos_codigoStatusDocumento",
                        column: x => x.codigoStatusDocumento,
                        principalTable: "tabStatusDocumentos",
                        principalColumn: "codigoStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tabItemDocumento",
                columns: table => new
                {
                    codigoDocumento = table.Column<int>(type: "int", nullable: false),
                    codigoItemDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoPermissao = table.Column<int>(type: "int", nullable: false),
                    codigoObjeto = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_tabItemDocumento_tabObjeto_codigoObjeto",
                        column: x => x.codigoObjeto,
                        principalTable: "tabObjeto",
                        principalColumn: "IdObjeto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabItemDocumento_tabPermissao_codigoPermissao",
                        column: x => x.codigoPermissao,
                        principalTable: "tabPermissao",
                        principalColumn: "codigoPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tabAvaliacao",
                columns: table => new
                {
                    codigoAvaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoItemDocumento = table.Column<int>(type: "int", nullable: false),
                    codigoDocumento = table.Column<int>(type: "int", nullable: false),
                    resultado = table.Column<bool>(type: "bit", nullable: false),
                    justificativa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtaAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabAvaliacao", x => x.codigoAvaliacao);
                    table.ForeignKey(
                        name: "FK_tabAvaliacao_tabItemDocumento_codigoDocumento_codigoItemDocumento",
                        columns: x => new { x.codigoDocumento, x.codigoItemDocumento },
                        principalTable: "tabItemDocumento",
                        principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" },
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
                name: "IX_tabAvaliacao_codigoDocumento_codigoItemDocumento",
                table: "tabAvaliacao",
                columns: new[] { "codigoDocumento", "codigoItemDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_tabDocumento_codigoStatusDocumento",
                table: "tabDocumento",
                column: "codigoStatusDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_tabDocumento_idAvaliador",
                table: "tabDocumento",
                column: "idAvaliador");

            migrationBuilder.CreateIndex(
                name: "IX_tabDocumento_idCliente",
                table: "tabDocumento",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_codigoDocumento_codigoObjeto_codigoPermissao",
                table: "tabItemDocumento",
                columns: new[] { "codigoDocumento", "codigoObjeto", "codigoPermissao" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_codigoObjeto",
                table: "tabItemDocumento",
                column: "codigoObjeto");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_codigoPermissao",
                table: "tabItemDocumento",
                column: "codigoPermissao");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tabItemDocumento");

            migrationBuilder.DropTable(
                name: "tabDocumento");

            migrationBuilder.DropTable(
                name: "tabObjeto");

            migrationBuilder.DropTable(
                name: "tabPermissao");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tabStatusDocumentos");
        }
    }
}
