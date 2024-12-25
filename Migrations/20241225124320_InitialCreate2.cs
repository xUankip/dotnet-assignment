using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnet_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Rentals",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerID",
                table: "Rentals",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_ComicBookID",
                table: "RentalDetails",
                column: "ComicBookID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_RentalID",
                table: "RentalDetails",
                column: "RentalID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_ComicBooks_ComicBookID",
                table: "RentalDetails",
                column: "ComicBookID",
                principalTable: "ComicBooks",
                principalColumn: "ComicBookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_Rentals_RentalID",
                table: "RentalDetails",
                column: "RentalID",
                principalTable: "Rentals",
                principalColumn: "RentalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Customers_CustomerID",
                table: "Rentals",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_ComicBooks_ComicBookID",
                table: "RentalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_Rentals_RentalID",
                table: "RentalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Customers_CustomerID",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CustomerID",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetails_ComicBookID",
                table: "RentalDetails");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetails_RentalID",
                table: "RentalDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "Rentals",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
