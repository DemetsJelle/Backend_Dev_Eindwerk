using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Data;
using Backend_Dev_Eindwerk.Models;
using Backend_Dev_Eindwerk.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Dev_Eindwerk.Controllers
{
    [ApiController]
    [Route("api")]
    public class PlayerController : ControllerBase
    {
        
        private IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        #region Player
        [HttpGet]
        [Route("players")]
        public async Task<List<Player>> GetPlayers()
        {
            return await _playerService.GetPlayers();
        }

        [HttpGet]
        [Route("player/id/{id}")]
        public async Task<Player> GetPlayerById(Guid id)
        {
            return await _playerService.GetPlayerById(id);
        }

        [HttpGet]
        [Route("player/ign/{ign}")]
        public async Task<Player> GetPlayerByIgn(string ign)
        {
            return await _playerService.GetPlayerByIgn(ign);
        }

        [HttpGet]
        [Route("player/name/{name}")]
        public async Task<Player> GetPlayerByName(string name)
        {
            return await _playerService.GetPlayerByName(name);
        }

        [HttpGet]
        [Route("players/origen/{nationality}")]
        public async Task<List<Player>> GetPlayersByNationality(string nationality)
        {
            return await _playerService.GetPlayersByNationality(nationality);
        }

        [HttpPost]
        [Route("player")]
        public async Task<ActionResult<Player>> AddPlayer(Player newPlayer)
        {
            try
            {
               return await _playerService.AddPlayer(newPlayer);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region  Teams
        [HttpGet]
        [Route("Teams")]
        public async Task<List<Team>> GetTeams()
        {
            return await _playerService.GetTeams();
        }

        [HttpGet]
        [Route("Team/origen/{origen}")]
        public async Task<List<Team>> GetTeamsByOrigen(string origen)
        {
            return await _playerService.GetTeamsByOrigen(origen);
        }

        [HttpGet]
        [Route("Team/id/{id}")]
        public async Task<Team> GetTeamsById(Guid id)
        {
            return await _playerService.GetTeamById(id);
        }

        [HttpGet]
        [Route("Team/Abbreviation/{abbreviation}")]
        public async Task<Team> GetTeamsByAbbreviation(string abbreviation)
        {
            return await _playerService.GetTeamByAbbreviation(abbreviation);
        }

        [HttpGet]
        [Route("Team/name/{name}")]
        public async Task<Team> GetTeamsByName(string name)
        {
            return await _playerService.GetTeamByName(name);
        }

        [HttpPost]
        [Route("team")]
        public async Task<ActionResult<Team>> AddTeam(Team newTeam)
        {
            try
            {
               return await _playerService.AddTeam(newTeam);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region  Leagues
        [HttpGet]
        [Route("leagues")]
        public async Task<List<League>> GetLeagues()
        {
            return await _playerService.GetLeagues();
        }

        [HttpGet]
        [Route("league/id/{id}")]
        public async Task<League> GetLeagueById(Guid id)
        {
            return await _playerService.GetLeagueById(id);
        }

        [HttpGet]
        [Route("league/abbreviation/{abbreviation}")]
        public async Task<League> GetLeagueByAbbreviation(string abbreviation)
        {
            return await _playerService.GetLeagueByAbbreviation(abbreviation);
        }

        [HttpGet]
        [Route("league/region/{region}")]
        public async Task<League> GetLeagueByRegion(string region)
        {
            return await _playerService.GetLeagueByRegion(region);
        }

        [HttpPost]
        [Route("league")]
        public async Task<ActionResult<League>> AddLeague(League newLeague)
        {
            try
            {
               return await _playerService.AddLeague(newLeague);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion


    }
}
