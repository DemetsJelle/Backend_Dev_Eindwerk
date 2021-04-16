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
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }

    public class EindwerkContext : DbContext, IEindwerkContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<League> Leagues { get; set; }
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
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Jensen, Nicolaj", Ign = "Jensen", DateOfBirth = "1/1/1995", Nationality = "Denmark" });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Jo, Yong In", Ign = "CoreJJ", DateOfBirth = "6/22/1994", Nationality = "Korea" });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Armao, Jonathan", Ign = "Armao", DateOfBirth = "9/9/1998", Nationality = "USA" });

            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Iliev Galabov, Zdravets", Ign = "Hylissang", DateOfBirth = "4/30/1995", Nationality = "Bulgaria" });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Rau, Gabriel", Ign = "Bwipo", DateOfBirth = "12/24/1998", Nationality = "Belgium" });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Lipp, Elias", Ign = "Upset", DateOfBirth = "12/16/1999", Nationality = "Germany" });

            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Yong-jun, Jang", Ign = "Ghost", DateOfBirth = "3/18/1999", Nationality = "Korea" });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Dong-ha, Kim", Ign = "Khan", DateOfBirth = "12/22/1995", Nationality = "Korea" });
            modelBuilder.Entity<Player>().HasData(new Player() { PlayerId = Guid.NewGuid(), Name = "Geon-bu, Kim", Ign = "Canyon", DateOfBirth = "6/18/2001", Nationality = "Korea" });


            modelBuilder.Entity<Team>().HasData(new Team() { TeamId = Guid.NewGuid(), Name = "Team Liquid", Abbreviation = "TL", LandOfOrigen = "The Netherlands" });
            modelBuilder.Entity<Team>().HasData(new Team() { TeamId = Guid.NewGuid(), Name = "Fnatic", Abbreviation = "FNC", LandOfOrigen = "Great Britain" });
            modelBuilder.Entity<Team>().HasData(new Team() { TeamId = Guid.NewGuid(), Name = "Damwon Kia", Abbreviation = "DWK", LandOfOrigen = "Korea" });

            modelBuilder.Entity<League>().HasData(new League() { LeagueId = Guid.NewGuid(), Name = "The League Championship Series", Abbreviation = "LCS", Region = "USA" });
            modelBuilder.Entity<League>().HasData(new League() { LeagueId = Guid.NewGuid(), Name = "The League of Legends European Championship", Abbreviation = "LEC", Region = "Europe" });
            modelBuilder.Entity<League>().HasData(new League() { LeagueId = Guid.NewGuid(), Name = "The League Champions Korea", Abbreviation = "LCk", Region = "Korea" });

        }

    }
}
