using Microsoft.EntityFrameworkCore.Migrations;

namespace iRED.DataAccess.Migrations
{
    public partial class Wxorder3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WxOrderItems_WxOrders_WxOrderID",
                table: "WxOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_WxOrderItems_WxOrderID",
                table: "WxOrderItems");

            migrationBuilder.DropColumn(
                name: "WxOrderID",
                table: "WxOrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderItems_OrderId",
                table: "WxOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderItems_ProductId",
                table: "WxOrderItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_WxOrderItems_WxOrders_OrderId",
                table: "WxOrderItems",
                column: "OrderId",
                principalTable: "WxOrders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WxOrderItems_WxProducts_ProductId",
                table: "WxOrderItems",
                column: "ProductId",
                principalTable: "WxProducts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WxOrderItems_WxOrders_OrderId",
                table: "WxOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WxOrderItems_WxProducts_ProductId",
                table: "WxOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_WxOrderItems_OrderId",
                table: "WxOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_WxOrderItems_ProductId",
                table: "WxOrderItems");

            migrationBuilder.AddColumn<int>(
                name: "WxOrderID",
                table: "WxOrderItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderItems_WxOrderID",
                table: "WxOrderItems",
                column: "WxOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_WxOrderItems_WxOrders_WxOrderID",
                table: "WxOrderItems",
                column: "WxOrderID",
                principalTable: "WxOrders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
