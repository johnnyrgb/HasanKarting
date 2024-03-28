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
    public class CarService : ICarService
    {
        private IDbRepository dbRepository;
        public CarService() { }
        public CarService(IDbRepository dbRepository) 
        { 
            this.dbRepository = dbRepository;
        }

        public void CreateCar(CarDTO carDTO)
        {
            dbRepository.Cars.Create(new Car()
            {
                Manufacturer = carDTO.Manufacturer,
                Model = carDTO.Model,
                Power = carDTO.Power,
                Mileage = carDTO.Mileage,
                Weight = carDTO.Weight,
            });
            dbRepository.Save();
        }

        public void DeleteCar(int id)
        {
            dbRepository.Cars.Delete(id);
            dbRepository.Save();
        }

        public CarDTO GetCar(int id)
        {
            return new CarDTO(dbRepository.Cars.GetItem(id));
        }

        public List<CarDTO> GetCars()
        {
            var cars = dbRepository.Cars.GetAll();
            return cars.Select(item => new CarDTO(item)).ToList();
        }

        public void UpdateCar(CarDTO carDTO)
        {
            Car? car = dbRepository.Cars.GetItem(carDTO.Id);
            car.Manufacturer = carDTO.Manufacturer;
            car.Model = carDTO.Model;
            car.Power = carDTO.Power;
            car.Mileage = carDTO.Mileage;
            car.Weight = carDTO.Weight;
            dbRepository.Save();
        }
    }
}
