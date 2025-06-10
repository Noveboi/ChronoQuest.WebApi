using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChronoQuest.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBktModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BayesianKnowledgeTracingModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    InitialKnowledgeProbability = table.Column<double>(type: "double precision", nullable: false),
                    LearningProbability = table.Column<double>(type: "double precision", nullable: false),
                    SlipProbability = table.Column<double>(type: "double precision", nullable: false),
                    GuessProbability = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BayesianKnowledgeTracingModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BayesianKnowledgeTracingModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BayesianKnowledgeTracingModel_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkillMastery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModelId = table.Column<Guid>(type: "uuid", nullable: false),
                    UtcDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProbabilityOfMastery = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkillMastery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkillMastery_BayesianKnowledgeTracingModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "BayesianKnowledgeTracingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BayesianKnowledgeTracingModel_TopicId",
                table: "BayesianKnowledgeTracingModel",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_BayesianKnowledgeTracingModel_UserId",
                table: "BayesianKnowledgeTracingModel",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkillMastery_ModelId",
                table: "UserSkillMastery",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkillMastery");

            migrationBuilder.DropTable(
                name: "BayesianKnowledgeTracingModel");
        }
    }
}
