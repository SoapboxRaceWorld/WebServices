using Microsoft.EntityFrameworkCore.Migrations;

namespace SBRW.Data.Migrations
{
    public partial class AddServerGameEndpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameEndpoint",
                table: "servers",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameEndpoint",
                table: "servers");
        }
    }
}
