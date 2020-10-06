using Microsoft.EntityFrameworkCore.Migrations;

namespace DROD.Migrations
{
    public partial class UpdateItemsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "TypeNote",
            columns: new[] { "ItemName", "Price", "Gender", "Path" },
            values: new object[,]
            {
                { "Test" },
                { "Test1" }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
