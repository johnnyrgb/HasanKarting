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
    public class UserService : IUserService
    {
        private IDbRepository dbRepository;
        public UserService() { }

        public UserService(IDbRepository dbRepository) 
        {
            this.dbRepository = dbRepository;
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            await dbRepository.Users.Create(new User()
            {
                Firstname = userDTO.Firstname,
                Lastname = userDTO.Lastname,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Username = userDTO.Username,
                Role = userDTO.Role,
            });
            await dbRepository.SaveAsync();
        }

        public async Task DeleteUser(int id)
        {
            await dbRepository.Users.Delete(id);
            await dbRepository.SaveAsync();
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return new UserDTO(await dbRepository.Users.GetItem(id));
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await dbRepository.Users.GetAll();
            return users.Select(item => new UserDTO(item)).ToList();
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            User? user = await dbRepository.Users.GetItem(userDTO.Id);
            user.Firstname = userDTO.Firstname;
            user.Lastname = userDTO.Lastname;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Username = userDTO.Username;
            user.Role = userDTO.Role;
        }
    }
}
