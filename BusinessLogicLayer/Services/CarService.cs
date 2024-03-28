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

        public async Task CreateCar(CarDTO carDTO)
        {
            await dbRepository.Cars.Create(new Car()
            {
                Manufacturer = carDTO.Manufacturer,
                Model = carDTO.Model,
                Power = carDTO.Power,
                Mileage = carDTO.Mileage,
                Weight = carDTO.Weight,
            });
            await dbRepository.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await dbRepository.Cars.Delete(id);
            await dbRepository.SaveAsync();
        }

        public async Task<CarDTO> GetCar(int id)
        {
            return new CarDTO(await dbRepository.Cars.GetItem(id));
        }

        public async Task<List<CarDTO>> GetCars()
        {
            var cars = await dbRepository.Cars.GetAll();
            return cars.Select(item => new CarDTO(item)).ToList();
        }

        public async Task Update(CarDTO carDTO)
        {
            Car? car = await dbRepository.Cars.GetItem(carDTO.Id);
            car.Manufacturer = carDTO.Manufacturer;
            car.Model = carDTO.Model;
            car.Power = carDTO.Power;
            car.Mileage = carDTO.Mileage;
            car.Weight = carDTO.Weight;
            await dbRepository.SaveAsync();
        }
    }
}
