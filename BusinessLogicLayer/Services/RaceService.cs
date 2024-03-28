using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class RaceService : IRaceService
    {
        private IDbRepository dbRepository;
        public RaceService() { }

        public RaceService(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public async Task CreateRace(RaceDTO raceDTO)
        {
            await dbRepository.Races.Create(new Race()
            {
                Date = raceDTO.Date,
                Status = raceDTO.Status,
            });
            await dbRepository.SaveAsync();
        }

        public async Task DeleteRace(int id)
        {
            await dbRepository.Races.Delete(id);
            await dbRepository.SaveAsync();
        }

        public async Task<RaceDTO> GetRace(int id)
        {
            return new RaceDTO(await dbRepository.Races.GetItem(id));
        }

        public async Task<List<RaceDTO>> GetRaces()
        {
            var races = await dbRepository.Races.GetAll();
            return races.Select(item => new RaceDTO(item)).ToList();
        }

        public async Task UpdateRace(RaceDTO raceDTO)
        {
            Race? race = await dbRepository.Races.GetItem(raceDTO.Id);
            race.Date = raceDTO.Date;
            race.Status = raceDTO.Status;
            await dbRepository.SaveAsync();
        }
    }
}
