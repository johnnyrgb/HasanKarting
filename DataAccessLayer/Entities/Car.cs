using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public partial class Car
    {
        public Car() { }
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public double Mileage { get; set; }
        public double Weight { get; set; }

        public virtual ICollection<Protocol> Protocols { get; set; }
    }
}
