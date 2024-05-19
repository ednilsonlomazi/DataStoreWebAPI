using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m073235 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "codigoObjeto",
                table: "tabItemDocumento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_codigoDocumento_codigoItemDocumento_codigoObjeto_codigoPermissao",
                table: "tabItemDocumento",
                columns: new[] { "codigoDocumento", "codigoItemDocumento", "codigoObjeto", "codigoPermissao" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tabItemDocumento_codigoDocumento_codigoItemDocumento_codigoObjeto_codigoPermissao",
                table: "tabItemDocumento");

            migrationBuilder.DropColumn(
                name: "codigoObjeto",
                table: "tabItemDocumento");
        }
    }
}
