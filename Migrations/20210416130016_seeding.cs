using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Dev_Eindwerk.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    SponsorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.SponsorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSponsor_SponsorId",
                table: "LeagueSponsor",
                column: "SponsorId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSponsor_Sponsor_SponsorId",
                table: "LeagueSponsor",
                column: "SponsorId",
                principalTable: "Sponsor",
                principalColumn: "SponsorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSponsor_Sponsor_SponsorId",
                table: "LeagueSponsor");

            migrationBuilder.DropTable(
                name: "Sponsor");

            migrationBuilder.DropIndex(
                name: "IX_LeagueSponsor_SponsorId",
                table: "LeagueSponsor");
        }
    }
}
