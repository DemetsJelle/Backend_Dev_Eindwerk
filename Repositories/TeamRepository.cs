using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Data;
using Backend_Dev_Eindwerk.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Dev_Eindwerk.Repositories
{
    public interface ITeamRepository
    {
        Task<Team> AddTeam(Team newTeam);
        Task<Team> GetTeamByAbbreviation(string abbrev, bool includePlayers);
        Task<Team> GetTeamByName(string name, bool includePlayers);
        Task<Team> GetTeamById(Guid id, bool includePlayers);
        Task<List<Team>> GetTeams(bool includePlayesr);
        Task<List<Team>> GetTeamsByOrigen(string origen, bool includePlayers);
        Task<Team> UpdateTeam(Team updateTeam);
    }

    public class TeamRepository : ITeamRepository
    {
        private IEindwerkContext _context;
        public TeamRepository(IEindwerkContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeams(bool includePlayers)
        {
            if(includePlayers)
                return await _context.Teams.Include(r => r.Players).ToListAsync();
            else
                return await _context.Teams.ToListAsync();
        }

        public async Task<Team> GetTeamById(Guid id, bool includePlayers)
        {
            return await _context.Teams.Where(t => t.TeamId == id).SingleOrDefaultAsync();
        }

        public async Task<Team> GetTeamByName(string name, bool includePlayers)
        {
            return await _context.Teams.Where(t => t.Name == name).SingleOrDefaultAsync();
        }

        public async Task<Team> GetTeamByAbbreviation(string abbrev, bool includePlayers)
        {
            return await _context.Teams.Where(t => t.Abbreviation == abbrev).SingleOrDefaultAsync();
        }

        public async Task<List<Team>> GetTeamsByOrigen(string origen, bool includePlayers)
        {
            return await _context.Teams.Where(t => t.LandOfOrigen == origen).ToListAsync();
        }

        public async Task<Team> AddTeam(Team newTeam)
        {
            await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();
            return newTeam;
        }

        public async Task<Team> UpdateTeam(Team updateTeam)
        {
            _context.Teams.Update(updateTeam);
            await _context.SaveChangesAsync();
            return updateTeam;
        }
    }
}
