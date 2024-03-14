using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public enum Status
    {
        Scheduled,
        In_process,
        Completed
    }
    public partial class Race
    {
        public Race() 
        {
            Protocols = new HashSet<Protocol>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Protocol> Protocols { get; set; }
        
    }
}
