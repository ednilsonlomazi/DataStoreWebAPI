using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m7323011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabAvaliacao_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabAvaliacao");

            migrationBuilder.DropIndex(
                name: "IX_tabAvaliacao_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabAvaliacao");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoDocumento",
                table: "tabAvaliacao");

            migrationBuilder.DropColumn(
                name: "TabItemDocumentocodigoItemDocumento",
                table: "tabAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_tabAvaliacao_codigoDocumento_codigoItemDocumento",
                table: "tabAvaliacao",
                columns: new[] { "codigoDocumento", "codigoItemDocumento" });

            migrationBuilder.AddForeignKey(
                name: "FK_tabAvaliacao_tabItemDocumento_codigoDocumento_codigoItemDocumento",
                table: "tabAvaliacao",
                columns: new[] { "codigoDocumento", "codigoItemDocumento" },
                principalTable: "tabItemDocumento",
                principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabAvaliacao_tabItemDocumento_codigoDocumento_codigoItemDocumento",
                table: "tabAvaliacao");

            migrationBuilder.DropIndex(
                name: "IX_tabAvaliacao_codigoDocumento_codigoItemDocumento",
                table: "tabAvaliacao");

            migrationBuilder.AddColumn<int>(
                name: "TabItemDocumentocodigoDocumento",
                table: "tabAvaliacao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TabItemDocumentocodigoItemDocumento",
                table: "tabAvaliacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tabAvaliacao_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabAvaliacao",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" });

            migrationBuilder.AddForeignKey(
                name: "FK_tabAvaliacao_tabItemDocumento_TabItemDocumentocodigoDocumento_TabItemDocumentocodigoItemDocumento",
                table: "tabAvaliacao",
                columns: new[] { "TabItemDocumentocodigoDocumento", "TabItemDocumentocodigoItemDocumento" },
                principalTable: "tabItemDocumento",
                principalColumns: new[] { "codigoDocumento", "codigoItemDocumento" });
        }
    }
}
