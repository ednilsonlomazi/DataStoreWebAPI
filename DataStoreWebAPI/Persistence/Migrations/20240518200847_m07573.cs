using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m07573 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigoItemDocumento",
                table: "tabItemDocumentoPermissao");

            migrationBuilder.DropColumn(
                name: "codigoPermissao",
                table: "tabItemDocumentoPermissao");

            migrationBuilder.CreateTable(
                name: "tabItemDocumentoObjeto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tabItemDocumentocodigoDocumento = table.Column<int>(type: "int", nullable: false),
                    tabItemDocumentocodigoItemDocumento = table.Column<int>(type: "int", nullable: false),
                    tabObjetoserverName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tabObjetocodigoBancoDados = table.Column<int>(type: "int", nullable: false),
                    tabObjetocodigoObjeto = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_tabItemDocumentoObjeto_tabObjeto_tabObjetoserverName_tabObjetocodigoBancoDados_tabObjetocodigoObjeto",
                        columns: x => new { x.tabObjetoserverName, x.tabObjetocodigoBancoDados, x.tabObjetocodigoObjeto },
                        principalTable: "tabObjeto",
                        principalColumns: new[] { "serverName", "codigoBancoDados", "codigoObjeto" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumentoObjeto_tabItemDocumentocodigoDocumento_tabItemDocumentocodigoItemDocumento",
                table: "tabItemDocumentoObjeto",
                columns: new[] { "tabItemDocumentocodigoDocumento", "tabItemDocumentocodigoItemDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumentoObjeto_tabObjetoserverName_tabObjetocodigoBancoDados_tabObjetocodigoObjeto",
                table: "tabItemDocumentoObjeto",
                columns: new[] { "tabObjetoserverName", "tabObjetocodigoBancoDados", "tabObjetocodigoObjeto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabItemDocumentoObjeto");

            migrationBuilder.AddColumn<int>(
                name: "codigoItemDocumento",
                table: "tabItemDocumentoPermissao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "codigoPermissao",
                table: "tabItemDocumentoPermissao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
