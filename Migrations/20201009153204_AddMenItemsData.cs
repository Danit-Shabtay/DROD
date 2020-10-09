using Microsoft.EntityFrameworkCore.Migrations;

namespace DROD.Migrations
{
    public partial class AddMenItemsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemName", "Price", "Gender", "Path" },
                values: new object[,]
                {
                    { "M1", 89, 1, "../imgs/M1.JPEG"},
                    { "M2", 109, 1, "../imgs/M2.JPEG"},
                    { "M3", 148, 1, "../imgs/M3.JPEG"},
                    { "M4", 99, 1, "../imgs/M4.JPEG"},
                    { "M5", 219, 1, "../imgs/M5.JPEG"},
                    { "M6", 300, 1, "../imgs/M6.JPEG"}
                }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
