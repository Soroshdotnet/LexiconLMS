using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiconLMS.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixMissingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8272fc96-c07b-46a3-a763-6fa2f02bf68d", "0c8913ad-7286-4de1-a92f-58d8acd1f29b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "290a78d2-73a4-4239-8189-36f2c5582fb6", "7fda93f7-6039-40e3-8b5c-6640016dc347" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f439457-c775-4dd3-8224-6770497b6193", "700aeb40-3ddf-409f-8fda-c073f8eb316c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a720ee3-bc1a-4c69-9977-ed395d70402f", "239d980f-7be9-4d64-a394-e6c2deb75cd0" });
        }
    }
}
