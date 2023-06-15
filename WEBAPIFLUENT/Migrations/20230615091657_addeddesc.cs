using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIFLUENT.Migrations
{
    /// <inheritdoc />
    public partial class addeddesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "bareboards",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageData",
                table: "bareboards",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "bareboards");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "bareboards");
        }
    }
}
