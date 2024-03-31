using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class CarController : ControllerBase
    {
        public readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> Get()
        {
            return await Task.Run(() => _carService.GetCars());
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> Get(int id)
        {
            return await Task.Run(() => _carService.GetCar(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<ActionResult<CarDTO>> Post(CarDTO item)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await Task.Run(() => _carService.CreateCar(new CarDTO()
            {
                Manufacturer = item.Manufacturer,
                Model = item.Model,
                Power = item.Power,
                Mileage = item.Mileage,
                Weight = item.Weight,
            }));
            return CreatedAtAction("Get", new {Id = item.Id}, item);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CarDTO>> Put(CarDTO item)
        {
            await Task.Run(() => _carService.UpdateCar(item));
            return CreatedAtAction("Get", new { Id = item.Id }, item);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Run(() => _carService.DeleteCar(id));
        }
    }
}
