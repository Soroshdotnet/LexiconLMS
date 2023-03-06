using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LexiconLMS.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AttilaStarkenius632023FixingApplicationUserToReplaceUserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_ActivityType_ActivityTypeId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Module_ModuleId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Course_CourseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Activity_ActivityId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_AspNetUsers_ApplictionUserId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Course_CourseId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Module_ModuleId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Module_Course_CourseId",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity",
                table: "Activity");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activities");

            migrationBuilder.RenameIndex(
                name: "IX_Module_CourseId",
                table: "Modules",
                newName: "IX_Modules_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_ModuleId",
                table: "Documents",
                newName: "IX_Documents_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_CourseId",
                table: "Documents",
                newName: "IX_Documents_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_ApplictionUserId",
                table: "Documents",
                newName: "IX_Documents_ApplictionUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_ActivityId",
                table: "Documents",
                newName: "IX_Documents_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_ModuleId",
                table: "Activities",
                newName: "IX_Activities_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_ActivityTypeId",
                table: "Activities",
                newName: "IX_Activities_ActivityTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Activity_Types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity_Types", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityTypeId", "Desc", "Duration", "ModuleId", "Name", "StartTime" },
                values: new object[,]
                {
                    { -14, 0, "", new TimeSpan(0, 0, 0, 0, 0), 0, "JKL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -13, 0, "", new TimeSpan(0, 0, 0, 0, 0), 0, "GHI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -12, 0, "", new TimeSpan(0, 0, 0, 0, 0), 0, "DEF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, 0, "", new TimeSpan(0, 0, 0, 0, 0), 0, "ABC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Activity_Types",
                columns: new[] { "ID", "Type" },
                values: new object[,]
                {
                    { -2, "Test" },
                    { -1, "Lesson" }
                });

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CourseId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[,]
            //    {
            //        { "-1", 0, "3f439457-c775-4dd3-8224-6770497b6193", null, "abc@hotmail.com", false, false, null, null, null, null, null, false, "700aeb40-3ddf-409f-8fda-c073f8eb316c", false, "abc" },
            //        { "-2", 0, "2a720ee3-bc1a-4c69-9977-ed395d70402f", null, "def@hotmail.com", false, false, null, null, null, null, null, false, "239d980f-7be9-4d64-a394-e6c2deb75cd0", false, "def" }
            //    });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[,]
                {
                    { -13, "-2", "Programming Frontend" },
                    { -12, "-1", "Programming .NET" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "ActivityId", "ApplictionUserId", "CourseId", "ModuleId" },
                values: new object[,]
                {
                    { -11, null, null, null, null },
                    { -10, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CourseId", "Desc", "Duration", "Name", "StartTime" },
                values: new object[,]
                {
                    { -15, 0, "def", new TimeSpan(1, 0, 0, 0, 0), "Azure", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -14, 0, "abc", new TimeSpan(4, 4, 0, 0, 0), "C#", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityType_ActivityTypeId",
                table: "Activities",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Modules_ModuleId",
                table: "Activities",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AspNetUsers_Courses_CourseId",
            //    table: "AspNetUsers",
            //    column: "CourseId",
            //    principalTable: "Courses",
            //    principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Activities_ActivityId",
                table: "Documents",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_ApplictionUserId",
                table: "Documents",
                column: "ApplictionUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Courses_CourseId",
                table: "Documents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Modules_ModuleId",
                table: "Documents",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Courses_CourseId",
                table: "Modules",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityType_ActivityTypeId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Modules_ModuleId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_CourseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Activities_ActivityId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_ApplictionUserId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Courses_CourseId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Modules_ModuleId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Courses_CourseId",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "Activity_Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: -11);

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
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "Module");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_CourseId",
                table: "Module",
                newName: "IX_Module_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ModuleId",
                table: "Document",
                newName: "IX_Document_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_CourseId",
                table: "Document",
                newName: "IX_Document_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ApplictionUserId",
                table: "Document",
                newName: "IX_Document_ApplictionUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_ActivityId",
                table: "Document",
                newName: "IX_Document_ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_ModuleId",
                table: "Activity",
                newName: "IX_Activity_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Activities_ActivityTypeId",
                table: "Activity",
                newName: "IX_Activity_ActivityTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity",
                table: "Activity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_ActivityType_ActivityTypeId",
                table: "Activity",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Module_ModuleId",
                table: "Activity",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Course_CourseId",
                table: "AspNetUsers",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Activity_ActivityId",
                table: "Document",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_AspNetUsers_ApplictionUserId",
                table: "Document",
                column: "ApplictionUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Course_CourseId",
                table: "Document",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Module_ModuleId",
                table: "Document",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Course_CourseId",
                table: "Module",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
