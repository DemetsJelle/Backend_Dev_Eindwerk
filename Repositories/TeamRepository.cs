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
        Task<Team> GetTeamByAbbreviation(string abbrev);
        Task<Team> GetTeamByName(string name);
        Task<Team> GetTeamById(Guid id);
        Task<List<Team>> GetTeams();
        Task<List<Team>> GetTeamsByOrigen(string origen);
        Task<Team> UpdateTeam(Team updateTeam);
    }

    public class TeamRepository : ITeamRepository
    {
        private IEindwerkContext _context;
        public TeamRepository(IEindwerkContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> GetTeamById(Guid id)
        {
            return await _context.Teams.Where(t => t.TeamId == id).SingleOrDefaultAsync();
        }

        public async Task<Team> GetTeamByName(string name)
        {
            return await _context.Teams.Where(t => t.Name == name).SingleOrDefaultAsync();
        }

        public async Task<Team> GetTeamByAbbreviation(string abbrev)
        {
            return await _context.Teams.Where(t => t.Abbreviation == abbrev).SingleOrDefaultAsync();
        }

        public async Task<List<Team>> GetTeamsByOrigen(string origen)
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
