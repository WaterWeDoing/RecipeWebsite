using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_SubmitterId",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "SubmitterId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_SubmitterId",
                table: "Recipes",
                column: "SubmitterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_SubmitterId",
                table: "Recipes");

            migrationBuilder.AlterColumn<string>(
                name: "SubmitterId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_SubmitterId",
                table: "Recipes",
                column: "SubmitterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
