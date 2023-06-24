using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIFLUENT.Migrations
{
    /// <inheritdoc />
    public partial class changedPUTbacktostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PUT",
                table: "poweruptests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PUT",
                table: "poweruptests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
