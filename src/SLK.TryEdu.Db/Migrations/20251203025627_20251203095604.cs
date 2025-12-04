using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SLK.TryEdu.Db.Migrations
{
    /// <inheritdoc />
    public partial class _20251203095604 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseData",
                table: "COURSE");

            migrationBuilder.DropColumn(
                name: "EmployeeCre",
                table: "COURSE");

            migrationBuilder.DropColumn(
                name: "PriceCoins",
                table: "COURSE");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "COURSE",
                newName: "StudentCount");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "COURSE",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "COURSE",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "COURSE",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "CourseType",
                table: "COURSE",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "COURSE",
                type: "numeric(3,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "COURSE",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "COURSE",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MongoDbCourseId",
                table: "COURSE",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "COURSE",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "COURSE",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EXAM_QUESTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Prompt = table.Column<string>(type: "text", nullable: true),
                    RichContent = table.Column<string>(type: "jsonb", nullable: true),
                    DefaultPoint = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    Difficulty = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Skill = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswerSchema = table.Column<string>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_QUESTION", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_QUESTION_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "EXAM_TEMPLATE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Level = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ExamType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    PassingScore = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Metadata = table.Column<string>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_TEMPLATE", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_TEMPLATE_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LEARNING_ENROLLMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    EnrolledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Progress = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEARNING_ENROLLMENT", x => x.Id);
                    table.UniqueConstraint("AK_LEARNING_ENROLLMENT_Guid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "EXAM_QUESTION_OPTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamQuestionId = table.Column<int>(type: "integer", nullable: false),
                    Label = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_QUESTION_OPTION", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_QUESTION_OPTION_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_EXAM_QUESTION_OPTION_EXAM_QUESTION_ExamQuestionId",
                        column: x => x.ExamQuestionId,
                        principalTable: "EXAM_QUESTION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EXAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamTemplateId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PriceCoins = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    SnapshotData = table.Column<string>(type: "jsonb", nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_EXAM_EXAM_TEMPLATE_ExamTemplateId",
                        column: x => x.ExamTemplateId,
                        principalTable: "EXAM_TEMPLATE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EXAM_TEMPLATE_SECTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamTemplateId = table.Column<int>(type: "integer", nullable: false),
                    SectionName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    QuestionCount = table.Column<int>(type: "integer", nullable: false),
                    WeightPercentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    Config = table.Column<string>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_TEMPLATE_SECTION", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_TEMPLATE_SECTION_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_EXAM_TEMPLATE_SECTION_EXAM_TEMPLATE_ExamTemplateId",
                        column: x => x.ExamTemplateId,
                        principalTable: "EXAM_TEMPLATE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EXAM_SUBMISSION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Score = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Percentage = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Answers = table.Column<string>(type: "jsonb", nullable: true),
                    AIGradingResult = table.Column<string>(type: "jsonb", nullable: true),
                    UserGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_SUBMISSION", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_SUBMISSION_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_EXAM_SUBMISSION_EXAM_ExamId",
                        column: x => x.ExamId,
                        principalTable: "EXAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EXAM_TEMPLATE_QUESTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamTemplateSectionId = table.Column<int>(type: "integer", nullable: false),
                    ExamQuestionId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    OverridePoint = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    Constraints = table.Column<string>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_TEMPLATE_QUESTION", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_TEMPLATE_QUESTION_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_EXAM_TEMPLATE_QUESTION_EXAM_QUESTION_ExamQuestionId",
                        column: x => x.ExamQuestionId,
                        principalTable: "EXAM_QUESTION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXAM_TEMPLATE_QUESTION_EXAM_TEMPLATE_SECTION_ExamTemplateSe~",
                        column: x => x.ExamTemplateSectionId,
                        principalTable: "EXAM_TEMPLATE_SECTION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EXAM_ATTEMPT_QUESTION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExamSubmissionId = table.Column<int>(type: "integer", nullable: false),
                    ExamQuestionId = table.Column<int>(type: "integer", nullable: false),
                    QuestionOptionId = table.Column<int>(type: "integer", nullable: true),
                    UserAnswer = table.Column<string>(type: "jsonb", nullable: true),
                    Score = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserCreated = table.Column<string>(type: "text", nullable: true),
                    UserModified = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_ATTEMPT_QUESTION", x => x.Id);
                    table.UniqueConstraint("AK_EXAM_ATTEMPT_QUESTION_Guid", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_EXAM_ATTEMPT_QUESTION_EXAM_QUESTION_ExamQuestionId",
                        column: x => x.ExamQuestionId,
                        principalTable: "EXAM_QUESTION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXAM_ATTEMPT_QUESTION_EXAM_SUBMISSION_ExamSubmissionId",
                        column: x => x.ExamSubmissionId,
                        principalTable: "EXAM_SUBMISSION",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_ExamTemplateId",
                table: "EXAM",
                column: "ExamTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_ATTEMPT_QUESTION_ExamQuestionId",
                table: "EXAM_ATTEMPT_QUESTION",
                column: "ExamQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_ATTEMPT_QUESTION_ExamSubmissionId",
                table: "EXAM_ATTEMPT_QUESTION",
                column: "ExamSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_QUESTION_OPTION_ExamQuestionId",
                table: "EXAM_QUESTION_OPTION",
                column: "ExamQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_SUBMISSION_ExamId",
                table: "EXAM_SUBMISSION",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_TEMPLATE_QUESTION_ExamQuestionId",
                table: "EXAM_TEMPLATE_QUESTION",
                column: "ExamQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_TEMPLATE_QUESTION_ExamTemplateSectionId",
                table: "EXAM_TEMPLATE_QUESTION",
                column: "ExamTemplateSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_TEMPLATE_SECTION_ExamTemplateId",
                table: "EXAM_TEMPLATE_SECTION",
                column: "ExamTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXAM_ATTEMPT_QUESTION");

            migrationBuilder.DropTable(
                name: "EXAM_QUESTION_OPTION");

            migrationBuilder.DropTable(
                name: "EXAM_TEMPLATE_QUESTION");

            migrationBuilder.DropTable(
                name: "LEARNING_ENROLLMENT");

            migrationBuilder.DropTable(
                name: "EXAM_SUBMISSION");

            migrationBuilder.DropTable(
                name: "EXAM_QUESTION");

            migrationBuilder.DropTable(
                name: "EXAM_TEMPLATE_SECTION");

            migrationBuilder.DropTable(
                name: "EXAM");

            migrationBuilder.DropTable(
                name: "EXAM_TEMPLATE");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "COURSE");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "COURSE");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "COURSE");

            migrationBuilder.DropColumn(
                name: "MongoDbCourseId",
                table: "COURSE");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "COURSE");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "COURSE");

            migrationBuilder.RenameColumn(
                name: "StudentCount",
                table: "COURSE",
                newName: "CreatedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "COURSE",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "COURSE",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "COURSE",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseType",
                table: "COURSE",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseData",
                table: "COURSE",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeCre",
                table: "COURSE",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "PriceCoins",
                table: "COURSE",
                type: "numeric(12,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
