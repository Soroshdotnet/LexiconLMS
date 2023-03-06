using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LexiconLMS.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AttilaStarkenius632023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ID", "Activity_TypeID", "Desc", "Duration", "Module_id", "Name", "StartTime" },
                values: new object[,]
                {
                    { -4, -4, "jkl", new TimeSpan(0, 0, 0, 0, 0), -4, "JKL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -3, -3, "ghi", new TimeSpan(0, 0, 0, 0, 0), -3, "GHI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, -2, "def", new TimeSpan(0, 0, 0, 0, 0), -2, "DEF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, -1, "abc", new TimeSpan(0, 0, 0, 0, 0), -1, "ABC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Activity_Types",
                columns: new[] { "ID", "Type" },
                values: new object[,]
                {
                    { -2, "Test" },
                    { -1, "Lesson" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "-1", 0, "89b55627-73ab-478c-aab0-ab0df874760b", "abc@hotmail.com", false, false, null, null, null, null, null, false, "c7debe7e-b62b-408a-a395-b6f43fc629ee", false, "abc" },
                    { "-2", 0, "67c6e9af-d316-4b48-8a32-ce60224554b2", "def@hotmail.com", false, false, null, null, null, null, null, false, "dffcf92a-ee0d-4448-8342-7beae6c7ef24", false, "def" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Desc", "Name" },
                values: new object[,]
                {
                    { -2, "-2", "Programming Frontend" },
                    { -1, "-1", "Programming .NET" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "ID", "Course_id", "Lesson_id", "Module_id", "Name" },
                values: new object[,]
                {
                    { -2, -1, -1, -1, "Slideshow" },
                    { -1, -1, -1, -1, "E-learning" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ID", "Course_id", "Desc", "Duration", "Name", "StartTime" },
                values: new object[,]
                {
                    { -2, -2, "def", new TimeSpan(1, 0, 0, 0, 0), "Azure", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, -1, "abc", new TimeSpan(4, 4, 0, 0, 0), "C#", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Course_id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { -2, -2, "efgh@hotmail.com", "efgh", "efgh@hotmail.com" },
                    { -1, -1, "abcd@hotmail.com", "abcd", "abcd@hotmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Activity_Types",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Activity_Types",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");
        }
    }
}
