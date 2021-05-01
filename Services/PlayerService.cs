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
            try
            {
                return await _playerRepository.GetPlayers(includeTeam);
            }
            catch( System.Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<Player> GetPlayerById(Guid id)
        {
            try
            {
                return await _playerRepository.GetPlayerById(id);
            }
            catch( System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Player> GetPlayerByIgn(string ign)
        {
            try
            {
                return await _playerRepository.GetPlayerByIGN(ign);
            }
            catch( System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            try
            {
                return await _playerRepository.GetPlayerByName(name);
            }
            catch( System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Player>> GetPlayersByNationality(string nationality)
        {
            try
            {
                return await _playerRepository.GetPlayersByNationality(nationality);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Player> AddPlayer(Player newPlayer)
        {
            try
            {
                if(newPlayer.Nationality == "")
                {
                    newPlayer.Nationality = "Unspecified";
                }

                return await _playerRepository.AddPlayer(newPlayer);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }
        public async Task<Player> UpdatePlayer(Player updatePlayer)
        {
            try
            {
                return await _playerRepository.UpdatePlayer(updatePlayer);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Teams
        public async Task<List<Team>> GetTeams(bool includePlayers)
        {
            try
            {
                return await _teamRepository.GetTeams(includePlayers);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<List<Team>> GetTeamsByOrigen(string origen, bool includePlayers)
        {
            try
            {
                return await _teamRepository.GetTeamsByOrigen(origen, includePlayers);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Team> GetTeamById(Guid id, bool includePlayers)
        {
            try
            {
                return await _teamRepository.GetTeamById(id, includePlayers);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Team> GetTeamByAbbreviation(string abbrev, bool includePlayers)
        {
            try
            {
                return await _teamRepository.GetTeamByAbbreviation(abbrev, includePlayers);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Team> GetTeamByName(string name, bool includePlayers)
        {
            try
            {
                return await _teamRepository.GetTeamByName(name, includePlayers);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Team> AddTeam(Team newTeam)
        {
            try
            {
                if(newTeam.LandOfOrigen == "")
                {
                    newTeam.LandOfOrigen = "Unspecified";
                }
                return await _teamRepository.AddTeam(newTeam);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Team> UpdateTeam(Team updateTeam)
        {
            try
            {
                return await _teamRepository.UpdateTeam(updateTeam);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Leagues
        public async Task<List<LeagueDTO>> GetLeagues(bool includeSponsors)
        {
            try
            {
                return _mapper.Map<List<LeagueDTO>>(await _leagueRepository.GetLeagues(includeSponsors));
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }
        public async Task<League> GetLeagueById(Guid id)
        {
            try
            {
                return await _leagueRepository.GetLeagueById(id);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<League> GetLeagueByAbbreviation(string abbrev)
        {
            try
            {
                return await _leagueRepository.GetLeagueByAbbreviation(abbrev);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<League> GetLeagueByRegion(string region)
        {
            try
            {
                return await _leagueRepository.GetLeagueByRegion(region);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<League> AddLeague(League newLeague)
        {
            try
            {
                return await _leagueRepository.AddLeague(newLeague);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<League> UpdateLeague(League updateLeague)
        {
            try
            {
                return await _leagueRepository.UpdateLeague(updateLeague);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region  Sponsor
        public async Task<List<Sponsor>> GetSponsors(bool includeLeagues)
        {
            try
            {
                return await _sponsorRepository.GetSponsors(includeLeagues);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Sponsor> GetSponsorById(Guid id)
        {
            try
            {
                return await _sponsorRepository.GetSponsorById(id);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Sponsor> GetSponsorByName(string name)
        {
            try
            {
                return await _sponsorRepository.GetSponsorByName(name);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
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
