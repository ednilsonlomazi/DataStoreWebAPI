using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "indAtivo",
                table: "tabClasseObjeto",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dtaCriacao",
                table: "tabClasseObjeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 10, 58, 13, 387, DateTimeKind.Local).AddTicks(7207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "indAtivo",
                table: "tabClasseObjeto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dtaCriacao",
                table: "tabClasseObjeto",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 10, 58, 13, 387, DateTimeKind.Local).AddTicks(7207));
        }
    }
}
