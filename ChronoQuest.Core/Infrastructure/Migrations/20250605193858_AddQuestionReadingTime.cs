using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChronoQuest.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionReadingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionReadingTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionReadingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionReadingTime_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionReadingTime_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionReadingTime_QuestionId",
                table: "QuestionReadingTime",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionReadingTime_UserId",
                table: "QuestionReadingTime",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionReadingTime");
        }
    }
}
