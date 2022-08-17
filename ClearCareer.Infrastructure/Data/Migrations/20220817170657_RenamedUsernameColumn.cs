using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClearCareer.Infrastructure.Data.Migrations
{
    public partial class RenamedUsernameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "ApplicationUsers",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "ApplicationUsers",
                newName: "UserName");
        }
    }
}
