using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IRepository<User>
    {
        private DatabaseContext databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public void Create(User item)
        {
            databaseContext.Users.Add(item);
            databaseContext.SaveChanges();
        }
        public IEnumerable<User> GetAll()
        {
            return databaseContext.Users.ToList();
        }
        

        public User GetItem(int id)
        {
            User? item = databaseContext.Users.Find(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public void Update(User item)
        {
            databaseContext.Users.Update(item);
            databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            User? item = databaseContext.Users.Find(id);
            if (item != null)
            {
                databaseContext.Users.Remove(item);
                 databaseContext.SaveChanges();
            }
            else
            {
                throw new Exception("User not found.");
            }
        } 
    }
}
