using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "avaliacaocodigoAvaliacao",
                table: "tabItemDocumento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TabAvaliacao",
                columns: table => new
                {
                    codigoAvaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emissorcodigoEmissor = table.Column<int>(type: "int", nullable: false),
                    resultado = table.Column<bool>(type: "bit", nullable: false),
                    justificativa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtaAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabAvaliacao", x => x.codigoAvaliacao);
                    table.ForeignKey(
                        name: "FK_TabAvaliacao_tabEmissors_emissorcodigoEmissor",
                        column: x => x.emissorcodigoEmissor,
                        principalTable: "tabEmissors",
                        principalColumn: "codigoEmissor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabItemDocumento_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento",
                column: "avaliacaocodigoAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_TabAvaliacao_emissorcodigoEmissor",
                table: "TabAvaliacao",
                column: "emissorcodigoEmissor");

            migrationBuilder.AddForeignKey(
                name: "FK_tabItemDocumento_TabAvaliacao_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento",
                column: "avaliacaocodigoAvaliacao",
                principalTable: "TabAvaliacao",
                principalColumn: "codigoAvaliacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabItemDocumento_TabAvaliacao_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento");

            migrationBuilder.DropTable(
                name: "TabAvaliacao");

            migrationBuilder.DropIndex(
                name: "IX_tabItemDocumento_avaliacaocodigoAvaliacao",
                table: "tabItemDocumento");

            migrationBuilder.DropColumn(
                name: "avaliacaocodigoAvaliacao",
                table: "tabItemDocumento");
        }
    }
}
