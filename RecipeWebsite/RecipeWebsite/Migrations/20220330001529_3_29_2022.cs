using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebsite.Migrations
{
    public partial class _3_29_2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItem_RecipeDirection_RecipeDirectionId",
                table: "RecipeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItem_Recipes_RecipeId",
                table: "RecipeItem");

            migrationBuilder.DropTable(
                name: "RecipeDirection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeItem",
                table: "RecipeItem");

            migrationBuilder.DropIndex(
                name: "IX_RecipeItem_RecipeDirectionId",
                table: "RecipeItem");

            migrationBuilder.DropColumn(
                name: "RecipeDirectionId",
                table: "RecipeItem");

            migrationBuilder.RenameTable(
                name: "RecipeItem",
                newName: "RecipeItems");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeItem_RecipeId",
                table: "RecipeItems",
                newName: "IX_RecipeItems_RecipeId");

            migrationBuilder.AddColumn<string>(
                name: "RecipeDirection",
                table: "RecipeItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeItems",
                table: "RecipeItems",
                column: "RecipeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItems_Recipes_RecipeId",
                table: "RecipeItems",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeItems_Recipes_RecipeId",
                table: "RecipeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeItems",
                table: "RecipeItems");

            migrationBuilder.DropColumn(
                name: "RecipeDirection",
                table: "RecipeItems");

            migrationBuilder.RenameTable(
                name: "RecipeItems",
                newName: "RecipeItem");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeItems_RecipeId",
                table: "RecipeItem",
                newName: "IX_RecipeItem_RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDirectionId",
                table: "RecipeItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeItem",
                table: "RecipeItem",
                column: "RecipeItemId");

            migrationBuilder.CreateTable(
                name: "RecipeDirection",
                columns: table => new
                {
                    RecipeDirectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Directions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDirection", x => x.RecipeDirectionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItem_RecipeDirectionId",
                table: "RecipeItem",
                column: "RecipeDirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItem_RecipeDirection_RecipeDirectionId",
                table: "RecipeItem",
                column: "RecipeDirectionId",
                principalTable: "RecipeDirection",
                principalColumn: "RecipeDirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeItem_Recipes_RecipeId",
                table: "RecipeItem",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId");
        }
    }
}
