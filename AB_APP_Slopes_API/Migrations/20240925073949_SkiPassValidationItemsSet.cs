using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_APP_Slopes_API.Migrations
{
    /// <inheritdoc />
    public partial class SkiPassValidationItemsSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkiPassValidationItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Elevation = table.Column<int>(type: "int", nullable: false),
                    SkiPassID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkiPassValidationItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkiPassValidationItems_SkiPasses_SkiPassID",
                        column: x => x.SkiPassID,
                        principalTable: "SkiPasses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SkiPassValidationItems_SkiPassID",
                table: "SkiPassValidationItems",
                column: "SkiPassID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkiPassValidationItems");
        }
    }
}
