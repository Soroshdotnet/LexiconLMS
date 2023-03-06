using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconLMS.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AttilaStarkenius632023AddingNewModelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89b55627-73ab-478c-aab0-ab0df874760b", "c7debe7e-b62b-408a-a395-b6f43fc629ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67c6e9af-d316-4b48-8a32-ce60224554b2", "dffcf92a-ee0d-4448-8342-7beae6c7ef24" });
        }
    }
}
