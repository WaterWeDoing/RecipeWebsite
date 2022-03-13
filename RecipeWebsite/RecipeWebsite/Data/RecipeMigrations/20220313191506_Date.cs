using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Data.RecipeMigrations
{
    public partial class Date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipes",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MainIngredient",
                newName: "MainIngredientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Recipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Recipes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MainIngredientId",
                table: "MainIngredient",
                newName: "Id");
        }
    }
}
