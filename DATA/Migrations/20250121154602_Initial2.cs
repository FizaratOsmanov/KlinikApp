using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f890173b-f88f-4c04-98d7-81e0b9244131",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c10212e-4d92-4f75-b2b9-5194d499afb2", "AQAAAAIAAYagAAAAEF/RRg6E23/1Q3lbvbdRlMvfcSSe1uyJK+Z6dvJB7xkOTlc5xQiFMENtQbDIXcFS2A==", "60f650c7-81f5-4e46-bfe5-c881daff8576" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f890173b-f88f-4c04-98d7-81e0b9244131",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2dfb0f3-bf66-4ce0-9582-28c6541397ce", "AQAAAAIAAYagAAAAEMYvJLISTnToap3QBMxvarvVnwTyo0J3Uw+2yoJsljvpibmtAJH3tlRyM5Wxx8Xm2Q==", "52e82eb0-3b39-43c3-8f9f-1aa98c6b36a3" });
        }
    }
}
