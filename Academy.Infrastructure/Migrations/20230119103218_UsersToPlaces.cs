using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy.Infrastructure.Migrations
{
    public partial class UsersToPlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlace_Places_PlaceId",
                table: "UserPlace");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlace_Users_UserId",
                table: "UserPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPlace",
                table: "UserPlace");

            migrationBuilder.RenameTable(
                name: "UserPlace",
                newName: "UserPlaces");

            migrationBuilder.RenameIndex(
                name: "IX_UserPlace_UserId",
                table: "UserPlaces",
                newName: "IX_UserPlaces_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPlaces",
                table: "UserPlaces",
                columns: new[] { "PlaceId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaces_Places_PlaceId",
                table: "UserPlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlaces_Users_UserId",
                table: "UserPlaces",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaces_Places_PlaceId",
                table: "UserPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlaces_Users_UserId",
                table: "UserPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPlaces",
                table: "UserPlaces");

            migrationBuilder.RenameTable(
                name: "UserPlaces",
                newName: "UserPlace");

            migrationBuilder.RenameIndex(
                name: "IX_UserPlaces_UserId",
                table: "UserPlace",
                newName: "IX_UserPlace_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPlace",
                table: "UserPlace",
                columns: new[] { "PlaceId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlace_Places_PlaceId",
                table: "UserPlace",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlace_Users_UserId",
                table: "UserPlace",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
