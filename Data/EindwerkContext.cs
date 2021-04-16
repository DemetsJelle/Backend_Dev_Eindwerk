using System.Threading;
using System;
using Backend_Dev_Eindwerk.Configuration;
using Backend_Dev_Eindwerk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Backend_Dev_Eindwerk.Data
{
    public interface IEindwerkContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<League> Leagues { get; set; }
        DbSet<Sponsor> Sponsor{get;set;}
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }

    public class EindwerkContext : DbContext, IEindwerkContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Sponsor> Sponsor {get;set;}
        private ConnectionStrings _connectionStrings;

        public EindwerkContext(DbContextOptions<EindwerkContext> options, IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionStrings.SQL);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeagueSponsor>().HasKey(ls => new {ls.LeaugeId, ls.SponsorId});

            modelBuilder.Entity<Team>().HasData(new Team() { TeamId = Guid.Parse("5b22b05a-10bd-4e8a-aedd-07638ed0c510"), Name = "Team Liquid", Abbreviation = "TL", LandOfOrigen = "The Netherlands", LeagueId = Guid.Parse("38690d3d-15ca-4aa0-a78c-4dfd911ac6b7") });
            modelBuilder.Entity<Team>().HasData(new Team() { TeamId = Guid.Parse("f8cc2164-dfff-4d27-b8e1-e21b882cc11b"), Name = "Fnatic", Abbreviation = "FNC", LandOfOrigen = "Great Britain", LeagueId = Guid.Parse("f4e30e73-e3ae-4237-9890-e0693acc552b") });
            modelBuilder.Entity<Team>().HasData(new Team() { TeamId = Guid.Parse("900d46ea-0778-43f0-9934-0ed25541a76e"), Name = "Damwon Kia", Abbreviation = "DWK", LandOfOrigen = "Korea", LeagueId = Guid.Parse("03b1bd13-fa74-415f-b396-b8c11e7cbaba")});

            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.Parse("e84e806d-3ed6-43d0-8d99-2c107b020510"), Name = "Jensen, Nicolaj", Ign = "Jensen", DateOfBirth = "1/1/1995", Nationality = "Denmark", TeamId = Guid.Parse("5b22b05a-10bd-4e8a-aedd-07638ed0c510") });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.Parse("1c12044f-9775-43b4-a6e3-2cc78677deb2"), Name = "Armao, Jonathan", Ign = "Armao", DateOfBirth = "9/9/1998", Nationality = "USA", TeamId = Guid.Parse("5b22b05a-10bd-4e8a-aedd-07638ed0c510") });

            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.Parse("d60c5fd4-8bbe-4b97-9c2b-ca1182d26e72"), Name = "Iliev Galabov, Zdravets", Ign = "Hylissang", DateOfBirth = "4/30/1995", Nationality = "Bulgaria", TeamId = Guid.Parse("f8cc2164-dfff-4d27-b8e1-e21b882cc11b") });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.Parse("814ebfff-17ec-4ba8-bdc2-759e616f48c4"), Name = "Rau, Gabriel", Ign = "Bwipo", DateOfBirth = "12/24/1998", Nationality = "Belgium", TeamId = Guid.Parse("f8cc2164-dfff-4d27-b8e1-e21b882cc11b") });

            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.Parse("6a3cc443-c72c-438e-ac51-bd3f28ad9175"), Name = "Dong-ha, Kim", Ign = "Khan", DateOfBirth = "12/22/1995", Nationality = "Korea", TeamId = Guid.Parse("900d46ea-0778-43f0-9934-0ed25541a76e") });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.Parse("07cdc167-7e4b-4b65-9bf4-2a70393c003f"), Name = "Geon-bu, Kim", Ign = "Canyon", DateOfBirth = "6/18/2001", Nationality = "Korea", TeamId = Guid.Parse("900d46ea-0778-43f0-9934-0ed25541a76e") });

            modelBuilder.Entity<League>().HasData(new League() { LeagueId = Guid.Parse("38690d3d-15ca-4aa0-a78c-4dfd911ac6b7"), Name = "The League Championship Series", Abbreviation = "LCS", Region = "USA" });
            modelBuilder.Entity<League>().HasData(new League() { LeagueId = Guid.Parse("f4e30e73-e3ae-4237-9890-e0693acc552b"), Name = "The League of Legends European Championship", Abbreviation = "LEC", Region = "Europe" });
            modelBuilder.Entity<League>().HasData(new League() { LeagueId = Guid.Parse("03b1bd13-fa74-415f-b396-b8c11e7cbaba"), Name = "The League Champions Korea", Abbreviation = "LCk", Region = "Korea" });
        }

    }
}
