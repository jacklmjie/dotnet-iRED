using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iRED.DataAccess.Migrations
{
    public partial class WxOrder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WxOrderItems_WxProducts_ProductId",
                table: "WxOrderItems");

            migrationBuilder.DropTable(
                name: "WxOrderMiddle");

            migrationBuilder.DropIndex(
                name: "IX_WxOrderItems_ProductId",
                table: "WxOrderItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "WxOrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductName",
                table: "WxOrderItems",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WxOrderItems_WxOrders_WxOrderID",
                table: "WxOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_WxOrderItems_WxOrderID",
                table: "WxOrderItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "WxOrderItems");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "WxOrderItems");

            migrationBuilder.DropColumn(
                name: "WxOrderID",
                table: "WxOrderItems");

            migrationBuilder.CreateTable(
                name: "WxOrderMiddle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxOrderMiddle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WxOrderMiddle_WxOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "WxOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WxOrderMiddle_WxOrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "WxOrderItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderItems_ProductId",
                table: "WxOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderMiddle_OrderId",
                table: "WxOrderMiddle",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderMiddle_OrderItemId",
                table: "WxOrderMiddle",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WxOrderItems_WxProducts_ProductId",
                table: "WxOrderItems",
                column: "ProductId",
                principalTable: "WxProducts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
