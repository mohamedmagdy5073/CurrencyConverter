using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "663c6ddf-262a-4d6c-b298-bb92d406c274", 0, "14120b41-99d3-4307-a1a3-ca9a4e347a12", "mohamedmagdy@gmail.com", true, "Mohamed", "Magdy", true, null, "MOHAMEDMAGDY@GMAIL.COM", "MOHAMEDMAGDY", "AQAAAAEAACcQAAAAEFz8RJX2aVKEu/YCPKmkuIGaziVOJ8tBmYgJwAn+6wq9vH0cFa5+K3be7ipBk2/UMQ==", "0123456789", true, "PNPSB6B6YP3GKYCEVLYBXNH3VPPDA34F", true, "mohamedmagdy" }
            );


            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "663c6ddf-262a-4d6c-b298-bb92d406c274", "124ebd8e-82d0-4314-a9c2-f2edf86a883b" }
            );

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "663c6ddf-262a-4d6c-b298-bb92d406c274", "d1f2484f-e460-4a6c-8730-1eec98c5e70f" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "663c6ddf-262a-4d6c-b298-bb92d406c274");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumn: "UserId",
                keyValue: "663c6ddf-262a-4d6c-b298-bb92d406c274");

        }
    }
}
