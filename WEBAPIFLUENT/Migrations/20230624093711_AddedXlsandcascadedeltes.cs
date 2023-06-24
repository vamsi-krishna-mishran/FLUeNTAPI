using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WEBAPIFLUENT.Migrations
{
    /// <inheritdoc />
    public partial class AddedXlsandcascadedeltes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "xLTamplates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    SHId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xLTamplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_xLTamplates_subheading_SHId",
                        column: x => x.SHId,
                        principalTable: "subheading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "xLSheets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Col1 = table.Column<string>(type: "longtext", nullable: false),
                    Col2 = table.Column<string>(type: "longtext", nullable: false),
                    Col3 = table.Column<string>(type: "longtext", nullable: false),
                    Col4 = table.Column<string>(type: "longtext", nullable: false),
                    XId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xLSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_xLSheets_xLTamplates_XId",
                        column: x => x.XId,
                        principalTable: "xLTamplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_xLSheets_XId",
                table: "xLSheets",
                column: "XId");

            migrationBuilder.CreateIndex(
                name: "IX_xLTamplates_SHId",
                table: "xLTamplates",
                column: "SHId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "xLSheets");

            migrationBuilder.DropTable(
                name: "xLTamplates");
        }
    }
}
