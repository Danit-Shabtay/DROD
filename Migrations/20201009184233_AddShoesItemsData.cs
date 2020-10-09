using Microsoft.EntityFrameworkCore.Migrations;

namespace DROD.Migrations
{
    public partial class AddShoesItemsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "Items",
    columns: new[] { "ItemName", "Price", "Gender", "Path" },
    values: new object[,]
    {
                    { "S1", 89, 3, "../imgs/S1.JPEG"},
                    { "S2", 99, 3, "../imgs/S2.JPEG"},
                    { "S3", 79, 3, "../imgs/S3.JPEG"},
                    { "S4", 99, 3, "../imgs/S4.JPEG"},
                    { "S5", 109, 3, "../imgs/S5.JPEG"},
                    { "S6", 69, 3, "../imgs/S6.JPEG"}
    }
);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
