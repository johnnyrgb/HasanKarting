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

        public void CreateProtocol(ProtocolDTO protocolDTO)
        {
            dbRepository.Protocols.Create(new Protocol()
            {
                RaceId = protocolDTO.RaceId,
                UserId = protocolDTO.UserId,
                CarId = protocolDTO.CarId,
                CompletionTime = protocolDTO.CompletionTime,
            });
            dbRepository.Save();
        }

        public void DeleteProtocol(int id)
        {
            dbRepository.Protocols.Delete(id);
            dbRepository.Save();
        }

        public ProtocolDTO GetProtocol(int id)
        {
            return new ProtocolDTO(dbRepository.Protocols.GetItem(id));
        }

        public List<ProtocolDTO> GetProtocols()
        {
            var protocols = dbRepository.Protocols.GetAll();
            return protocols.Select(item => new ProtocolDTO(item)).ToList();
        }

        public void UpdateProtocol(ProtocolDTO protocolDTO)
        {
            Protocol? protocol = dbRepository.Protocols.GetItem(protocolDTO.Id);
        }
    }
}
