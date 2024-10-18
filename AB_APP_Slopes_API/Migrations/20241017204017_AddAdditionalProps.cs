using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AB_APP_Slopes_API.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SocialFeed_FeedPostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_SkiPasses_AspNetUsers_UserId",
                table: "SkiPasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SkiPassValidationItems_SkiPasses_SkiPassID",
                table: "SkiPassValidationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialFeed_AspNetUsers_UserId",
                table: "SocialFeed");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "SocialFeed");

            migrationBuilder.DropColumn(
                name: "Resort",
                table: "SkiPasses");

            migrationBuilder.RenameColumn(
                name: "SkiPassID",
                table: "SkiPassValidationItems",
                newName: "SkiPassId");

            migrationBuilder.RenameIndex(
                name: "IX_SkiPassValidationItems_SkiPassID",
                table: "SkiPassValidationItems",
                newName: "IX_SkiPassValidationItems_SkiPassId");

            migrationBuilder.UpdateData(
                table: "SocialFeed",
                keyColumn: "UserId",
                keyValue: null,
                column: "UserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SocialFeed",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LiftID",
                table: "SkiPassValidationItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SkiPasses",
                keyColumn: "UserId",
                keyValue: null,
                column: "UserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SkiPasses",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ResortId",
                table: "SkiPasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Elevation",
                table: "Lifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "UserId",
                keyValue: null,
                column: "UserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FeedPostID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3", 0, "3e572262-3307-4ce7-85c7-ab3aa6e9746e", "user@example.com", false, true, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDgMpSD8PRl5bjhwpfAmC03rdAemVqABZVtyp4rm7HM1etb2110YmPLtfLQxMAzfxg==", null, false, "MUCKVMYLN3EZL7HJPIJBRX6GWW3TWZKS", false, "user@example.com" });

            migrationBuilder.InsertData(
                table: "Resorts",
                columns: new[] { "Id", "AvalancheRisk", "ImageUrl", "Name", "PassImageUrl" },
                values: new object[,]
                {
                    { 2, "Low avalanche risk", "https://my.appbuilder.dev/api/assets/750ef162-23d7-4919-9988-fd46ed1ddb8f/content?ts=2024-09-17T14:18:50.361872Z", "Bansko", "https://my.appbuilder.dev/api/assets/d2f3a913-5acc-447d-a67d-a8fcc374421a/content?ts=2024-09-19T10:16:32.939986Z" },
                    { 3, "Low avalanche risk", "https://my.appbuilder.dev/api/assets/e0c392f7-74b8-4cbd-805b-741552fe6683/content?ts=2024-09-17T14:17:57.579837Z", "Borovets", "https://my.appbuilder.dev/api/assets/c78c2e7e-15d0-4222-8310-7656ab1fc9dc/content?ts=2024-09-19T10:18:36.851622Z" },
                    { 4, "Low avalanche risk", "https://my.appbuilder.dev/api/assets/8651aee7-d411-47dd-90d7-615290048064/content?ts=2024-10-10T10:33:00.6130576Z", "Vitosha", "https://my.appbuilder.dev/api/assets/8d47d314-622d-405f-8d3b-59d5b6d71bbd/content?ts=2024-10-10T10:33:01.1651277Z" }
                });

            migrationBuilder.InsertData(
                table: "Lifts",
                columns: new[] { "Id", "Elevation", "IsOpen", "Name", "ResortId" },
                values: new object[,]
                {
                    { 1, 0, true, "Cabin lift", 2 },
                    { 2, 0, true, "Todorka", 2 },
                    { 3, 0, false, "Most", 2 },
                    { 4, 0, false, "Kolarski", 2 },
                    { 5, 0, true, "Bunderitza 1", 2 },
                    { 6, 0, true, "Bunderitza 2", 2 },
                    { 7, 0, false, "Gondola", 3 },
                    { 8, 0, true, "Sitnyakovo express", 3 },
                    { 9, 0, true, "Martinovi baraki", 3 },
                    { 10, 0, true, "Yastrebetz Express", 3 },
                    { 11, 0, true, "Markudzhik", 3 },
                    { 12, 0, true, "Cabin lift", 4 },
                    { 13, 0, true, "Lale 1", 4 },
                    { 14, 0, true, "Lale 2", 4 },
                    { 15, 0, true, "Pomagalski", 4 },
                    { 16, 0, true, "Mecha polyana", 4 }
                });

            migrationBuilder.InsertData(
                table: "SkiPasses",
                columns: new[] { "ID", "FirstName", "IsActive", "IsReloadable", "LastName", "ResortId", "UserId" },
                values: new object[,]
                {
                    { "123456", "", false, false, "", 2, "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" },
                    { "pass-001", "John", true, true, "Doe", 2, "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" },
                    { "pass-002", "Jane", true, false, "Smith", 3, "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" }
                });

            migrationBuilder.InsertData(
                table: "SocialFeed",
                columns: new[] { "ID", "Content", "ImgUrl", "TimeStamp", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Content of post 1", "https://my.appbuilder.dev/api/assets/750ef162-23d7-4919-9988-fd46ed1ddb8f/content?ts=2024-09-17T14:18:50.361872Z", new DateTime(2024, 10, 17, 23, 40, 17, 0, DateTimeKind.Local).AddTicks(3832), "Post 1", "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" },
                    { 2, "Content of post 2", "https://my.appbuilder.dev/api/assets/750ef162-23d7-4919-9988-fd46ed1ddb8f/content?ts=2024-09-17T14:18:50.361872Z", new DateTime(2024, 10, 16, 23, 40, 17, 0, DateTimeKind.Local).AddTicks(3940), "Post 2", "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" },
                    { 3, "Content of post 3", "https://my.appbuilder.dev/api/assets/750ef162-23d7-4919-9988-fd46ed1ddb8f/content?ts=2024-09-17T14:18:50.361872Z", new DateTime(2024, 10, 15, 23, 40, 17, 0, DateTimeKind.Local).AddTicks(3963), "Post 3", "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" },
                    { 4, "Content of post 4", "https://my.appbuilder.dev/api/assets/750ef162-23d7-4919-9988-fd46ed1ddb8f/content?ts=2024-09-17T14:18:50.361872Z", new DateTime(2024, 10, 14, 23, 40, 17, 0, DateTimeKind.Local).AddTicks(3980), "Post 4", "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" },
                    { 5, "Content of post 5", "https://my.appbuilder.dev/api/assets/750ef162-23d7-4919-9988-fd46ed1ddb8f/content?ts=2024-09-17T14:18:50.361872Z", new DateTime(2024, 10, 13, 23, 40, 17, 0, DateTimeKind.Local).AddTicks(3996), "Post 5", "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "FeedPostID", "TimeStamp", "UserId" },
                values: new object[] { 1, "Anyone?", 1, new DateTime(2024, 9, 25, 11, 44, 11, 0, DateTimeKind.Unspecified), "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3" });

            migrationBuilder.InsertData(
                table: "SkiPassValidationItems",
                columns: new[] { "ID", "Elevation", "LiftID", "SkiPassId", "Time" },
                values: new object[,]
                {
                    { 1, 1500, 1, "123456", "09:00" },
                    { 2, 2300, 1, "123456", "09:35" },
                    { 3, 1700, 3, "123456", "09:40" },
                    { 4, 1900, 3, "123456", "09:45" },
                    { 5, 1200, 4, "123456", "09:55" },
                    { 6, 1750, 4, "123456", "10:05" },
                    { 7, 1300, 5, "123456", "10:06" },
                    { 8, 1800, 5, "123456", "10:14" },
                    { 9, 1800, 6, "123456", "10:20" },
                    { 10, 2500, 6, "123456", "10:35" },
                    { 11, 1500, 1, "123456", "11:00" },
                    { 12, 1900, 1, "123456", "11:35" },
                    { 13, 1200, 4, "123456", "11:40" },
                    { 14, 1750, 4, "123456", "11:49" },
                    { 49, 1500, 0, "pass-001", "08:30" },
                    { 50, 1600, 0, "pass-001", "09:15" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkiPassValidationItems_LiftID",
                table: "SkiPassValidationItems",
                column: "LiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SocialFeed_FeedPostID",
                table: "Comments",
                column: "FeedPostID",
                principalTable: "SocialFeed",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkiPasses_AspNetUsers_UserId",
                table: "SkiPasses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkiPassValidationItems_Lifts_LiftID",
                table: "SkiPassValidationItems",
                column: "LiftID",
                principalTable: "Lifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkiPassValidationItems_SkiPasses_SkiPassId",
                table: "SkiPassValidationItems",
                column: "SkiPassId",
                principalTable: "SkiPasses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialFeed_AspNetUsers_UserId",
                table: "SocialFeed",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SocialFeed_FeedPostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_SkiPasses_AspNetUsers_UserId",
                table: "SkiPasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SkiPassValidationItems_Lifts_LiftID",
                table: "SkiPassValidationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SkiPassValidationItems_SkiPasses_SkiPassId",
                table: "SkiPassValidationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialFeed_AspNetUsers_UserId",
                table: "SocialFeed");

            migrationBuilder.DropIndex(
                name: "IX_SkiPassValidationItems_LiftID",
                table: "SkiPassValidationItems");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SkiPassValidationItems",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SkiPasses",
                keyColumn: "ID",
                keyValue: "pass-002");

            migrationBuilder.DeleteData(
                table: "SocialFeed",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SocialFeed",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SocialFeed",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SocialFeed",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lifts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SkiPasses",
                keyColumn: "ID",
                keyValue: "123456");

            migrationBuilder.DeleteData(
                table: "SkiPasses",
                keyColumn: "ID",
                keyValue: "pass-001");

            migrationBuilder.DeleteData(
                table: "SocialFeed",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4b5e8c5-3253-4a5d-b0c5-b2845e0672e3");

            migrationBuilder.DeleteData(
                table: "Resorts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "LiftID",
                table: "SkiPassValidationItems");

            migrationBuilder.DropColumn(
                name: "ResortId",
                table: "SkiPasses");

            migrationBuilder.DropColumn(
                name: "Elevation",
                table: "Lifts");

            migrationBuilder.RenameColumn(
                name: "SkiPassId",
                table: "SkiPassValidationItems",
                newName: "SkiPassID");

            migrationBuilder.RenameIndex(
                name: "IX_SkiPassValidationItems_SkiPassId",
                table: "SkiPassValidationItems",
                newName: "IX_SkiPassValidationItems_SkiPassID");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SocialFeed",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "SocialFeed",
                type: "longblob",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SkiPasses",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Resort",
                table: "SkiPasses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "FeedPostID",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SocialFeed_FeedPostID",
                table: "Comments",
                column: "FeedPostID",
                principalTable: "SocialFeed",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SkiPasses_AspNetUsers_UserId",
                table: "SkiPasses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkiPassValidationItems_SkiPasses_SkiPassID",
                table: "SkiPassValidationItems",
                column: "SkiPassID",
                principalTable: "SkiPasses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialFeed_AspNetUsers_UserId",
                table: "SocialFeed",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
