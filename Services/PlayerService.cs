using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend_Dev_Eindwerk.DTO;
using Backend_Dev_Eindwerk.Models;
using Backend_Dev_Eindwerk.Repositories;

namespace Backend_Dev_Eindwerk.Services
{
    public interface IPlayerService
    {
        Task<League> AddLeague(League newLeague);
        Task<Player> AddPlayer(Player newPlayer);
        Task<SponsorDTO> AddSponsor(SponsorDTO sponsor);
        Task<Team> AddTeam(Team newTeam);
        Task<League> GetLeagueByAbbreviation(string abbrev);
        Task<League> GetLeagueById(Guid id);
        Task<League> GetLeagueByRegion(string region);
        Task<List<League>> GetLeagues();
        Task<Player> GetPlayerById(Guid id);
        Task<Player> GetPlayerByIgn(string ign);
        Task<Player> GetPlayerByName(string name);
        Task<List<Player>> GetPlayers();
        Task<List<Player>> GetPlayersByNationality(string nationality);
        Task<Sponsor> GetSponsorById(Guid id);
        Task<Sponsor> GetSponsorByName(string name);
        Task<List<Sponsor>> GetSponsors();
        Task<Team> GetTeamByAbbreviation(string abbrev);
        Task<Team> GetTeamById(Guid id);
        Task<Team> GetTeamByName(string name);
        Task<List<Team>> GetTeams();
        Task<List<Team>> GetTeamsByOrigen(string origen);
        Task<League> UpdateLeague(League updateLeague);
        Task<Player> UpdatePlayer(Player updatePlayer);
        Task<Team> UpdateTeam(Team updateTeam);
    }

    public class PlayerService : IPlayerService
    {

        private IPlayerRepository _playerRepository;
        private ITeamRepository _teamRepository;
        private ILeagueRepository _leagueRepository;
        private ISponsorRepository _sponsorRepository;
        private IMapper _mapper;

        public PlayerService(
            IMapper mapper,
            IPlayerRepository playerRepository,
            ITeamRepository teamRepository,
            ILeagueRepository leagueRepository,
            ISponsorRepository sponsorRepository
        )
        {
            _mapper = mapper;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
            _sponsorRepository = sponsorRepository;
        }

        #region Player
        public async Task<List<Player>> GetPlayers()
        {
            return await _playerRepository.GetPlayers();
        }

        public async Task<Player> GetPlayerById(Guid id)
        {
            return await _playerRepository.GetPlayerById(id);
        }

        public async Task<Player> GetPlayerByIgn(string ign)
        {
            return await _playerRepository.GetPlayerByIGN(ign);
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            return await _playerRepository.GetPlayerByName(name);
        }

        public async Task<List<Player>> GetPlayersByNationality(string nationality)
        {
            return await _playerRepository.GetPlayersByNationality(nationality);
        }

        public async Task<Player> AddPlayer(Player newPlayer)
        {
            return await _playerRepository.AddPlayer(newPlayer);
        }
        public async Task<Player> UpdatePlayer(Player updatePlayer)
        {
            return await _playerRepository.UpdatePlayer(updatePlayer);
        }
        #endregion

        #region Teams
        public async Task<List<Team>> GetTeams()
        {
            return await _teamRepository.GetTeams();
        }

        public async Task<List<Team>> GetTeamsByOrigen(string origen)
        {
            return await _teamRepository.GetTeamsByOrigen(origen);
        }

        public async Task<Team> GetTeamById(Guid id)
        {
            return await _teamRepository.GetTeamById(id);
        }

        public async Task<Team> GetTeamByAbbreviation(string abbrev)
        {
            return await _teamRepository.GetTeamByAbbreviation(abbrev);
        }

        public async Task<Team> GetTeamByName(string name)
        {
            return await _teamRepository.GetTeamByName(name);
        }

        public async Task<Team> AddTeam(Team newTeam)
        {
            return await _teamRepository.AddTeam(newTeam);
        }

        public async Task<Team> UpdateTeam(Team updateTeam)
        {
            return await _teamRepository.UpdateTeam(updateTeam);
        }
        #endregion

        #region Leagues
        public async Task<List<League>> GetLeagues()
        {
            return await _leagueRepository.GetLeagues();
        }
        public async Task<League> GetLeagueById(Guid id)
        {
            return await _leagueRepository.GetLeagueById(id);
        }

        public async Task<League> GetLeagueByAbbreviation(string abbrev)
        {
            return await _leagueRepository.GetLeagueByAbbreviation(abbrev);
        }

        public async Task<League> GetLeagueByRegion(string region)
        {
            return await _leagueRepository.GetLeagueByRegion(region);
        }

        public async Task<League> AddLeague(League newLeague)
        {
            return await _leagueRepository.AddLeague(newLeague);
        }

        public async Task<League> UpdateLeague(League updateLeague)
        {
            return await _leagueRepository.UpdateLeague(updateLeague);
        }
        #endregion

        #region  Sponsor
        public async Task<List<Sponsor>> GetSponsors()
        {
            return await _sponsorRepository.GetSponsors();
        }

        public async Task<Sponsor> GetSponsorById(Guid id)
        {
            return await _sponsorRepository.GetSponsorById(id);
        }

        public async Task<Sponsor> GetSponsorByName(string name)
        {
            return await _sponsorRepository.GetSponsorByName(name);
        }

        public async Task<SponsorDTO> AddSponsor(SponsorDTO sponsor)
        {
            try
            {

                Sponsor newSponsor = _mapper.Map<Sponsor>(sponsor);

                newSponsor.LeagueSponsor = new List<LeagueSponsor>();
                foreach (var leagueId in sponsor.Leagues)
                {
                    newSponsor.LeagueSponsor.Add(new LeagueSponsor() { LeaugeId = leagueId });
                }
                await _sponsorRepository.AddSponsor(newSponsor);

                return sponsor;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
