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
        void CreateProtocol(ProtocolDTO protocolDTO);
        List<ProtocolDTO> GetProtocols();
        ProtocolDTO GetProtocol(int id);
        void UpdateProtocol(ProtocolDTO protocolDTO);
        void DeleteProtocol(int id);

        // custom
    }
}
