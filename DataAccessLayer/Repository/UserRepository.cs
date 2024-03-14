using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
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
        public async Task Create(User item)
        {
            await databaseContext.Users.AddAsync(item);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await databaseContext.Users.ToListAsync();
        }

        public async Task<User> GetItem(int id)
        {
            User? item = await databaseContext.Users.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public async Task Update(User item)
        {
            databaseContext.Users.Update(item);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            User? item = await databaseContext.Users.FindAsync(id);
            if (item != null)
            {
                databaseContext.Users.Remove(item);
                await databaseContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found.");
            }
        } 
    }
}
