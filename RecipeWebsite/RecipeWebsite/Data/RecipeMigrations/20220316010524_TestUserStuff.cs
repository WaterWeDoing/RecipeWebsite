using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Data.RecipeMigrations
{
    public partial class TestUserStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubbmiterId",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubmitterId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaterId",
                table: "RecipeRating",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RecipeUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_SubmitterId",
                table: "Recipes",
                column: "SubmitterId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRating_RaterId",
                table: "RecipeRating",
                column: "RaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeRating_RecipeUser_RaterId",
                table: "RecipeRating",
                column: "RaterId",
                principalTable: "RecipeUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeUser_SubmitterId",
                table: "Recipes",
                column: "SubmitterId",
                principalTable: "RecipeUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeRating_RecipeUser_RaterId",
                table: "RecipeRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeUser_SubmitterId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeUser");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_SubmitterId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRating_RaterId",
                table: "RecipeRating");

            migrationBuilder.DropColumn(
                name: "SubbmiterId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "SubmitterId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RaterId",
                table: "RecipeRating");
        }
    }
}
