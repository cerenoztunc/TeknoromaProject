using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class AddedBirthDateAndGenderPropertiesForCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "de9f2eaf-41af-4a52-a6b6-8270cbe7c3d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8a3026fd-bf75-4af6-88ec-73ff23dd577b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 24, 23, 52, 46, 708, DateTimeKind.Local).AddTicks(2513), "c3914db5-2545-49e8-a598-c2eb79bbff01", new DateTime(2022, 1, 24, 23, 52, 46, 707, DateTimeKind.Local).AddTicks(229), "AQAAAAEAACcQAAAAEIQoFBQ0D3EFgTy5rj5k9yQRBB9XBtftiszVEizcLPzUVzgNe2HRy5n50mErLdlwAg==", "5ab630dc-1adb-4f92-898b-44f7b4df3c3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 24, 23, 52, 46, 715, DateTimeKind.Local).AddTicks(6814), "55c30b00-ac51-454c-ba07-3d41a0f83b1f", new DateTime(2022, 1, 24, 23, 52, 46, 715, DateTimeKind.Local).AddTicks(6788), "AQAAAAEAACcQAAAAENYuPeQuH7s5MS+qbRqIlZADkhVfHaIExSRGNTBaU5LgM5zSCTrtbIHTndKj9maB7g==", "636fc18a-b7aa-4ee8-b127-fc0ce3fd2ed5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

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
    }
}
