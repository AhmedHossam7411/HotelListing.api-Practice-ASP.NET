using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.api.Migrations
{
    /// <inheritdoc />
    public partial class refactorConfigurationsFolder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "20b7cc54-d657-4078-99a5-2d6447521d91");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ee7691ee-71ea-4cc6-9c62-84c4c7f33ef1");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d724059-5ef4-4e66-859e-506428e211d3", null, "Administrator", "ADMINISTRATOR" },
                    { "f9b40d10-156b-405b-adf4-6446543bc607", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9d724059-5ef4-4e66-859e-506428e211d3");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f9b40d10-156b-405b-adf4-6446543bc607");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20b7cc54-d657-4078-99a5-2d6447521d91", null, "User", "USER" },
                    { "ee7691ee-71ea-4cc6-9c62-84c4c7f33ef1", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
