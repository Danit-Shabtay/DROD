using Microsoft.EntityFrameworkCore.Migrations;

namespace DROD.Migrations
{
    public partial class ChnageTypeOrderLinesInIrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orders_OrdersId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrdersId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ItemsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Items_ItemsID",
                        column: x => x.ItemsID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "Genre", "LastName", "Password", "Type" },
                values: new object[] { 1, null, "Danishagan@gmail.com", null, null, null, "Aa123456", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "Genre", "LastName", "Password", "Type" },
                values: new object[] { 2, null, "Ofrimor@gmail.com", null, null, null, "Aa123456", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ItemsID",
                table: "OrderDetail",
                column: "ItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrdersId",
                table: "Orders",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orders_OrdersId",
                table: "Orders",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
