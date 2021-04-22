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
        Task<List<LeagueDTO>> GetLeagues(bool includeSponsors);
        Task<Player> GetPlayerById(Guid id);
        Task<Player> GetPlayerByIgn(string ign);
        Task<Player> GetPlayerByName(string name);
        Task<List<Player>> GetPlayers(bool includeTeam);
        Task<List<Player>> GetPlayersByNationality(string nationality);
        Task<Sponsor> GetSponsorById(Guid id);
        Task<Sponsor> GetSponsorByName(string name);
        Task<List<Sponsor>> GetSponsors(bool includeLeagues);
        Task<Team> GetTeamByAbbreviation(string abbrev, bool includePlayers);
        Task<Team> GetTeamById(Guid id, bool includePlayers);
        Task<Team> GetTeamByName(string name, bool includePlayers);
        Task<List<Team>> GetTeams(bool includePlayers);
        Task<List<Team>> GetTeamsByOrigen(string origen, bool includePlayers);
        Task<League> UpdateLeague(League updateLeague);
        Task<Player> UpdatePlayer(Player updatePlayer);
        Task <SponsorDTO> UpdateSponsor(SponsorDTO updateSponsor);
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
        public async Task<List<Player>> GetPlayers(bool includeTeam)
        {
            return await _playerRepository.GetPlayers(includeTeam);
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
        public async Task<List<Team>> GetTeams(bool includePlayers)
        {
            return await _teamRepository.GetTeams(includePlayers);
        }

        public async Task<List<Team>> GetTeamsByOrigen(string origen, bool includePlayers)
        {
            return await _teamRepository.GetTeamsByOrigen(origen, includePlayers);
        }

        public async Task<Team> GetTeamById(Guid id, bool includePlayers)
        {
            return await _teamRepository.GetTeamById(id, includePlayers);
        }

        public async Task<Team> GetTeamByAbbreviation(string abbrev, bool includePlayers)
        {
            return await _teamRepository.GetTeamByAbbreviation(abbrev, includePlayers);
        }

        public async Task<Team> GetTeamByName(string name, bool includePlayers)
        {
            return await _teamRepository.GetTeamByName(name, includePlayers);
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
        public async Task<List<LeagueDTO>> GetLeagues(bool includeSponsors)
        {
            return _mapper.Map<List<LeagueDTO>>(await _leagueRepository.GetLeagues(includeSponsors));
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
        public async Task<List<Sponsor>> GetSponsors(bool includeLeagues)
        {
            return await _sponsorRepository.GetSponsors(includeLeagues);
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

                newSponsor.LeagueSponsors = new List<LeagueSponsor>();
                foreach (var leagueId in sponsor.Leagues)
                {
                    newSponsor.LeagueSponsors.Add(new LeagueSponsor() { LeagueId = leagueId });
                }
                await _sponsorRepository.AddSponsor(newSponsor);

                return sponsor;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<SponsorDTO> UpdateSponsor(SponsorDTO sponsor)
        {
            try
            {
                Sponsor updateSponsor = _mapper.Map<Sponsor>(sponsor);

                updateSponsor.LeagueSponsors = new List<LeagueSponsor>();
                foreach (var leagueId in sponsor.Leagues)
                {
                    updateSponsor.LeagueSponsors.Add(new LeagueSponsor() { LeagueId = leagueId });
                }
                await _sponsorRepository.UpdateSponsor(updateSponsor);

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
