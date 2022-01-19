using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class AddReorderDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReorderLevel",
                table: "Products",
                newName: "ReorderAmount");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReorderDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5f1737b4-d8ce-45d1-a4f6-a55df21e675e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "56f4776d-5d1e-4367-b4ea-d84d60c19ac3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 19, 14, 25, 10, 891, DateTimeKind.Local).AddTicks(6037), "daab4c09-3276-4c42-bd97-576e7c6f5bac", new DateTime(2022, 1, 19, 14, 25, 10, 887, DateTimeKind.Local).AddTicks(5932), "AQAAAAEAACcQAAAAEEWj7wpvS0hh6xSnnmLazTv+UBX6Y0UdZsBQjofqZmDI6vJr49SbgS2k33yKQvvK0Q==", "a86cad05-7f1e-40c3-a575-7154c5c28e16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 19, 14, 25, 10, 945, DateTimeKind.Local).AddTicks(3854), "fbd962b3-00ca-4626-afa4-8ade5796835a", new DateTime(2022, 1, 19, 14, 25, 10, 945, DateTimeKind.Local).AddTicks(3811), "AQAAAAEAACcQAAAAEAI//ghjPOwtUMoIF+GYhSwjkK2sPXdlFnsCwFsVYI74eG4B/5aFdhyz5+u12TJWqg==", "879211be-b59c-49d7-b31a-7c370f6f0910" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReorderDate",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ReorderAmount",
                table: "Products",
                newName: "ReorderLevel");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c662f9a2-0498-4516-9e7a-bfbe10852a15");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8d029217-dc27-4743-9807-5a382b6359cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 19, 2, 53, 26, 495, DateTimeKind.Local).AddTicks(2286), "04e51949-6a0a-410d-bdd4-2f52e88b5cb9", new DateTime(2022, 1, 19, 2, 53, 26, 494, DateTimeKind.Local).AddTicks(365), "AQAAAAEAACcQAAAAEF+f2zRNHwXT1g3OB+k/hl8zkKO2SYoQjy2Y0PBvcg6v4M8cQ6PWBbpAkoCIknVdmA==", "edf98031-f180-4743-8f3f-5297c78e97c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 19, 2, 53, 26, 502, DateTimeKind.Local).AddTicks(2243), "00d5b6a0-f285-4bc2-af2e-10c89dc0d525", new DateTime(2022, 1, 19, 2, 53, 26, 502, DateTimeKind.Local).AddTicks(2218), "AQAAAAEAACcQAAAAEMmQXJXnwMhlDzWhl5q43+6qQVAlOXZ3eNGWqwZGAbHviCs0dNs18zT72Lc2J7IGbQ==", "ebaf4581-a8c2-404f-bec7-e57650e88fe2" });
        }
    }
}
