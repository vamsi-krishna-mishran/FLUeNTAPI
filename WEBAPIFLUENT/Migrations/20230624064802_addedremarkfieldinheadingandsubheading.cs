using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIFLUENT.Migrations
{
    /// <inheritdoc />
    public partial class addedremarkfieldinheadingandsubheading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "subheading",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "headings",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "subheading");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "headings");
        }
    }
}
