using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class md : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idClasseObjeto",
                table: "tabObjeto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tabClasseObjeto",
                columns: table => new
                {
                    IdClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoClasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtaCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    indAtivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabClasseObjeto", x => x.IdClasse);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabObjeto_idClasseObjeto",
                table: "tabObjeto",
                column: "idClasseObjeto");

            migrationBuilder.AddForeignKey(
                name: "FK_tabObjeto_tabClasseObjeto_idClasseObjeto",
                table: "tabObjeto",
                column: "idClasseObjeto",
                principalTable: "tabClasseObjeto",
                principalColumn: "IdClasse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tabObjeto_tabClasseObjeto_idClasseObjeto",
                table: "tabObjeto");

            migrationBuilder.DropTable(
                name: "tabClasseObjeto");

            migrationBuilder.DropIndex(
                name: "IX_tabObjeto_idClasseObjeto",
                table: "tabObjeto");

            migrationBuilder.DropColumn(
                name: "idClasseObjeto",
                table: "tabObjeto");
        }
    }
}
