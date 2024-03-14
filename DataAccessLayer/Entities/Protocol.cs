using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Protocol
    {
        public Protocol() { }
        public int RaceId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime? CompletionTime { get; set; }

        public virtual Race Race { get; set; }
        public virtual User User { get ; set; }
        public virtual Car Car { get; set; }
    }
}
