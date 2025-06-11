using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChronoQuest.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Bkt_ManyUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BayesianKnowledgeTracingModel_UserId",
                table: "BayesianKnowledgeTracingModel");

            migrationBuilder.CreateTable(
                name: "ExtraMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
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
                name: "IX_BayesianKnowledgeTracingModel_UserId",
                table: "BayesianKnowledgeTracingModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMaterial_UserId",
                table: "ExtraMaterial",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraMaterial");

            migrationBuilder.DropIndex(
                name: "IX_BayesianKnowledgeTracingModel_UserId",
                table: "BayesianKnowledgeTracingModel");

            migrationBuilder.CreateIndex(
                name: "IX_BayesianKnowledgeTracingModel_UserId",
                table: "BayesianKnowledgeTracingModel",
                column: "UserId",
                unique: true);
        }
    }
}
