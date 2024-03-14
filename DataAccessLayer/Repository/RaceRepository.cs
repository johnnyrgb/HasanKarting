using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class RaceRepository : IRepository<Race>
    {
        private DatabaseContext databaseContext;

        public RaceRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Race item)
        {
            await databaseContext.Races.AddAsync(item);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Race>> GetAll()
        {
            return await databaseContext.Races.ToListAsync();
        }

        public async Task<Race> GetItem(int id)
        {
            Race? item = await databaseContext.Races.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Event not found.");
            }
        }

        public async Task Update(Race item)
        {
            databaseContext.Races.Update(item);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Race? item = await databaseContext.Races.FindAsync(id);
            if (item != null)
            {
                databaseContext.Races.Remove(item);
                await databaseContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Event not found.");
            }
        }
    }
}
