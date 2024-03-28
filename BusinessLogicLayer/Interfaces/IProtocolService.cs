using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProtocolService
    {
        // base
        Task CreateProtocol(ProtocolDTO protocolDTO);
        Task<List<ProtocolDTO>> GetProtocols();
        Task<ProtocolDTO> GetProtocol(int id);
        Task UpdateProtocol(ProtocolDTO protocolDTO);
        Task DeleteProtocol(int id);

        // custom
    }
}
