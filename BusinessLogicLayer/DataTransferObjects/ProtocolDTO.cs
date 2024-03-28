using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class ProtocolDTO
    {
        public ProtocolDTO() { }
        public ProtocolDTO(Protocol protocol)
        {
            Id = protocol.Id;
            RaceId = protocol.RaceId;
            UserId = protocol.UserId;
            CarId = protocol.CarId;
            if (protocol.CompletionTime != null)
                CompletionTime = protocol.CompletionTime;
            else CompletionTime = null;
        }
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public TimeOnly? CompletionTime { get; set; }

    }   
}       
