using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeHunterWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(256)", nullable: false),
                    ip_address = table.Column<string>(type: "char(15)", nullable: false),
                    mac_address = table.Column<string>(type: "char(17)", nullable: false),
                    IsUp = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabNode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tabUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(256)", nullable: false),
                    password = table.Column<string>(type: "varchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tabUser_tabNode_NodeId",
                        column: x => x.NodeId,
                        principalTable: "tabNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabUser_NodeId",
                table: "tabUser",
                column: "NodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabUser");

            migrationBuilder.DropTable(
                name: "tabNode");
        }
    }
}
