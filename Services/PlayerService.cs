using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Models;
using Backend_Dev_Eindwerk.Repositories;

namespace Backend_Dev_Eindwerk.Services
{
    public interface IPlayerService
    {
        Task<League> AddLeague(League newLeague);
        Task<Player> AddPlayer(Player newPlayer);
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
        Task<Team> GetTeamByAbbreviation(string abbrev);
        Task<Team> GetTeamByName(string name);
        Task<Team> GetTeamById(Guid id);
        Task<List<Team>> GetTeams();
        Task<List<Team>> GetTeamsByOrigen(string origen);
        Task<Player> UpdatePlayer(Player updatePlayer);
        Task<Team> UpdateTeam(Team updateTeam);
        Task<League> UpdateLeague(League updateLeague);
    }

    public class PlayerService : IPlayerService
    {

        IPlayerRepository _playerRepository;
        ITeamRepository _teamRepository;
        ILeagueRepository _leagueRepository;

        public PlayerService(
            IPlayerRepository playerRepository,
            ITeamRepository teamRepository,
            ILeagueRepository leagueRepository
        )
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _leagueRepository = leagueRepository;
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

    }
}
