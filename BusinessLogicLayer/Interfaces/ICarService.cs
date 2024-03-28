using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICarService
    {
        // base
        void CreateCar(CarDTO carDTO);
        List<CarDTO> GetCars();
        CarDTO GetCar(int id);
        void UpdateCar(CarDTO carDTO);
        void DeleteCar(int id);

        // custom
    }
}
