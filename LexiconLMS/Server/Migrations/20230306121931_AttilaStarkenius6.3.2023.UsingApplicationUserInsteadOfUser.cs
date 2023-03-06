using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconLMS.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AttilaStarkenius632023UsingApplicationUserInsteadOfUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf16bc8b-3441-44e7-a153-c5976881a12d", "109c4d1b-d037-4050-a766-3220e5e3c0fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5894681-baac-4eaa-8419-eb684a8b87a6", "8a28de34-ebe7-4b7c-8c51-71d7e476b0d4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de2e9076-1295-4a8a-aa6e-e526a4c7f3d1", "d09f014e-887a-4b00-b5a2-1a73c3dd3393" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8543e3b-83b9-459a-871b-58b888cd3a14", "5d1548f6-6b4f-475a-bceb-2db16b4756bc" });
        }
    }
}
