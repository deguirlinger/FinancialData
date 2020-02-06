using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialData.API.Migrations
{
    public partial class NextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("3fe335af-dec4-4122-b52a-0b62b5f05b44"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8ceacc18-dd09-4314-855f-7104c9f3b24c"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("af47a135-05fb-486e-896a-b43b07ea1166"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("cda8eb0c-9e2e-4e8e-bd9b-f6969b267da7"), new DateTime(2020, 2, 6, 11, 30, 49, 560, DateTimeKind.Local).AddTicks(8220), "It's hot!", 32 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("f1d47b78-f0f0-4489-967a-889f9d2c453f"), new DateTime(2020, 2, 6, 11, 30, 49, 577, DateTimeKind.Local).AddTicks(380), "It's chilly...", 10 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("8ae40ab9-b47a-447e-bef1-424cf110c48a"), new DateTime(2020, 2, 6, 11, 30, 49, 577, DateTimeKind.Local).AddTicks(430), "It's cold!", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("8ae40ab9-b47a-447e-bef1-424cf110c48a"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("cda8eb0c-9e2e-4e8e-bd9b-f6969b267da7"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("f1d47b78-f0f0-4489-967a-889f9d2c453f"));

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("af47a135-05fb-486e-896a-b43b07ea1166"), new DateTime(2020, 2, 6, 11, 1, 41, 950, DateTimeKind.Local).AddTicks(6470), "It's hot!", 32 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("3fe335af-dec4-4122-b52a-0b62b5f05b44"), new DateTime(2020, 2, 6, 11, 1, 41, 966, DateTimeKind.Local).AddTicks(7730), "It's chilly...", 10 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("8ceacc18-dd09-4314-855f-7104c9f3b24c"), new DateTime(2020, 2, 6, 11, 1, 41, 966, DateTimeKind.Local).AddTicks(7790), "It's cold!", 0 });
        }
    }
}
