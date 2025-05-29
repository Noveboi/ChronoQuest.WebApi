using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChronoQuest.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Quiz_ChapterId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapter_Topic_ChapterId",
                table: "Chapter");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_AspNetUsers_UserId",
                table: "Exam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Question_QuestionsId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Question_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Topic_TopicId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Question_QuestionsId",
                table: "QuestionQuiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameTable(
                name: "Chapter",
                newName: "Chapters");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TopicId",
                table: "Questions",
                newName: "IX_Questions_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_UserId",
                table: "Exams",
                newName: "IX_Exams_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapter_ChapterId",
                table: "Chapters",
                newName: "IX_Chapters_ChapterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Quiz_ChapterId",
                table: "Chapters",
                column: "ChapterId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapters_Topics_ChapterId",
                table: "Chapters",
                column: "ChapterId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exams_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_UserId",
                table: "Exams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsId",
                table: "QuestionQuiz",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Quiz_ChapterId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_Chapters_Topics_ChapterId",
                table: "Chapters");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exams_ExamId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_UserId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Questions_QuestionId",
                table: "Option");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsId",
                table: "QuestionQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Topics_TopicId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chapters",
                table: "Chapters");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameTable(
                name: "Chapters",
                newName: "Chapter");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TopicId",
                table: "Question",
                newName: "IX_Question_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_UserId",
                table: "Exam",
                newName: "IX_Exam_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chapters_ChapterId",
                table: "Chapter",
                newName: "IX_Chapter_ChapterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chapter",
                table: "Chapter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Quiz_ChapterId",
                table: "Chapter",
                column: "ChapterId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chapter_Topic_ChapterId",
                table: "Chapter",
                column: "ChapterId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_AspNetUsers_UserId",
                table: "Exam",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Question_QuestionsId",
                table: "ExamQuestion",
                column: "QuestionsId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Question_QuestionId",
                table: "Option",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Topic_TopicId",
                table: "Question",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Question_QuestionsId",
                table: "QuestionQuiz",
                column: "QuestionsId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
