using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceDAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6dfba41e-fbfd-4a0f-b58b-206000550248"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8cb474f-ad9b-4751-b383-fc62f47c8cab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cce2e66d-f3ba-40f8-b7c4-c035997fe560"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("711376d1-6023-43c2-8976-cd1516464a4a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c14d6a8-1e3d-4a36-aab5-e66955d084cf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5d1bfd1-b6fd-46d1-bbae-24723899c02e"));

            migrationBuilder.AddColumn<string>(
                name: "E_mail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "E_mail", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("35efd315-76dc-4e5d-9526-58475d9dc795"), 0, "Paris", "9a78210a-c1cf-425c-a859-14c8e11b9b81", "", "Michael@gmail.com", false, new DateTime(2023, 10, 26, 6, 46, 49, 415, DateTimeKind.Local).AddTicks(7053), false, null, null, null, null, "Michael1234", null, null, false, null, false, "Michael" },
                    { new Guid("8a372c2e-55b3-4804-8f34-6c2d7aeba8c3"), 0, "Paris", "9d56a599-f460-4b7e-b061-eda89b675a75", "", "Sara@example.com", false, new DateTime(2023, 10, 26, 6, 46, 49, 415, DateTimeKind.Local).AddTicks(7047), false, null, null, null, null, "Sara1234", null, null, false, null, false, "Sara" },
                    { new Guid("d2946c26-9d36-43e2-abd3-96e6e1ad924f"), 0, "Newyork", "fcce24ad-f2a9-4664-acab-7d5ef00bc28a", "", "John@example.com", false, new DateTime(2023, 10, 26, 6, 46, 49, 415, DateTimeKind.Local).AddTicks(7026), false, null, null, null, null, "John1234", null, null, false, null, false, "John" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "DiscountRate", "Image", "MinimumQuality", "Name", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("0630923e-85d9-4910-8135-23c73f6a72ad"), "phones", 10m, "", "VeryGood", "Iphone13", 800, new Guid("d2946c26-9d36-43e2-abd3-96e6e1ad924f") },
                    { new Guid("33f47251-f562-4e61-9bda-dea7b82edcb0"), "phones", 150m, "", "Good", "Iphone15", 1000, new Guid("35efd315-76dc-4e5d-9526-58475d9dc795") },
                    { new Guid("687e4179-b277-4cb3-a4c3-14d824197085"), "phones", 10m, "", "Good", "Iphone14", 900, new Guid("8a372c2e-55b3-4804-8f34-6c2d7aeba8c3") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0630923e-85d9-4910-8135-23c73f6a72ad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33f47251-f562-4e61-9bda-dea7b82edcb0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("687e4179-b277-4cb3-a4c3-14d824197085"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35efd315-76dc-4e5d-9526-58475d9dc795"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8a372c2e-55b3-4804-8f34-6c2d7aeba8c3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d2946c26-9d36-43e2-abd3-96e6e1ad924f"));

            migrationBuilder.DropColumn(
                name: "E_mail",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("711376d1-6023-43c2-8976-cd1516464a4a"), 0, "Newyork", "ebffa0ad-c50a-4c91-8a8a-d34dee52c116", "John@example.com", false, new DateTime(2023, 10, 26, 6, 16, 50, 373, DateTimeKind.Local).AddTicks(7398), false, null, null, null, null, "John1234", null, null, false, null, false, "John" },
                    { new Guid("7c14d6a8-1e3d-4a36-aab5-e66955d084cf"), 0, "Paris", "af9efa7a-b62e-41d8-9c20-467e72faf1b4", "Sara@example.com", false, new DateTime(2023, 10, 26, 6, 16, 50, 373, DateTimeKind.Local).AddTicks(7419), false, null, null, null, null, "Sara1234", null, null, false, null, false, "Sara" },
                    { new Guid("a5d1bfd1-b6fd-46d1-bbae-24723899c02e"), 0, "Paris", "56309715-1d0e-4472-83e0-69cae200d491", "Michael@gmail.com", false, new DateTime(2023, 10, 26, 6, 16, 50, 373, DateTimeKind.Local).AddTicks(7425), false, null, null, null, null, "Michael1234", null, null, false, null, false, "Michael" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "DiscountRate", "Image", "MinimumQuality", "Name", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("6dfba41e-fbfd-4a0f-b58b-206000550248"), "phones", 150m, "", "Good", "Iphone15", 1000, new Guid("a5d1bfd1-b6fd-46d1-bbae-24723899c02e") },
                    { new Guid("c8cb474f-ad9b-4751-b383-fc62f47c8cab"), "phones", 10m, "", "VeryGood", "Iphone13", 800, new Guid("711376d1-6023-43c2-8976-cd1516464a4a") },
                    { new Guid("cce2e66d-f3ba-40f8-b7c4-c035997fe560"), "phones", 10m, "", "Good", "Iphone14", 900, new Guid("7c14d6a8-1e3d-4a36-aab5-e66955d084cf") }
                });
        }
    }
}
