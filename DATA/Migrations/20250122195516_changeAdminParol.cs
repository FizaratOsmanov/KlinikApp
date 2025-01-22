using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class changeAdminParol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f890173b-f88f-4c04-98d7-81e0b9244131",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaf56739-630c-4876-8eea-b1d964d6b7f0", "AQAAAAIAAYagAAAAEIwFOiaylj37YjKacJy/1snc84n0xsNkoBnrsL58Csn9kxjFe/TG9qJgJ6hUf2uVrA==", "9feb345b-48a0-4a5d-9907-ed1bd7223758" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f890173b-f88f-4c04-98d7-81e0b9244131",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c10212e-4d92-4f75-b2b9-5194d499afb2", "AQAAAAIAAYagAAAAEF/RRg6E23/1Q3lbvbdRlMvfcSSe1uyJK+Z6dvJB7xkOTlc5xQiFMENtQbDIXcFS2A==", "60f650c7-81f5-4e46-bfe5-c881daff8576" });
        }
    }
}
