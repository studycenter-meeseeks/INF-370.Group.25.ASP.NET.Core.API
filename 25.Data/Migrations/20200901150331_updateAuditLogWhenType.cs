using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _25.Data.Migrations
{
    public partial class updateAuditLogWhenType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "What",
                table: "AuditLogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "When",
                table: "AuditLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "What",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "When",
                table: "AuditLogs");
        }
    }
}
