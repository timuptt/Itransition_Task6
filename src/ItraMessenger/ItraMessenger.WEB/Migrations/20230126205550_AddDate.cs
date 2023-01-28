using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItraMessenger.WEB.Migrations
{
    /// <inheritdoc />
    public partial class AddDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Messages",
                newName: "SenderName");

            migrationBuilder.RenameColumn(
                name: "RecipientUserId",
                table: "Messages",
                newName: "RevieverName");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RevieverName",
                table: "Messages",
                newName: "RecipientUserId");
        }
    }
}
