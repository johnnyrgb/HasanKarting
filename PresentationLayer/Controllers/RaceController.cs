using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class RaceController : ControllerBase
    {
        public readonly IRaceService _raceService;
        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }
        // GET: api/<RaceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceDTO>>> Get()
        {
            return await Task.Run(() => _raceService.GetRaces());
        }

        // GET api/<RaceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceDTO>> Get(int id)
        {
            return await Task.Run(() => _raceService.GetRace(id));
        }

        // POST api/<RaceController>
        [HttpPost]
        public async Task<ActionResult<RaceDTO>> Post(RaceDTO item) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await Task.Run(() => _raceService.CreateRace(new RaceDTO()
            {
                Date = item.Date,
                Status = item.Status,
            }
            ));
            return CreatedAtAction("Get", new { Id = item.Id, }, item);
        }

        // PUT api/<RaceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RaceDTO>> Put(RaceDTO item)
        {
            await Task.Run(() => _raceService.UpdateRace(item));
            return CreatedAtAction("Get", new { Id = item.Id }, item);
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("{id}")]
        public async Task Delete (int id)
        {
            await Task.Run(() => _raceService.DeleteRace(id));
        }
    }
}
