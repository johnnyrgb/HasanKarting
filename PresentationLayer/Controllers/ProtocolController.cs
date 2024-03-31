using BusinessLogicLayer.DataTransferObjects;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class ProtocolController : ControllerBase
    {
        public readonly IProtocolService _protocolService;
        public ProtocolController(IProtocolService protocolService)
        {
            _protocolService = protocolService;
        }

        // GET: api/<ProtocolController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProtocolDTO>>> Get()
        {
            return await Task.Run(() => _protocolService.GetProtocols());
        }

        // GET api/<ProtocolController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProtocolDTO>> Get(int id)
        {
            return await Task.Run(() => _protocolService.GetProtocol(id));
        }

        // POST api/<ProtocolController>
        [HttpPost]
        public async Task<ActionResult<ProtocolDTO>> Post(ProtocolDTO item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Task.Run(() => _protocolService.CreateProtocol(new ProtocolDTO()
            {
                RaceId = item.RaceId,
                UserId = item.UserId,
                CarId = item.CarId, 
            }));
            return CreatedAtAction("Get", new { Id = item.Id }, item);
        }

        // PUT api/<ProtocolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProtocolDTO>> Put(ProtocolDTO value)
        {
            await Task.Run(() => _protocolService.UpdateProtocol(value));
            return CreatedAtAction("Get", new { Id = value.Id }, value);
        }

        // DELETE api/<ProtocolController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Task.Run(() => _protocolService.DeleteProtocol(id));
        }
    }
}
