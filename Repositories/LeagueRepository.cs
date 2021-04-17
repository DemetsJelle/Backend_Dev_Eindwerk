using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend_Dev_Eindwerk.Data;
using Backend_Dev_Eindwerk.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend_Dev_Eindwerk.Repositories
{
    public interface ILeagueRepository
    {
        Task<League> AddLeague(League newLeague);
        Task<League> GetLeagueByAbbreviation(string abbrev);
        Task<League> GetLeagueById(Guid id);
        Task<League> GetLeagueByRegion(string region);
        Task<List<League>> GetLeagues(bool includeSponsors);
        Task<League> UpdateLeague(League updateleague);
    }

    public class LeagueRepository : ILeagueRepository
    {
        private IEindwerkContext _context;

        public LeagueRepository(IEindwerkContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<List<League>> GetLeagues(bool includeSponsors)
        {
            if(includeSponsors)
                return await _context.Leagues.Include(l => l.LeagueSponsors).ThenInclude(l => l.Sponsor).ToListAsync();
            else
                return await _context.Leagues.ToListAsync();
        }

        public async Task<League> GetLeagueById(Guid id)
        {
            return await _context.Leagues.Where(l => l.LeagueId == id).SingleOrDefaultAsync();
        }

        public async Task<League> GetLeagueByAbbreviation(string abbrev)
        {
            return await _context.Leagues.Where(l => l.Abbreviation == abbrev).SingleOrDefaultAsync();
        }
        public async Task<League> GetLeagueByRegion(string region)
        {
            return await _context.Leagues.Where(l => l.Region == region).SingleOrDefaultAsync();
        }

        public async Task<League> AddLeague(League newLeague)
        {
            await _context.Leagues.AddAsync(newLeague);
            await _context.SaveChangesAsync();
            return newLeague;
        }

        public async Task<League> UpdateLeague(League updateLeague)
        {
            _context.Leagues.Update(updateLeague);
            await _context.SaveChangesAsync();
            return updateLeague;
        }
    }
}
