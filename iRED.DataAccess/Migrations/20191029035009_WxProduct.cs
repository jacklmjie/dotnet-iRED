using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iRED.DataAccess.Migrations
{
    public partial class WxProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WxProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    VenueId = table.Column<int>(nullable: false),
                    PictureId = table.Column<Guid>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    AvailableStock = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WxProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WxProducts_FileAttachments_PictureId",
                        column: x => x.PictureId,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WxProducts_WxVenues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "WxVenues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WxProducts_PictureId",
                table: "WxProducts",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_WxProducts_VenueId",
                table: "WxProducts",
                column: "VenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WxProducts");
        }
    }
}
