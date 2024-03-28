using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class RaceDTO
    {
        public RaceDTO() { }
        public RaceDTO(Race race)
        {
            Id = race.Id;
            Date = race.Date;
            Status = race.Status;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
    }
}
