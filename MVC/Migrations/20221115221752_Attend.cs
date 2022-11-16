using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    public partial class Attend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GigV2");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GigId = table.Column<int>(type: "int", nullable: false),
                    AttendeeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendances_Gig_GigId",
                        column: x => x.GigId,
                        principalTable: "Gig",
                        principalColumn: "GigId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_User_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Followings",
                columns: table => new
                {
                    FollowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FolloweeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => x.FollowingId);
                    table.ForeignKey(
                        name: "FK_Followings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Followings_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "598cfc07-bdc3-4676-a92f-1bb8e951bd60",
                columns: new[] { "ConcurrencyStamp", "Name", "SecurityStamp" },
                values: new object[] { "62b67368-46dd-40b4-8e2e-7e7349450b5f", "Kick Hammer", "8a622135-7b7d-4295-a6ea-79838d1b8d5e" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "ff3a36c1-df1b-4fcc-9567-5776743ad04f",
                columns: new[] { "ConcurrencyStamp", "Name", "SecurityStamp" },
                values: new object[] { "bbe83349-b97d-43f7-9683-e09ab424d8de", "Jose Jose", "068b032b-d09b-4166-aad4-e6d55afef05b" });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AttendeeId",
                table: "Attendances",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_GigId",
                table: "Attendances",
                column: "GigId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_UserId",
                table: "Followings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_UserId1",
                table: "Followings",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Followings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GigV2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GigV2", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "598cfc07-bdc3-4676-a92f-1bb8e951bd60",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "SecurityStamp" },
                values: new object[] { "7c68024a-71eb-434e-a66f-60fd2f403d15", "Kick", "Hammer", "a3be3e0e-64d0-49ee-89cf-773a8911bef7" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "ff3a36c1-df1b-4fcc-9567-5776743ad04f",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "SecurityStamp" },
                values: new object[] { "461f0ab6-74d3-4deb-a011-1028f4620f04", "Jose", "Jose", "89590231-7b16-49bd-8e44-ef65020145c5" });
        }
    }
}
