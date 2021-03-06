using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Data;
using Backend_Dev_Eindwerk.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Dev_Eindwerk.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player> AddPlayer(Player newPlayer);
        Task<Player> GetPlayerById(Guid Id);
        Task<Player> GetPlayerByIGN(string ign);
        Task<Player> GetPlayerByName(string name);
        Task<List<Player>> GetPlayers(bool includeTeam);
        Task<List<Player>> GetPlayersByNationality(string nationality);
        Task<Player> UpdatePlayer(Player updatePlayer);
    }

    public class PlayerRepository : IPlayerRepository
    {

        private IEindwerkContext _context;
        public PlayerRepository(IEindwerkContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetPlayers(bool includeTeam)
        {
            if(includeTeam)
                return await _context.Players.Include(p => p.team).ToListAsync();
            else
                return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetPlayerById(Guid id)
        {
            return await _context.Players.Where(p => p.PlayerId == id).SingleOrDefaultAsync();
        }

        public async Task<Player> GetPlayerByIGN(string ign)
        {
            return await _context.Players.Where(p => p.Ign == ign).SingleOrDefaultAsync();
        }
        public async Task<Player> GetPlayerByName(string name)
        {
            return await _context.Players.Where(p => p.Name == name).SingleOrDefaultAsync();
        }

        public async Task<List<Player>> GetPlayersByNationality(string nationality)
        {
            return await _context.Players.Where(p => p.Nationality == nationality).ToListAsync();
        }

        public async Task<Player> AddPlayer(Player newPlayer)
        {
            await _context.Players.AddAsync(newPlayer);
            await _context.SaveChangesAsync();
            return newPlayer;
        }

        public async Task<Player> UpdatePlayer(Player updatePlayer)
        {
            _context.Players.Update(updatePlayer);
            await _context.SaveChangesAsync();
            return updatePlayer;
        }
    }
}
