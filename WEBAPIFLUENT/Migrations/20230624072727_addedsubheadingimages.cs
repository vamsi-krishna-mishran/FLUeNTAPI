using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WEBAPIFLUENT.Migrations
{
    /// <inheritdoc />
    public partial class addedsubheadingimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subheadingimages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    ImageData = table.Column<string>(type: "longtext", nullable: false),
                    SHId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subheadingimages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subheadingimages_subheading_SHId",
                        column: x => x.SHId,
                        principalTable: "subheading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_subheadingimages_SHId",
                table: "subheadingimages",
                column: "SHId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subheadingimages");
        }
    }
}
