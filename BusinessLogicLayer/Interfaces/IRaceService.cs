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
        void CreateRace(RaceDTO raceDTO);
        List<RaceDTO> GetRaces();
        RaceDTO GetRace(int id);
        void UpdateRace(RaceDTO raceDTO);
        void DeleteRace(int id);

        // custom
    }
}
