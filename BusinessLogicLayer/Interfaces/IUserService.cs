using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        // base
        Task CreateUser(UserDTO userDTO);
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUser();
        Task Update(UserDTO userDTO);
        Task Delete(int id);

        // custom
    }
}
