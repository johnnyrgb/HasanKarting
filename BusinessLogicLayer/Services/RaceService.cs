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

        public void CreateRace(RaceDTO raceDTO)
        {
            dbRepository.Races.Create(new Race()
            {
                Date = raceDTO.Date,
                Status = raceDTO.Status,
            });
            dbRepository.Save();
        }

        public void DeleteRace(int id)
        {
            dbRepository.Races.Delete(id);
            dbRepository.Save();
        }

        public RaceDTO GetRace(int id)
        {
            return new RaceDTO(dbRepository.Races.GetItem(id));
        }

        public List<RaceDTO> GetRaces()
        {
            var races = dbRepository.Races.GetAll();
            return races.Select(item => new RaceDTO(item)).ToList();
        }

        public void UpdateRace(RaceDTO raceDTO)
        {
            Race? race = dbRepository.Races.GetItem(raceDTO.Id);
            race.Date = raceDTO.Date;
            race.Status = raceDTO.Status;
            dbRepository.Save();
        }
    }
}
