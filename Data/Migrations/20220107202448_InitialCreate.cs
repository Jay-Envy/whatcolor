using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatColor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WhatColor");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "WhatColor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorCategory",
                schema: "WhatColor",
                columns: table => new
                {
                    ColorCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainColor = table.Column<string>(nullable: true),
                    Positive = table.Column<string>(nullable: true),
                    Negative = table.Column<string>(nullable: true),
                    Meaning = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCategory", x => x.ColorCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "WhatColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "WhatColor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "WhatColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "WhatColor",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "WhatColor",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "WhatColor",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                schema: "WhatColor",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HEX = table.Column<string>(nullable: true),
                    CMYK = table.Column<string>(nullable: true),
                    RGB = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TrendingUrl = table.Column<string>(nullable: true),
                    ComplementaryHex = table.Column<string>(nullable: true),
                    ColorCategoryID = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorID);
                    table.ForeignKey(
                        name: "FK_Color_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "WhatColor",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    Contents = table.Column<string>(nullable: true),
                    Img = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Image_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColorHistory",
                schema: "WhatColor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ColorHistoryID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false),
                    SearchDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorHistory_Color_ColorID",
                        column: x => x.ColorID,
                        principalSchema: "WhatColor",
                        principalTable: "Color",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorHistory_AspNetUsers_Id",
                        column: x => x.Id,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageLibrary",
                schema: "WhatColor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImageLibraryID = table.Column<int>(nullable: false),
                    ImageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageLibrary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageLibrary_AspNetUsers_Id",
                        column: x => x.Id,
                        principalSchema: "WhatColor",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageLibrary_Image_ImageID",
                        column: x => x.ImageID,
                        principalSchema: "WhatColor",
                        principalTable: "Image",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "WhatColor",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "WhatColor",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "WhatColor",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "WhatColor",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "WhatColor",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "WhatColor",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "WhatColor",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                schema: "WhatColor",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_UserId",
                schema: "WhatColor",
                table: "Color",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorHistory_ColorID",
                schema: "WhatColor",
                table: "ColorHistory",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UserId",
                schema: "WhatColor",
                table: "Image",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageLibrary_ImageID",
                schema: "WhatColor",
                table: "ImageLibrary",
                column: "ImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "ColorCategory",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "ColorHistory",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "ImageLibrary",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "Color",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "WhatColor");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "WhatColor");
        }
    }
}
