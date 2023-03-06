using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LexiconLMS.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AttilaStarkenius632023fixingapplicationdbcontextcsclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Course_id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1",
                columns: new[] { "ConcurrencyStamp", "Course_id", "Name", "Password", "SecurityStamp" },
                values: new object[] { "de2e9076-1295-4a8a-aa6e-e526a4c7f3d1", -1, "ABC", "abc", "d09f014e-887a-4b00-b5a2-1a73c3dd3393" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2",
                columns: new[] { "ConcurrencyStamp", "Course_id", "Name", "Password", "SecurityStamp" },
                values: new object[] { "d8543e3b-83b9-459a-871b-58b888cd3a14", -2, "DEF", "def", "5d1548f6-6b4f-475a-bceb-2db16b4756bc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb70fcd4-72bd-4449-af03-d1e58b5293ca", "76cd49bd-008c-40ad-ba03-f2979a201bb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0b7d2577-6ebe-4b39-838f-c29aa12de3a5", "6201c586-e6e9-4df1-b43f-bc76e1629c9b" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Course_id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { -2, -2, "efgh@hotmail.com", "efgh", "efgh@hotmail.com" },
                    { -1, -1, "abcd@hotmail.com", "abcd", "abcd@hotmail.com" }
                });
        }
    }
}
