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
    public class ProtocolService : IProtocolService
    {
        private IDbRepository dbRepository;
        public ProtocolService() { }

        public ProtocolService(IDbRepository dbRepository)
        {
            this.dbRepository = dbRepository;
        }

        public async Task CreateProtocol(ProtocolDTO protocolDTO)
        {
            await dbRepository.Protocols.Create(new Protocol()
            {
                RaceId = protocolDTO.RaceId,
                UserId = protocolDTO.UserId,
                CarId = protocolDTO.CarId,
                CompletionTime = protocolDTO.CompletionTime,
            });
            await dbRepository.SaveAsync();
        }

        public async Task DeleteProtocol(int id)
        {
            await dbRepository.Protocols.Delete(id);
            await dbRepository.SaveAsync();
        }

        public async Task<ProtocolDTO> GetProtocol(int id)
        {
            return new ProtocolDTO(await dbRepository.Protocols.GetItem(id));
        }

        public async Task<List<ProtocolDTO>> GetProtocols()
        {
            var protocols = await dbRepository.Protocols.GetAll();
            return protocols.Select(item => new ProtocolDTO(item)).ToList();
        }

        public async Task UpdateProtocol(ProtocolDTO protocolDTO)
        {
            Protocol? protocol = await dbRepository.Protocols.GetItem(protocolDTO.Id);
        }
    }
}
