using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class InitialCatalogRestaurant12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuisines_Restaurants_RestaurantId",
                table: "Cuisines");

            migrationBuilder.DropIndex(
                name: "IX_Cuisines_RestaurantId",
                table: "Cuisines");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Cuisines");

            migrationBuilder.CreateTable(
                name: "CuisineRestaurant",
                columns: table => new
                {
                    CuisinesId = table.Column<int>(type: "int", nullable: false),
                    RestaurantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineRestaurant", x => new { x.CuisinesId, x.RestaurantsId });
                    table.ForeignKey(
                        name: "FK_CuisineRestaurant_Cuisines_CuisinesId",
                        column: x => x.CuisinesId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuisineRestaurant_Restaurants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuisineRestaurant_RestaurantsId",
                table: "CuisineRestaurant",
                column: "RestaurantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuisineRestaurant");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Cuisines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_RestaurantId",
                table: "Cuisines",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuisines_Restaurants_RestaurantId",
                table: "Cuisines",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
