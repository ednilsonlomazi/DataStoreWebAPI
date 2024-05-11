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
            migrationBuilder.RenameColumn(
                name: "codigoPermissao",
                table: "tabItemDocumento",
                newName: "permissaocodigoPermissao");

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_permissaocodigoPermissao",
                table: "tabItemDocumento",
                column: "permissaocodigoPermissao");

            migrationBuilder.AddForeignKey(
                name: "FK_tabItemDocumento_tabPermissao_permissaocodigoPermissao",
                table: "tabItemDocumento",
                column: "permissaocodigoPermissao",
                principalTable: "tabPermissao",
                principalColumn: "codigoPermissao",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabItemDocumento_tabPermissao_permissaocodigoPermissao",
                table: "tabItemDocumento");

            migrationBuilder.DropIndex(
                name: "IX_tabItemDocumento_permissaocodigoPermissao",
                table: "tabItemDocumento");

            migrationBuilder.RenameColumn(
                name: "permissaocodigoPermissao",
                table: "tabItemDocumento",
                newName: "codigoPermissao");
        }
    }
}
