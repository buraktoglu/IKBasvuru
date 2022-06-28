using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKBasvuru.DATA.Migrations
{
    public partial class domainclassupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MilitaryService",
                table: "JobApplication",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MilitaryService",
                table: "JobApplication");
        }
    }
}
