using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class AddReorderLevelAndPictureProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "ReorderLevel",
                table: "Products",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReorderLevel",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "89bf658e-744a-4837-ac8c-a13cf6eb910b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aa192964-d53a-4513-9940-cb205ee3c1c0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 33, 27, 1, DateTimeKind.Local).AddTicks(8694), "620b19de-a81a-49d7-b186-ddbf6abb7f80", new DateTime(2021, 12, 6, 13, 33, 27, 0, DateTimeKind.Local).AddTicks(2982), "AQAAAAEAACcQAAAAEE9n5rdjEty+JKG7mYR/uEOneiw8hIp2z4TAw+dLjMfepRMzWudD4EjHpYwCvNvqGw==", "66a127ff-ea64-4a99-92b0-c37eb07be99c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 33, 27, 40, DateTimeKind.Local).AddTicks(830), "ffa4850b-b300-4218-902b-302311e2e150", new DateTime(2021, 12, 6, 13, 33, 27, 40, DateTimeKind.Local).AddTicks(802), "AQAAAAEAACcQAAAAEH8sgac1iCkfvldT+uPpLyBz4hPxeZWjx4XWnpNocqXUgrLnH2ZYrpWPrDbLhQxEJA==", "87fb6a77-a125-4254-9274-649dcc869d7c" });
        }
    }
}
