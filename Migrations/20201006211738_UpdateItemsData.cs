using Microsoft.EntityFrameworkCore.Migrations;
using DROD.Models;

namespace DROD.Migrations
{
    public partial class UpdateItemsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemName", "Price", "Gender", "Path" },
                values: new object[,]
                {
                    { "W1", 59, ItemType.Women, "../imgs/W1.JPEG"},
                    { "W2", 89, ItemType.Women, "../imgs/W2.JPEG"},
                    { "W3", 78, ItemType.Women, "../imgs/W3.JPEG"},
                    { "W4", 89, ItemType.Women, "../imgs/W4.JPEG"},
                    { "W5", 119, ItemType.Women, "../imgs/W5.JPEG"},
                    { "W6", 109, ItemType.Women, "../imgs/W6.JPEG"}
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
