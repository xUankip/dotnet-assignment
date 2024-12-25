using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dotnet_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComicBooks",
                columns: new[] { "ComicBookID", "Author", "PricePerDay", "Title" },
                values: new object[,]
                {
                    { 1, "Gosho Aoyama", 1.5m, "Conan" },
                    { 2, "Fujiko F. Fujio", 1.2m, "Doraemon" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "FullName", "PhoneNumber", "RegistrationDate" },
                values: new object[] { 1, "Nguyen Hung", "0123456789", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "RentalID", "CustomerID", "RentalDate", "ReturnDate", "Status" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" });

            migrationBuilder.InsertData(
                table: "RentalDetails",
                columns: new[] { "RentalDetailID", "ComicBookID", "PricePerDay", "Quantity", "RentalID" },
                values: new object[,]
                {
                    { 1, 1, 1.5m, 1, 1 },
                    { 2, 2, 1.2m, 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RentalDetails",
                keyColumn: "RentalDetailID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalDetails",
                keyColumn: "RentalDetailID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComicBooks",
                keyColumn: "ComicBookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComicBooks",
                keyColumn: "ComicBookID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "RentalID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);
        }
    }
}
