using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKBasvuru.DATA.Migrations
{
    public partial class fieldsubstraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "MilitaryService",
                table: "JobApplication");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "JobApplication",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "JobApplication",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "JobApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "JobApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "MilitaryService",
                table: "JobApplication",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
