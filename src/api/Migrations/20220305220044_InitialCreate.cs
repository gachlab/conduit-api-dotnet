using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conduit.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    bio = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    following = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    body = table.Column<string>(type: "TEXT", nullable: true),
                    createdAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    favorited = table.Column<bool>(type: "INTEGER", nullable: false),
                    favoritesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    authorusername = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.slug);
                    table.ForeignKey(
                        name: "FK_Articles_Author_authorusername",
                        column: x => x.authorusername,
                        principalTable: "Author",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Articleslug = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.name);
                    table.ForeignKey(
                        name: "FK_Tags_Articles_Articleslug",
                        column: x => x.Articleslug,
                        principalTable: "Articles",
                        principalColumn: "slug",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_authorusername",
                table: "Articles",
                column: "authorusername");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Articleslug",
                table: "Tags",
                column: "Articleslug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
