using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChronoQuest.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_ReviewMaterialParagraph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraMaterial");

            migrationBuilder.CreateTable(
                name: "ReviewMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewMaterial_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewParagraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewParagraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewParagraphs_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewMaterial_UserId",
                table: "ReviewMaterial",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewParagraphs_TopicId",
                table: "ReviewParagraphs",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewMaterial");

            migrationBuilder.DropTable(
                name: "ReviewParagraphs");

            migrationBuilder.CreateTable(
                name: "ExtraMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraMaterial_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMaterial_UserId",
                table: "ExtraMaterial",
                column: "UserId",
                unique: true);
        }
    }
}
