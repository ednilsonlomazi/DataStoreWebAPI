using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabRelacionaClienteObjetoPermissaos",
                columns: table => new
                {
                    tabClientecodigoCliente = table.Column<int>(type: "int", nullable: false),
                    tabObjetoserverName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tabObjetocodigoBancoDados = table.Column<int>(type: "int", nullable: false),
                    tabObjetocodigoObjeto = table.Column<int>(type: "int", nullable: false),
                    tabPermissaocodigoPermissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tabRelacionaClienteObjetoPermissaos_tabCliente_tabClientecodigoCliente",
                        column: x => x.tabClientecodigoCliente,
                        principalTable: "tabCliente",
                        principalColumn: "codigoCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabRelacionaClienteObjetoPermissaos_tabObjeto_tabObjetoserverName_tabObjetocodigoBancoDados_tabObjetocodigoObjeto",
                        columns: x => new { x.tabObjetoserverName, x.tabObjetocodigoBancoDados, x.tabObjetocodigoObjeto },
                        principalTable: "tabObjeto",
                        principalColumns: new[] { "serverName", "codigoBancoDados", "codigoObjeto" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tabRelacionaClienteObjetoPermissaos_tabPermissao_tabPermissaocodigoPermissao",
                        column: x => x.tabPermissaocodigoPermissao,
                        principalTable: "tabPermissao",
                        principalColumn: "codigoPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabRelacionaClienteObjetoPermissaos_tabClientecodigoCliente",
                table: "tabRelacionaClienteObjetoPermissaos",
                column: "tabClientecodigoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tabRelacionaClienteObjetoPermissaos_tabObjetoserverName_tabObjetocodigoBancoDados_tabObjetocodigoObjeto",
                table: "tabRelacionaClienteObjetoPermissaos",
                columns: new[] { "tabObjetoserverName", "tabObjetocodigoBancoDados", "tabObjetocodigoObjeto" });

            migrationBuilder.CreateIndex(
                name: "IX_tabRelacionaClienteObjetoPermissaos_tabPermissaocodigoPermissao",
                table: "tabRelacionaClienteObjetoPermissaos",
                column: "tabPermissaocodigoPermissao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabRelacionaClienteObjetoPermissaos");
        }
    }
}
