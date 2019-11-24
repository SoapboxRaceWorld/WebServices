using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBRW.Data.Migrations
{
    public partial class AddStatsModelAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "server_stats",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServerID = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TrackedAt = table.Column<DateTime>(nullable: false),
                    PlayersOnline = table.Column<int>(nullable: false),
                    PlayersRegistered = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_server_stats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_server_stats_servers_ServerID",
                        column: x => x.ServerID,
                        principalTable: "servers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_server_stats_ServerID",
                table: "server_stats",
                column: "ServerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "server_stats");
        }
    }
}
