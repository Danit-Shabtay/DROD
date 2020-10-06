using Microsoft.EntityFrameworkCore.Migrations;

namespace DROD.Migrations
{
    public partial class AddGenderAndPathToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Items");
        }
    }
}
