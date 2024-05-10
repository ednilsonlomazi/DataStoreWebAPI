using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabItemDocumento_tabDocumento_IdtabDocumento",
                table: "tabItemDocumento");

            migrationBuilder.DropForeignKey(
                name: "FK_tabObjeto_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_tabPermissao_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabPermissao");

            migrationBuilder.DropIndex(
                name: "IX_tabPermissao_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabPermissao");

            migrationBuilder.DropIndex(
                name: "IX_tabObjeto_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto");

            migrationBuilder.DropIndex(
                name: "IX_tabItemDocumento_IdtabDocumento",
                table: "tabItemDocumento");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoDocumento",
                table: "tabPermissao");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoItemDocumento",
                table: "tabPermissao");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoDocumento",
                table: "tabObjeto");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto");

            migrationBuilder.DropColumn(
                name: "IdtabDocumento",
                table: "tabItemDocumento");

            migrationBuilder.RenameColumn(
                name: "codigoObjeto",
                table: "tabItemDocumento",
                newName: "IdObjeto");

            migrationBuilder.AddColumn<int>(
                name: "IdObjeto",
                table: "tabObjeto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_tabItemDocumento_tabDocumento_codigoDocumento",
                table: "tabItemDocumento",
                column: "codigoDocumento",
                principalTable: "tabDocumento",
                principalColumn: "codigoDocumento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabItemDocumento_tabDocumento_codigoDocumento",
                table: "tabItemDocumento");

            migrationBuilder.DropColumn(
                name: "IdObjeto",
                table: "tabObjeto");

            migrationBuilder.RenameColumn(
                name: "IdObjeto",
                table: "tabItemDocumento",
                newName: "codigoObjeto");

            migrationBuilder.AddColumn<int>(
                name: "TabItemDocumentocodigoDocumento",
                table: "tabPermissao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TabItemDocumentocodigoItemDocumento",
                table: "tabPermissao",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "IdtabDocumento",
                table: "tabItemDocumento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tabPermissao_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabPermissao",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_tabObjeto_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_IdtabDocumento",
                table: "tabItemDocumento",
                column: "IdtabDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_tabItemDocumento_tabDocumento_IdtabDocumento",
                table: "tabItemDocumento",
                column: "IdtabDocumento",
                principalTable: "tabDocumento",
                principalColumn: "codigoDocumento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tabObjeto_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabObjeto",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" },
                principalTable: "tabItemDocumento",
                principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" });

            migrationBuilder.AddForeignKey(
                name: "FK_tabPermissao_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabPermissao",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" },
                principalTable: "tabItemDocumento",
                principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" });
        }
    }
}
