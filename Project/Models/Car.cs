using Microsoft.Extensions.Hosting;

namespace Project.Models
{
    public partial class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; } // модель
        public string Manufacturer { get; set; } // производитель
        public int Power { get; set; } // мощность (Вт или л.с.?)
        public int RacesSinceLastService { get; set; } // гонок с последнего обслуживания
        public int Mileage{ get; set; } // километраж
        public int Status { get; set; } // статус (готов, требует обслуживания...)
        public DateTime LastServiceDate { get; set; } // дата последнего облуживания        
    }
}
