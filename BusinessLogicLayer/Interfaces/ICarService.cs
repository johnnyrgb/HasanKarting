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
        Task CreateCar(CarDTO carDTO);
        Task<List<CarDTO>> GetCars();
        Task<CarDTO> GetCar(int id);
        Task Update(CarDTO carDTO);
        Task Delete(int id);

        // custom
    }
}
