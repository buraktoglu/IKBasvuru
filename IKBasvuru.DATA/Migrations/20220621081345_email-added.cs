using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKBasvuru.DATA.Migrations
{
    public partial class emailadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "JobApplication",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "JobApplication");
        }
    }
}
