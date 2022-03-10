using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIConfiguration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetLogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetLogs", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "NetLogs",
                columns: new[] { "ID", "Date", "Destination", "Port", "Source", "UserAgent" },
                values: new object[] { new Guid("ba0b2e46-f8ee-4c49-84ef-59877b6480c4"), new DateTime(2021, 8, 17, 15, 14, 56, 0, DateTimeKind.Local), "239.136.66.100", 55874, "0.196.36.4", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_6_2) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/13.0.782.107 Safari/535.1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetLogs");
        }
    }
}
