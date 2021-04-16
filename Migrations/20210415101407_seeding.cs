using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Dev_Eindwerk.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "Abbreviation", "Name", "Region" },
                values: new object[,]
                {
                    { new Guid("3b16aaa8-a02a-4eba-a9b0-32ca2fec2024"), "LCS", "The League Championship Series", "USA" },
                    { new Guid("f6fa6f75-3510-4935-aa2d-a92243998d57"), "LEC", "The League of Legends European Championship", "Europe" },
                    { new Guid("ec8b4cb9-67f8-4dc6-984b-df5ba7e06a9d"), "LCk", "The League Champions Korea", "Korea" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "DateOfBirth", "Ign", "Name", "Nationality" },
                values: new object[,]
                {
                    { new Guid("4f7a6b47-0444-4f8e-b4dc-e9755aef2baf"), "1/1/1995", "Jensen", "Jensen, Nicolaj", "Denmark" },
                    { new Guid("763496f4-26eb-4ba0-84d4-213cac6c021a"), "6/22/1994", "CoreJJ", "Jo, Yong In", "Korea" },
                    { new Guid("4fba20d4-c02f-4e70-b0a5-e7c5164d00d1"), "9/9/1998", "Armao", "Armao, Jonathan", "USA" },
                    { new Guid("0a1c11c3-416d-4406-b1a8-d2e9da3211c7"), "4/30/1995", "Hylissang", "Iliev Galabov, Zdravets", "Bulgaria" },
                    { new Guid("cb8aa374-c49c-415e-b11a-cde8c1e058fb"), "12/24/1998", "Bwipo", "Rau, Gabriel", "Belgium" },
                    { new Guid("5a43989e-c81f-4ad6-993f-63cccb9d905e"), "12/16/1999", "Upset", "Lipp, Elias", "Germany" },
                    { new Guid("ed5cc04a-90aa-4cce-8325-a5da87c57fe4"), "3/18/1999", "Ghost", "Yong-jun, Jang", "Korea" },
                    { new Guid("b6430774-60ae-4953-9076-950a0258ae38"), "12/22/1995", "Khan", "Dong-ha, Kim", "Korea" },
                    { new Guid("ff636ed9-4702-49a7-935d-5d2aa55acc3c"), "6/18/2001", "Canyon", "Geon-bu, Kim", "Korea" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Abbreviation", "LandOfOrigen", "LeagueId", "Name" },
                values: new object[,]
                {
                    { new Guid("d3524a34-c7d7-4868-8093-95f5497f7f3d"), "TL", "The Netherlands", new Guid("00000000-0000-0000-0000-000000000000"), "Team Liquid" },
                    { new Guid("5ff63c93-a006-49a8-98c5-8b0a006e9383"), "FNC", "Great Britain", new Guid("00000000-0000-0000-0000-000000000000"), "Fnatic" },
                    { new Guid("be9c1a3b-37de-42c4-bfa9-ceab59930904"), "DWK", "Korea", new Guid("00000000-0000-0000-0000-000000000000"), "Damwon Kia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: new Guid("3b16aaa8-a02a-4eba-a9b0-32ca2fec2024"));

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: new Guid("ec8b4cb9-67f8-4dc6-984b-df5ba7e06a9d"));

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: new Guid("f6fa6f75-3510-4935-aa2d-a92243998d57"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("0a1c11c3-416d-4406-b1a8-d2e9da3211c7"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("4f7a6b47-0444-4f8e-b4dc-e9755aef2baf"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("4fba20d4-c02f-4e70-b0a5-e7c5164d00d1"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("5a43989e-c81f-4ad6-993f-63cccb9d905e"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("763496f4-26eb-4ba0-84d4-213cac6c021a"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("b6430774-60ae-4953-9076-950a0258ae38"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("cb8aa374-c49c-415e-b11a-cde8c1e058fb"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("ed5cc04a-90aa-4cce-8325-a5da87c57fe4"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: new Guid("ff636ed9-4702-49a7-935d-5d2aa55acc3c"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("5ff63c93-a006-49a8-98c5-8b0a006e9383"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("be9c1a3b-37de-42c4-bfa9-ceab59930904"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("d3524a34-c7d7-4868-8093-95f5497f7f3d"));
        }
    }
}
