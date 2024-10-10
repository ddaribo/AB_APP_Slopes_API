using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB_APP_Slopes_API.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lift_Resorts_ResortId",
                table: "Lift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lift",
                table: "Lift");

            migrationBuilder.RenameTable(
                name: "Lift",
                newName: "Lifts");

            migrationBuilder.RenameIndex(
                name: "IX_Lift_ResortId",
                table: "Lifts",
                newName: "IX_Lifts_ResortId");

            migrationBuilder.AddColumn<string>(
                name: "AvalancheRisk",
                table: "Resorts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Resorts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ResortId",
                table: "Lifts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lifts",
                table: "Lifts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SkiPasses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReloadable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkiPasses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkiPasses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SkiPasses_UserId",
                table: "SkiPasses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lifts_Resorts_ResortId",
                table: "Lifts",
                column: "ResortId",
                principalTable: "Resorts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lifts_Resorts_ResortId",
                table: "Lifts");

            migrationBuilder.DropTable(
                name: "SkiPasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lifts",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "AvalancheRisk",
                table: "Resorts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Resorts");

            migrationBuilder.RenameTable(
                name: "Lifts",
                newName: "Lift");

            migrationBuilder.RenameIndex(
                name: "IX_Lifts_ResortId",
                table: "Lift",
                newName: "IX_Lift_ResortId");

            migrationBuilder.AlterColumn<int>(
                name: "ResortId",
                table: "Lift",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lift",
                table: "Lift",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lift_Resorts_ResortId",
                table: "Lift",
                column: "ResortId",
                principalTable: "Resorts",
                principalColumn: "Id");
        }
    }
}
