using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKBasvuru.DATA.Migrations
{
    public partial class domainclassupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatus",
                table: "JobApplication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "JobApplication",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "JobApplication");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "JobApplication");
        }
    }
}
