using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialData.API.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("0880d3ec-92cd-469f-a572-0b883869f74e"), new DateTime(2020, 2, 5, 16, 3, 53, 571, DateTimeKind.Local).AddTicks(2020), "It's hot!", 32 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("7e9012c6-1387-48f3-a2a2-c07a3b330eff"), new DateTime(2020, 2, 5, 16, 3, 53, 587, DateTimeKind.Local).AddTicks(2610), "It's chilly...", 10 });

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[] { new Guid("d2757829-b559-49fb-9dac-78f2ae0cb16b"), new DateTime(2020, 2, 5, 16, 3, 53, 587, DateTimeKind.Local).AddTicks(2660), "It's cold!", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0880d3ec-92cd-469f-a572-0b883869f74e"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("7e9012c6-1387-48f3-a2a2-c07a3b330eff"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("d2757829-b559-49fb-9dac-78f2ae0cb16b"));
        }
    }
}
