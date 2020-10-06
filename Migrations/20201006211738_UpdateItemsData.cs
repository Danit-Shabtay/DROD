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
                    { "W1", 59, 1, "../imgs/W1.JPEG"},
                    { "W2", 89, 1, "../imgs/W2.JPEG"},
                    { "W3", 78, 1, "../imgs/W3.JPEG"},
                    { "W4", 89, 1, "../imgs/W4.JPEG"},
                    { "W5", 119, 1, "../imgs/W5.JPEG"},
                    { "W6", 109, 1, "../imgs/W6.JPEG"}
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
