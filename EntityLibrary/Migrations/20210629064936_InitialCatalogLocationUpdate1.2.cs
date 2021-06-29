using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class InitialCatalogLocationUpdate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvienceId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvienceId",
                table: "Cities",
                column: "ProvienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Proviences_ProvienceId",
                table: "Cities",
                column: "ProvienceId",
                principalTable: "Proviences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Proviences_ProvienceId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_ProvienceId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ProvienceId",
                table: "Cities");
        }
    }
}
