using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorWebAssemblyProjectTest.Server.Migrations
{
    /// <inheritdoc />
    public partial class _001_TipeS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SelfTypes_SelfTypeId",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelfTypes",
                table: "SelfTypes");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SelfTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SelfTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SelfTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "SelfTypes",
                newName: "SelfType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelfType",
                table: "SelfType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TipeS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Persent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipeS",
                columns: new[] { "Id", "Name1", "Persent" },
                values: new object[] { 1, "SelfType1", 25 });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SelfType_SelfTypeId",
                table: "Answers",
                column: "SelfTypeId",
                principalTable: "SelfType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_SelfType_SelfTypeId",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "TipeS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelfType",
                table: "SelfType");

            migrationBuilder.RenameTable(
                name: "SelfType",
                newName: "SelfTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelfTypes",
                table: "SelfTypes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Question 1", 1 },
                    { 2, "Question 2", 2 },
                    { 3, "Question 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "SelfTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SelfType 1" },
                    { 2, "SelfType 2" },
                    { 3, "SelfType 3" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Name", "QuestionId", "SelfTypeId" },
                values: new object[,]
                {
                    { 1, "Answer 1", 1, 1 },
                    { 2, "Answer 2", 1, 2 },
                    { 3, "Answer 3", 1, 3 },
                    { 4, "Answer 4", 2, 1 },
                    { 5, "Answer 5", 2, 2 },
                    { 6, "Answer 6", 2, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_SelfTypes_SelfTypeId",
                table: "Answers",
                column: "SelfTypeId",
                principalTable: "SelfTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
