using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class CarDTO
    {
        public CarDTO() { }
        public CarDTO(Car car)
        {
            Id = car.Id;
            Manufacturer = car.Manufacturer;
            Model = car.Model;
            Power = car.Power;
            Mileage = car.Mileage;
            Weight = car.Weight;
        }

        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public double Mileage { get; set; }
        public double Weight { get; set; }
    }
}
