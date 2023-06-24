using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WEBAPIFLUENT.Migrations
{
    /// <inheritdoc />
    public partial class addedpoweruptest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "poweruptests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Ref = table.Column<string>(type: "longtext", nullable: false),
                    PUT = table.Column<int>(type: "int", nullable: false),
                    Exp = table.Column<string>(type: "longtext", nullable: false),
                    Mes = table.Column<string>(type: "longtext", nullable: false),
                    IId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poweruptests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_poweruptests_identity_IId",
                        column: x => x.IId,
                        principalTable: "identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_poweruptests_IId",
                table: "poweruptests",
                column: "IId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "poweruptests");
        }
    }
}
