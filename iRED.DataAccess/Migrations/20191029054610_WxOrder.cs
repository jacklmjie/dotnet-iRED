using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iRED.DataAccess.Migrations
{
    public partial class WxOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WxOrders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserAddress = table.Column<string>(nullable: true),
                    UserPhone = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    PayStatus = table.Column<int>(nullable: false),
                    GoodsStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WxOrders_WxUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "WxUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WxOrderItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    WxOrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxOrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WxOrderItems_WxProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "WxProducts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WxOrderItems_WxOrders_WxOrderID",
                        column: x => x.WxOrderID,
                        principalTable: "WxOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderItems_ProductId",
                table: "WxOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WxOrderItems_WxOrderID",
                table: "WxOrderItems",
                column: "WxOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_WxOrders_UserId",
                table: "WxOrders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WxOrderItems");

            migrationBuilder.DropTable(
                name: "WxOrders");
        }
    }
}
