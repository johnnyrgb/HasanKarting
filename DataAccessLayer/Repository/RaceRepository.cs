using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Utilities;
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
        public void Create(Race item)
        {
            databaseContext.Races.AddAsync(item);
            databaseContext.SaveChangesAsync();
        }
        public IEnumerable<Race> GetAll()
        {
            return databaseContext.Races.ToList();
        }

        public Race GetItem(int id)
        {
            Race? item = databaseContext.Races.Find(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Event not found.");
            }
        }

        public void Update(Race item)
        {
            databaseContext.Races.Update(item);
            databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Race? item = databaseContext.Races.Find(id);
            if (item != null)
            {
                databaseContext.Races.Remove(item);
                databaseContext.SaveChanges();
            }
            else
            {
                throw new Exception("Event not found.");
            }
        }
    }
}
