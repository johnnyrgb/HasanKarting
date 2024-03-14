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
    public class CarRepository : IRepository<Car>
    {
        private DatabaseContext databaseContext;

        public CarRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Create(Car item)
        {
            await databaseContext.Cars.AddAsync(item);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await databaseContext.Cars.ToListAsync();
        }

        public async Task<Car> GetItem(int id)
        {
            Car? item = await databaseContext.Cars.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public async Task Update(Car item)
        {
            databaseContext.Cars.Update(item);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Car? item = await databaseContext.Cars.FindAsync(id);
            if (item != null)
            {
                databaseContext.Cars.Remove(item);
                await databaseContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
