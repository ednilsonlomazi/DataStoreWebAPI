using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabRecursoAvaliacao",
                columns: table => new
                {
                    codigoRecursoAvaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoAvaliacao = table.Column<int>(type: "int", nullable: false),
                    descricaoRecurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtaAberturaRecurso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtaAnaliseRecurso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    analiseRecurso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabRecursoAvaliacao", x => x.codigoRecursoAvaliacao);
                    table.ForeignKey(
                        name: "FK_tabRecursoAvaliacao_tabAvaliacao_codigoAvaliacao",
                        column: x => x.codigoAvaliacao,
                        principalTable: "tabAvaliacao",
                        principalColumn: "codigoAvaliacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabRecursoAvaliacao_codigoAvaliacao",
                table: "tabRecursoAvaliacao",
                column: "codigoAvaliacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabRecursoAvaliacao");
        }
    }
}
