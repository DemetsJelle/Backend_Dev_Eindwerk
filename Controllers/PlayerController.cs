using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend_Dev_Eindwerk.Data;
using Backend_Dev_Eindwerk.DTO;
using Backend_Dev_Eindwerk.Models;
using Backend_Dev_Eindwerk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Dev_Eindwerk.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        [HttpGet]
        [Route("players")]
        public async Task<ActionResult<List<Player>>> GetPlayers(bool includeTeam)
        {
            try
            {
                return new OkObjectResult(await _playerService.GetPlayers(includeTeam));
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("player/id/{id}")]
        public async Task<ActionResult<Player>> GetPlayerById(Guid id)
        {
            try
            {
                return await _playerService.GetPlayerById(id);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
       
        [HttpGet]
        [Route("player/ign/{ign}")]
        public async Task<ActionResult<Player>> GetPlayerByIgn(string ign)
        {
            try
            {
                return await _playerService.GetPlayerByIgn(ign);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("player/name/{name}")]
        public async Task<ActionResult<Player>> GetPlayerByName(string name)
        {
            try
            {
                return await _playerService.GetPlayerByName(name);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }     
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("players/origen/{nationality}")]
        public async Task<ActionResult<List<Player>>> GetPlayersByNationality(string nationality)
        {
            try
            {
                return await _playerService.GetPlayersByNationality(nationality);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }


        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("Teams")]
        public async Task<ActionResult<List<Team>>> GetTeams(bool includePlayers)
        {
            try
            {
                return await _playerService.GetTeams(includePlayers);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Team/origen/{origen}")]
        public async Task<ActionResult<List<Team>>> GetTeamsByOrigen(string origen, bool includePlayers)
        {
            try
            {
                return await _playerService.GetTeamsByOrigen(origen, includePlayers);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Team/id/{id}")]
        public async Task<ActionResult<Team>> GetTeamsById(Guid id, bool includePlayers)
        {
            try
            {
                return await _playerService.GetTeamById(id, includePlayers);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Team/Abbreviation/{abbreviation}")]
        public async Task<ActionResult<Team>> GetTeamsByAbbreviation(string abbreviation, bool includePlayers)
        {
            try
            {
                return await _playerService.GetTeamByAbbreviation(abbreviation, includePlayers);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Team/name/{name}")]
        public async Task<ActionResult<Team>> GetTeamsByName(string name, bool includePlayers)
        {
            try
            {
                return await _playerService.GetTeamByName(name, includePlayers);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet]
        [Route("leagues")]
        public async Task<ActionResult<List<LeagueDTO>>> GetLeagues(bool includeSponsors)
        {
            try
            {
                return await _playerService.GetLeagues(includeSponsors);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("league/id/{id}")]
        public async Task<ActionResult<League>> GetLeagueById(Guid id)
        {
            try
            {
                return await _playerService.GetLeagueById(id);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("league/abbreviation/{abbreviation}")]
        public async Task<ActionResult<League>> GetLeagueByAbbreviation(string abbreviation)
        {
            try
            {
                return await _playerService.GetLeagueByAbbreviation(abbreviation);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("league/region/{region}")]
        public async Task<ActionResult<League>> GetLeagueByRegion(string region)
        {
            try
            {
                return await _playerService.GetLeagueByRegion(region);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet]
        [Route("sponsors")]
        public async Task<ActionResult<List<Sponsor>>> GetSponsors(bool includeLeagues)
        {
            try
            {
                return await _playerService.GetSponsors(includeLeagues);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("sponsor/id/{id}")]
        public async Task<ActionResult<Sponsor>> GetSponsorById(Guid id)
        {
            try
            {
                return await _playerService.GetSponsorById(id);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("sponsor/name/{name}")]
        public async Task<ActionResult<Sponsor>> GetSponsorByName(string name)
        {
            try
            {
                return await _playerService.GetSponsorByName(name);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
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
                //throw ex;
                return new StatusCodeResult(500);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("sponsor")]
        public async Task<ActionResult<SponsorDTO>> UpdateSponsor(SponsorDTO updateSponsor)
        {
            try
            {
               return await _playerService.UpdateSponsor(updateSponsor);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }
        #endregion
    }
}
