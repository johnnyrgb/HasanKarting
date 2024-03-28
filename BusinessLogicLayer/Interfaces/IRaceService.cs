using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IRaceService
    {
        // base
        Task CreateRace(RaceDTO raceDTO);
        Task<List<RaceDTO>> GetRaces();
        Task<RaceDTO> GetRace();
        Task Update(RaceDTO raceDTO);
        Task Delete(int id);

        // custom
    }
}
