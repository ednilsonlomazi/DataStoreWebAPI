using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m073230 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tabItemDocumento_codigoDocumento_codigoItemDocumento_codigoObjeto_codigoPermissao",
                table: "tabItemDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_codigoDocumento_codigoObjeto_codigoPermissao",
                table: "tabItemDocumento",
                columns: new[] { "codigoDocumento", "codigoObjeto", "codigoPermissao" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tabItemDocumento_codigoDocumento_codigoObjeto_codigoPermissao",
                table: "tabItemDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_codigoDocumento_codigoItemDocumento_codigoObjeto_codigoPermissao",
                table: "tabItemDocumento",
                columns: new[] { "codigoDocumento", "codigoItemDocumento", "codigoObjeto", "codigoPermissao" },
                unique: true);
        }
    }
}
