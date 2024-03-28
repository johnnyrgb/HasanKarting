using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProtocolDTO
    {
        // base
        Task CreateUser(ProtocolDTO protocolDTO);
        Task<List<ProtocolDTO>> GetUsers();
        Task<ProtocolDTO> GetUser();
        Task Update(ProtocolDTO protocolDTO);
        Task Delete(int id);

        // custom
    }
}
