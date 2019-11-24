using Microsoft.EntityFrameworkCore.Migrations;

namespace SBRW.Data.Migrations
{
    public partial class UpdateServerStatsStatusToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "server_stats",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "server_stats",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
