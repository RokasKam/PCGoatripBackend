using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infrastructure.Migrations
{
    public partial class UpdateManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPlaces",
                table: "UserPlaces");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserPlaces",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "UserPlaces",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificationDate",
                table: "UserPlaces",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPlaces",
                table: "UserPlaces",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlaces_PlaceId",
                table: "UserPlaces",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPlaces",
                table: "UserPlaces");

            migrationBuilder.DropIndex(
                name: "IX_UserPlaces_PlaceId",
                table: "UserPlaces");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPlaces");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserPlaces");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "UserPlaces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPlaces",
                table: "UserPlaces",
                columns: new[] { "PlaceId", "UserId" });
        }
    }
}
