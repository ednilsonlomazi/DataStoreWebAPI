using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m07575 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabObjeto_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto");

            migrationBuilder.DropIndex(
                name: "IX_tabObjeto_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoDocumento",
                table: "tabObjeto");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TabItemDocumentocodigoDocumento",
                table: "tabObjeto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tabObjeto_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" });

            migrationBuilder.AddForeignKey(
                name: "FK_tabObjeto_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" },
                principalTable: "tabItemDocumento",
                principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" });
        }
    }
}
