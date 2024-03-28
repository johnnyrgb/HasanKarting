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

        public void CreateUser(UserDTO userDTO)
        {
            dbRepository.Users.Create(new User()
            {
                Firstname = userDTO.Firstname,
                Lastname = userDTO.Lastname,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Username = userDTO.Username,
                Role = userDTO.Role,
            });
            dbRepository.Save();
        }

        public void DeleteUser(int id)
        {
            dbRepository.Users.Delete(id);
            dbRepository.Save();
        }

        public UserDTO GetUser(int id)
        {
            return new UserDTO(dbRepository.Users.GetItem(id));
        }

        public List<UserDTO> GetUsers()
        {
            var users = dbRepository.Users.GetAll();
            return users.Select(item => new UserDTO(item)).ToList();
        }


        public void UpdateUser(UserDTO userDTO)
        {
            User? user = dbRepository.Users.GetItem(userDTO.Id);
            user.Firstname = userDTO.Firstname;
            user.Lastname = userDTO.Lastname;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            user.Username = userDTO.Username;
            user.Role = userDTO.Role;
        }
    }
}
