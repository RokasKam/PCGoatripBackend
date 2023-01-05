using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infrastructure.Migrations
{
    public partial class Place : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlaceName = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    PeopleAmountFrom = table.Column<int>(type: "INTEGER", nullable: false),
                    PeopleAmountTo = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceFrom = table.Column<double>(type: "REAL", nullable: false),
                    PriceTo = table.Column<double>(type: "REAL", nullable: false),
                    VisitDurationFrom = table.Column<double>(type: "REAL", nullable: false),
                    VisitDurationTo = table.Column<double>(type: "REAL", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longtitude = table.Column<double>(type: "REAL", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    RatingAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModificationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Grade = table.Column<double>(type: "REAL", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    ModificationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    ModificationDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    Subject = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }
    }
}
