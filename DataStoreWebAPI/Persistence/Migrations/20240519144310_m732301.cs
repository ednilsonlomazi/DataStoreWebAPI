using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m732301 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "codigoDocumento",
                table: "tabAvaliacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "codigoItemDocumento",
                table: "tabAvaliacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigoDocumento",
                table: "tabAvaliacao");

            migrationBuilder.DropColumn(
                name: "codigoItemDocumento",
                table: "tabAvaliacao");
        }
    }
}
