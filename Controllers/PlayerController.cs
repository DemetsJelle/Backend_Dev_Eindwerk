using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Data;
using Backend_Dev_Eindwerk.DTO;
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
        public async Task<List<Player>> GetPlayers(bool includeTeam)
        {
            return await _playerService.GetPlayers(includeTeam);
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

        [HttpPut]
        [Route("player")]
        public async Task<ActionResult<Player>> UpdatePlayer(Player updatePlayer)
        {
            try
            {
               return await _playerService.UpdatePlayer(updatePlayer);
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
        public async Task<List<Team>> GetTeams(bool includePlayers)
        {
            return await _playerService.GetTeams(includePlayers);
        }

        [HttpGet]
        [Route("Team/origen/{origen}")]
        public async Task<List<Team>> GetTeamsByOrigen(string origen, bool includePlayers)
        {
            return await _playerService.GetTeamsByOrigen(origen, includePlayers);
        }

        [HttpGet]
        [Route("Team/id/{id}")]
        public async Task<Team> GetTeamsById(Guid id, bool includePlayers)
        {
            return await _playerService.GetTeamById(id, includePlayers);
        }

        [HttpGet]
        [Route("Team/Abbreviation/{abbreviation}")]
        public async Task<Team> GetTeamsByAbbreviation(string abbreviation, bool includePlayers)
        {
            return await _playerService.GetTeamByAbbreviation(abbreviation, includePlayers);
        }

        [HttpGet]
        [Route("Team/name/{name}")]
        public async Task<Team> GetTeamsByName(string name, bool includePlayers)
        {
            return await _playerService.GetTeamByName(name, includePlayers);
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

        [HttpPut]
        [Route("team")]
        public async Task<ActionResult<Team>> UpdateTeam(Team updateTeam)
        {
            try
            {
               return await _playerService.UpdateTeam(updateTeam);
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
        public async Task<List<LeagueDTO>> GetLeagues(bool includeSponsors)
        {
            return await _playerService.GetLeagues(includeSponsors);
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

        [HttpPut]
        [Route("league")]
        public async Task<ActionResult<League>> UpdateLeague(League updateLeague)
        {
            try
            {
               return await _playerService.UpdateLeague(updateLeague);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion

        #region  Sponsors
        [HttpGet]
        [Route("sponsors")]
        public async Task<List<Sponsor>> GetSponsors(bool includeLeagues)
        {
            return await _playerService.GetSponsors(includeLeagues);
        }

        [HttpGet]
        [Route("sponsor/id/{id}")]
        public async Task<League> GetSponsorById(Guid id)
        {
            return await _playerService.GetLeagueById(id);
        }

        [HttpPost]
        [Route("sponsor")]
        public async Task<ActionResult<SponsorDTO>> AddSponsor(SponsorDTO newSponsor)
        {
            try
            {
               return await _playerService.AddSponsor(newSponsor);
            }
            catch(Exception ex)
            {
                throw ex;
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}
