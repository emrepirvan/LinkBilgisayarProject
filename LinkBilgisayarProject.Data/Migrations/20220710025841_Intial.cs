using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkBilgisayarProject.Data.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    City = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommercialActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ServiceDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialActivities_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeeklyReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReportUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyReports_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "Email", "Name", "PhoneNumber", "PhotoUrl", "Surname" },
                values: new object[,]
                {
                    { 1, "Batı Ağıl", "Aragorn@gmail.com", "Aragorn", "12312312", "aragorn.img", "Arathorn" },
                    { 2, "Londra", "expecto@gmail.com", "Harry", "02222222", "harry.img", "Potter" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { 1, true, "12345", "Gandalf" },
                    { 2, false, "987654", "Frodo" },
                    { 3, true, "00000", "Gimli" }
                });

            migrationBuilder.InsertData(
                table: "CommercialActivities",
                columns: new[] { "Id", "ActivityDate", "CustomerId", "Price", "ServiceDescription" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), 1, 8800m, "Kırık Kılıç onarıldı" },
                    { 2, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), 2, 2300m, "Baykuş satıldı" }
                });

            migrationBuilder.InsertData(
                table: "WeeklyReports",
                columns: new[] { "Id", "CustomerId", "ReportUrl" },
                values: new object[,]
                {
                    { 1, 1, "AragornUrlReport" },
                    { 2, 2, "HarryReport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommercialActivities_CustomerId",
                table: "CommercialActivities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReports_CustomerId",
                table: "WeeklyReports",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommercialActivities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WeeklyReports");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
