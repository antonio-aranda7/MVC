using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class JWTFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598cfc07-bdc3-4676-a92f-1bb8e951bd60",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b5225eb-bad9-45ea-bb75-59ee5aa09a21", "f6f79980-c7e5-4040-9c65-75dcb95dbf79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff3a36c1-df1b-4fcc-9567-5776743ad04f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "90475106-9960-4920-871b-1ccfc8a81080", "490960e7-1c5e-4580-adf8-03c49f769b7b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "598cfc07-bdc3-4676-a92f-1bb8e951bd60",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bef88f2c-24c3-404a-9a08-e08e481cce7b", "c05eb727-0df8-4d6d-a597-0ab6333d8142" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff3a36c1-df1b-4fcc-9567-5776743ad04f",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d49589a-7a1f-4809-8b9b-d7d7c9fcd5f0", "b275c983-60ab-4ac1-b4af-83699b449eed" });
        }
    }
}
