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
                name: "FK_TabAvaliacao_tabEmissors_emissorcodigoEmissor",
                table: "TabAvaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_tabItemDocumento_TabAvaliacao_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TabAvaliacao",
                table: "TabAvaliacao");

            migrationBuilder.DropIndex(
                name: "IX_TabAvaliacao_emissorcodigoEmissor",
                table: "TabAvaliacao");

            migrationBuilder.DropColumn(
                name: "emissorcodigoEmissor",
                table: "TabAvaliacao");

            migrationBuilder.RenameTable(
                name: "TabAvaliacao",
                newName: "tabAvaliacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tabAvaliacao",
                table: "tabAvaliacao",
                column: "codigoAvaliacao");

            migrationBuilder.AddForeignKey(
                name: "FK_tabItemDocumento_tabAvaliacao_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento",
                column: "avaliacaocodigoAvaliacao",
                principalTable: "tabAvaliacao",
                principalColumn: "codigoAvaliacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabItemDocumento_tabAvaliacao_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tabAvaliacao",
                table: "tabAvaliacao");

            migrationBuilder.RenameTable(
                name: "tabAvaliacao",
                newName: "TabAvaliacao");

            migrationBuilder.AddColumn<int>(
                name: "emissorcodigoEmissor",
                table: "TabAvaliacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TabAvaliacao",
                table: "TabAvaliacao",
                column: "codigoAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_TabAvaliacao_emissorcodigoEmissor",
                table: "TabAvaliacao",
                column: "emissorcodigoEmissor");

            migrationBuilder.AddForeignKey(
                name: "FK_TabAvaliacao_tabEmissors_emissorcodigoEmissor",
                table: "TabAvaliacao",
                column: "emissorcodigoEmissor",
                principalTable: "tabEmissors",
                principalColumn: "codigoEmissor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tabItemDocumento_TabAvaliacao_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento",
                column: "avaliacaocodigoAvaliacao",
                principalTable: "TabAvaliacao",
                principalColumn: "codigoAvaliacao");
        }
    }
}
