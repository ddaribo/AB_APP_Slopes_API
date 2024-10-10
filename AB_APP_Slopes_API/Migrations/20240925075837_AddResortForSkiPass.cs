using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_APP_Slopes_API.Migrations
{
    /// <inheritdoc />
    public partial class AddResortForSkiPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resort",
                table: "SkiPasses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resort",
                table: "SkiPasses");
        }
    }
}
