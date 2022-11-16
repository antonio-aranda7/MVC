using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class Configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Jazz" },
                    { 2, "Blues" },
                    { 3, "Rock" },
                    { 4, "Country" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "598cfc07-bdc3-4676-a92f-1bb8e951bd60", 0, "7c68024a-71eb-434e-a66f-60fd2f403d15", null, false, "Kick", "Hammer", false, null, null, null, null, null, false, "a3be3e0e-64d0-49ee-89cf-773a8911bef7", false, null },
                    { "ff3a36c1-df1b-4fcc-9567-5776743ad04f", 0, "461f0ab6-74d3-4deb-a011-1028f4620f04", null, false, "Jose", "Jose", false, null, null, null, null, null, false, "89590231-7b16-49bd-8e44-ef65020145c5", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "598cfc07-bdc3-4676-a92f-1bb8e951bd60");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "ff3a36c1-df1b-4fcc-9567-5776743ad04f");
        }
    }
}
