using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DAL.Migrations
{
    public partial class AddedIdentityNumberForCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "44698657-4a3c-42a0-a1b7-d15389c9e9b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aaad72c5-e170-44b3-87b1-fd9ff45b6f35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 30, 14, 30, 26, 543, DateTimeKind.Local).AddTicks(8285), "b50eaa38-6779-402a-82b0-697360873d53", new DateTime(2022, 1, 30, 14, 30, 26, 542, DateTimeKind.Local).AddTicks(6192), "AQAAAAEAACcQAAAAEEfitjDAR7ydL6VomveR1PTDS+OyIdOPMhPDfSQxqVk8Kcx/kAPz2y9fvjaaKvNJXg==", "cf6f3f1e-1d37-46b1-bd7b-b27e72165c9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(2022, 1, 30, 14, 30, 26, 550, DateTimeKind.Local).AddTicks(9973), "d70e8406-f3a2-4c34-89cb-1ef7963e6f1f", new DateTime(2022, 1, 30, 14, 30, 26, 550, DateTimeKind.Local).AddTicks(9942), "AQAAAAEAACcQAAAAEA1XINhfPUPJ6KjVt0RdAmFt4Mrdyhy+I7SLSCyMpVf2lhLH90Vy4sjalg63mxt+Sg==", "74a533e4-88a7-4ab6-becc-a445e0449871" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Customers");

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
    }
}
