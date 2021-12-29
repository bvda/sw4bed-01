using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace multi_container.migrations
{
    public partial class NewSummaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewSummary",
                table: "WeatherForecast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewSummary",
                table: "WeatherForecast");
        }
    }
}
