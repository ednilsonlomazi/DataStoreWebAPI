using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStoreWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mddD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dtaCriacao",
                table: "tabClasseObjeto",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 10, 58, 13, 387, DateTimeKind.Local).AddTicks(7207));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dtaCriacao",
                table: "tabClasseObjeto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 10, 58, 13, 387, DateTimeKind.Local).AddTicks(7207),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
