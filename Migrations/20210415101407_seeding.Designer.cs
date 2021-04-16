﻿// <auto-generated />
using System;
using Backend_Dev_Eindwerk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend_Dev_Eindwerk.Migrations
{
    [DbContext(typeof(EindwerkContext))]
    [Migration("20210415101407_seeding")]
    partial class seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Backend_Dev_Eindwerk.Models.League", b =>
                {
                    b.Property<Guid>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeagueId");

                    b.ToTable("Leagues");

                    b.HasData(
                        new
                        {
                            LeagueId = new Guid("3b16aaa8-a02a-4eba-a9b0-32ca2fec2024"),
                            Abbreviation = "LCS",
                            Name = "The League Championship Series",
                            Region = "USA"
                        },
                        new
                        {
                            LeagueId = new Guid("f6fa6f75-3510-4935-aa2d-a92243998d57"),
                            Abbreviation = "LEC",
                            Name = "The League of Legends European Championship",
                            Region = "Europe"
                        },
                        new
                        {
                            LeagueId = new Guid("ec8b4cb9-67f8-4dc6-984b-df5ba7e06a9d"),
                            Abbreviation = "LCk",
                            Name = "The League Champions Korea",
                            Region = "Korea"
                        });
                });

            modelBuilder.Entity("Backend_Dev_Eindwerk.Models.Player", b =>
                {
                    b.Property<Guid>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = new Guid("4f7a6b47-0444-4f8e-b4dc-e9755aef2baf"),
                            DateOfBirth = "1/1/1995",
                            Ign = "Jensen",
                            Name = "Jensen, Nicolaj",
                            Nationality = "Denmark"
                        },
                        new
                        {
                            PlayerId = new Guid("763496f4-26eb-4ba0-84d4-213cac6c021a"),
                            DateOfBirth = "6/22/1994",
                            Ign = "CoreJJ",
                            Name = "Jo, Yong In",
                            Nationality = "Korea"
                        },
                        new
                        {
                            PlayerId = new Guid("4fba20d4-c02f-4e70-b0a5-e7c5164d00d1"),
                            DateOfBirth = "9/9/1998",
                            Ign = "Armao",
                            Name = "Armao, Jonathan",
                            Nationality = "USA"
                        },
                        new
                        {
                            PlayerId = new Guid("0a1c11c3-416d-4406-b1a8-d2e9da3211c7"),
                            DateOfBirth = "4/30/1995",
                            Ign = "Hylissang",
                            Name = "Iliev Galabov, Zdravets",
                            Nationality = "Bulgaria"
                        },
                        new
                        {
                            PlayerId = new Guid("cb8aa374-c49c-415e-b11a-cde8c1e058fb"),
                            DateOfBirth = "12/24/1998",
                            Ign = "Bwipo",
                            Name = "Rau, Gabriel",
                            Nationality = "Belgium"
                        },
                        new
                        {
                            PlayerId = new Guid("5a43989e-c81f-4ad6-993f-63cccb9d905e"),
                            DateOfBirth = "12/16/1999",
                            Ign = "Upset",
                            Name = "Lipp, Elias",
                            Nationality = "Germany"
                        },
                        new
                        {
                            PlayerId = new Guid("ed5cc04a-90aa-4cce-8325-a5da87c57fe4"),
                            DateOfBirth = "3/18/1999",
                            Ign = "Ghost",
                            Name = "Yong-jun, Jang",
                            Nationality = "Korea"
                        },
                        new
                        {
                            PlayerId = new Guid("b6430774-60ae-4953-9076-950a0258ae38"),
                            DateOfBirth = "12/22/1995",
                            Ign = "Khan",
                            Name = "Dong-ha, Kim",
                            Nationality = "Korea"
                        },
                        new
                        {
                            PlayerId = new Guid("ff636ed9-4702-49a7-935d-5d2aa55acc3c"),
                            DateOfBirth = "6/18/2001",
                            Ign = "Canyon",
                            Name = "Geon-bu, Kim",
                            Nationality = "Korea"
                        });
                });

            modelBuilder.Entity("Backend_Dev_Eindwerk.Models.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandOfOrigen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LeagueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = new Guid("d3524a34-c7d7-4868-8093-95f5497f7f3d"),
                            Abbreviation = "TL",
                            LandOfOrigen = "The Netherlands",
                            LeagueId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Team Liquid"
                        },
                        new
                        {
                            TeamId = new Guid("5ff63c93-a006-49a8-98c5-8b0a006e9383"),
                            Abbreviation = "FNC",
                            LandOfOrigen = "Great Britain",
                            LeagueId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Fnatic"
                        },
                        new
                        {
                            TeamId = new Guid("be9c1a3b-37de-42c4-bfa9-ceab59930904"),
                            Abbreviation = "DWK",
                            LandOfOrigen = "Korea",
                            LeagueId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Damwon Kia"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
