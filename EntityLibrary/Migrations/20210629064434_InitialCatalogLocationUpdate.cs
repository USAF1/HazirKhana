using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityLibrary.Migrations
{
    public partial class InitialCatalogLocationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Proviences",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proviences_Name",
                table: "Proviences",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name_PostalCode",
                table: "Cities",
                columns: new[] { "Name", "PostalCode" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Proviences_Name",
                table: "Proviences");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Name_PostalCode",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Proviences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }
    }
}
