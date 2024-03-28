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
        void CreateUser(UserDTO userDTO);
        List<UserDTO> GetUsers();
        UserDTO GetUser(int id);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(int id);

        // custom
    }
}
