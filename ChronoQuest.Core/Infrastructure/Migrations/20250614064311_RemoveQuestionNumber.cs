using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChronoQuest.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuestionNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
