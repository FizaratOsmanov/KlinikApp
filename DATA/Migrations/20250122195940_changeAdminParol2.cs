using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    /// <inheritdoc />
    public partial class changeAdminParol2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a599db25-d050-4126-a00e-df56f0b6a05a", "f890173b-f88f-4c04-98d7-81e0b9244131" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a599db25-d050-4126-a00e-df56f0b6a05a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f890173b-f88f-4c04-98d7-81e0b9244131");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d6ec704-60f2-44bc-9485-e5b2516ee13a", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "67bfb8c6-031c-4a06-aaf0-526592f96798", 0, "0c2983ba-9df9-415b-96dc-0bca4113de09", null, false, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEL7kCsfPkccvYoAZUxMr+pKj85EdrzrMlvrx8Yr/heLGJ0OmPRmGMLLeef+h2b0i0w==", null, false, "e16af383-afef-466c-850d-0e66704c5433", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d6ec704-60f2-44bc-9485-e5b2516ee13a", "67bfb8c6-031c-4a06-aaf0-526592f96798" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d6ec704-60f2-44bc-9485-e5b2516ee13a", "67bfb8c6-031c-4a06-aaf0-526592f96798" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d6ec704-60f2-44bc-9485-e5b2516ee13a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67bfb8c6-031c-4a06-aaf0-526592f96798");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a599db25-d050-4126-a00e-df56f0b6a05a", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f890173b-f88f-4c04-98d7-81e0b9244131", 0, "eaf56739-630c-4876-8eea-b1d964d6b7f0", null, false, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEIwFOiaylj37YjKacJy/1snc84n0xsNkoBnrsL58Csn9kxjFe/TG9qJgJ6hUf2uVrA==", null, false, "9feb345b-48a0-4a5d-9907-ed1bd7223758", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a599db25-d050-4126-a00e-df56f0b6a05a", "f890173b-f88f-4c04-98d7-81e0b9244131" });
        }
    }
}
