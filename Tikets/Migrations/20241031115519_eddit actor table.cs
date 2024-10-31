using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tikets.Migrations
{
    /// <inheritdoc />
    public partial class edditactortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "News",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "News",
                table: "Actors");
        }
    }
}
