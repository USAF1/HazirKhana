using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class InitialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: false),
                    ParentCuisineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuisines_Cuisines_ParentCuisineId",
                        column: x => x.ParentCuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_ParentCuisineId",
                table: "Cuisines",
                column: "ParentCuisineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuisines");
        }
    }
}
