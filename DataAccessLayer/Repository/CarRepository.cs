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

        public void Create(Car item)
        {
            databaseContext.Cars.Add(item);
            databaseContext.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            return databaseContext.Cars.ToList();
        }

        public Car GetItem(int id)
        {
            Car? item = databaseContext.Cars.Find(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        public void Update(Car item)
        {
          
            databaseContext.Cars.Update(item);
            databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Car? item = databaseContext.Cars.Find(id);
            if (item != null)
            {
                databaseContext.Cars.Remove(item);
                databaseContext.SaveChanges();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }
    }
}
