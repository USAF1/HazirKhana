using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class InitalCatalogUpdateRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Cuisines",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cuisines",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Cuisines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proviences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proviences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    ContactMob = table.Column<long>(type: "bigint", nullable: false),
                    ConatctTel = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProvienceId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Discription = table.Column<string>(type: "varchar(100)", nullable: false),
                    SalesTax = table.Column<int>(type: "int", nullable: false),
                    OrderLedTime = table.Column<int>(type: "int", nullable: false),
                    PercentageCutOff = table.Column<int>(type: "int", nullable: false),
                    Reservation = table.Column<bool>(type: "bit", nullable: false),
                    Logo = table.Column<byte[]>(type: "image", nullable: false),
                    Banner = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurants_Proviences_ProvienceId",
                        column: x => x.ProvienceId,
                        principalTable: "Proviences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CuisineId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Cuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_RestaurantId",
                table: "Cuisines",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CuisineId",
                table: "Products",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RestaurantId",
                table: "Products",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId",
                table: "Restaurants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ProvienceId",
                table: "Restaurants",
                column: "ProvienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuisines_Restaurants_RestaurantId",
                table: "Cuisines",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuisines_Restaurants_RestaurantId",
                table: "Cuisines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Proviences");

            migrationBuilder.DropIndex(
                name: "IX_Cuisines_RestaurantId",
                table: "Cuisines");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Cuisines");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Cuisines",
                type: "image",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cuisines",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);
        }
    }
}
