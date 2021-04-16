using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Dev_Eindwerk.Migrations
{
    public partial class seeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "Abbreviation", "Name", "Region" },
                values: new object[,]
                {
                    { new Guid("38690d3d-15ca-4aa0-a78c-4dfd911ac6b7"), "LCS", "The League Championship Series", "USA" },
                    { new Guid("f4e30e73-e3ae-4237-9890-e0693acc552b"), "LEC", "The League of Legends European Championship", "Europe" },
                    { new Guid("03b1bd13-fa74-415f-b396-b8c11e7cbaba"), "LCk", "The League Champions Korea", "Korea" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Abbreviation", "LandOfOrigen", "LeagueId", "Name" },
                values: new object[,]
                {
                    { new Guid("5b22b05a-10bd-4e8a-aedd-07638ed0c510"), "TL", "The Netherlands", new Guid("38690d3d-15ca-4aa0-a78c-4dfd911ac6b7"), "Team Liquid" },
                    { new Guid("f8cc2164-dfff-4d27-b8e1-e21b882cc11b"), "FNC", "Great Britain", new Guid("f4e30e73-e3ae-4237-9890-e0693acc552b"), "Fnatic" },
                    { new Guid("900d46ea-0778-43f0-9934-0ed25541a76e"), "DWK", "Korea", new Guid("03b1bd13-fa74-415f-b396-b8c11e7cbaba"), "Damwon Kia" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "DateOfBirth", "Ign", "Name", "Nationality", "TeamId" },
                values: new object[,]
                {
                    { new Guid("e84e806d-3ed6-43d0-8d99-2c107b020510"), "1/1/1995", "Jensen", "Jensen, Nicolaj", "Denmark", new Guid("5b22b05a-10bd-4e8a-aedd-07638ed0c510") },
                    { new Guid("1c12044f-9775-43b4-a6e3-2cc78677deb2"), "9/9/1998", "Armao", "Armao, Jonathan", "USA", new Guid("5b22b05a-10bd-4e8a-aedd-07638ed0c510") },
                    { new Guid("d60c5fd4-8bbe-4b97-9c2b-ca1182d26e72"), "4/30/1995", "Hylissang", "Iliev Galabov, Zdravets", "Bulgaria", new Guid("f8cc2164-dfff-4d27-b8e1-e21b882cc11b") },
                    { new Guid("814ebfff-17ec-4ba8-bdc2-759e616f48c4"), "12/24/1998", "Bwipo", "Rau, Gabriel", "Belgium", new Guid("f8cc2164-dfff-4d27-b8e1-e21b882cc11b") },
                    { new Guid("6a3cc443-c72c-438e-ac51-bd3f28ad9175"), "12/22/1995", "Khan", "Dong-ha, Kim", "Korea", new Guid("900d46ea-0778-43f0-9934-0ed25541a76e") },
                    { new Guid("07cdc167-7e4b-4b65-9bf4-2a70393c003f"), "6/18/2001", "Canyon", "Geon-bu, Kim", "Korea", new Guid("900d46ea-0778-43f0-9934-0ed25541a76e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: new Guid("03b1bd13-fa74-415f-b396-b8c11e7cbaba"));

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: new Guid("38690d3d-15ca-4aa0-a78c-4dfd911ac6b7"));

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: new Guid("f4e30e73-e3ae-4237-9890-e0693acc552b"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("07cdc167-7e4b-4b65-9bf4-2a70393c003f"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("1c12044f-9775-43b4-a6e3-2cc78677deb2"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("6a3cc443-c72c-438e-ac51-bd3f28ad9175"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("814ebfff-17ec-4ba8-bdc2-759e616f48c4"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("d60c5fd4-8bbe-4b97-9c2b-ca1182d26e72"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("e84e806d-3ed6-43d0-8d99-2c107b020510"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("5b22b05a-10bd-4e8a-aedd-07638ed0c510"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("900d46ea-0778-43f0-9934-0ed25541a76e"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("f8cc2164-dfff-4d27-b8e1-e21b882cc11b"));
        }
    }
}
