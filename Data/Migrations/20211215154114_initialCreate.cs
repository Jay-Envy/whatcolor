using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatColor.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HEX = table.Column<string>(nullable: true),
                    CMYK = table.Column<int>(nullable: false),
                    RGB = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TrendingUrl = table.Column<string>(nullable: true),
                    ComplementaryHex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
