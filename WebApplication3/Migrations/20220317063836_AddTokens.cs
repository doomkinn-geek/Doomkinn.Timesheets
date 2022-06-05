using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doomkinn.Timesheets.Migrations
{
    public partial class AddTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                schema: "Test",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                schema: "Test",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Test",
                table: "User",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Test",
                table: "User",
                newName: "Role");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                schema: "Test",
                table: "User",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                schema: "Test",
                table: "Employee",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "Test",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "Test",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Username",
                schema: "Test",
                table: "User",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "Token",
                schema: "Test",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "Test",
                table: "User",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                schema: "Test",
                table: "User",
                type: "TEXT",
                nullable: true);
        }
    }
}
