using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Data;
using Backend_Dev_Eindwerk.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Dev_Eindwerk.Repositories
{
    public interface ISponsorRepository
    {
        Task<Sponsor> AddSponsor(Sponsor newSponsor);
        Task<Sponsor> GetSponsorByName(string name);
        Task<Sponsor> GetSponsorById(Guid id);
        Task<List<Sponsor>> GetSponsors(bool includeLeagues);
        Task<Sponsor> UpdateSponsor(Sponsor updateSponsor);
    }

    public class SponsorRepository : ISponsorRepository
    {
        private IEindwerkContext _context;
        public SponsorRepository(IEindwerkContext context)
        {
            _context = context;
        }

        public async Task<List<Sponsor>> GetSponsors(bool includeLeagues)
        {
            if(includeLeagues)
                return await _context.Sponsor.Include(s => s.LeagueSponsors).ToListAsync();
            else
                return await _context.Sponsor.ToListAsync();
        }

        public async Task<Sponsor> GetSponsorById(Guid id)
        {
            return await _context.Sponsor.Where(l => l.SponsorId == id).SingleOrDefaultAsync();
        }

        public async Task<Sponsor> GetSponsorByName(string name)
        {
            return await _context.Sponsor.Where(l => l.Name == name).SingleOrDefaultAsync();
        }

        public async Task<Sponsor> AddSponsor(Sponsor newSponsor)
        {
            await _context.Sponsor.AddAsync(newSponsor);
            await _context.SaveChangesAsync();
            return newSponsor;
        }

        public async Task<Sponsor> UpdateSponsor(Sponsor updateSponsor)
        {
            _context.Sponsor.Update(updateSponsor);
            await _context.SaveChangesAsync();
            return updateSponsor;
        }
    }
}
