using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infrastructure.Migrations
{
    public partial class EntityConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')",
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificationDate",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')",
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModificationDate",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATE('now')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Students");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValueSql: "DATE('now')");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Students",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValueSql: "DATE('now')");
        }
    }
}
