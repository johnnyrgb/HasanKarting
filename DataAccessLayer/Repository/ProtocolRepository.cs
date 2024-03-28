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
    public class ProtocolRepository : IRepository<Protocol>
    {
        private DatabaseContext databaseContext;

        public ProtocolRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public void Create(Protocol item)
        {
            databaseContext.Protocols.Add(item);
            databaseContext.SaveChanges();
        }
        public IEnumerable<Protocol> GetAll()
        {
            return databaseContext.Protocols.ToList();
        }

        public Protocol GetItem(int id)
        {
            Protocol? item = databaseContext.Protocols.Find(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Protocol not found.");
            }
        }

        public void Update(Protocol item)
        {
            databaseContext.Protocols.Update(item);
            databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Protocol? item = databaseContext.Protocols.Find(id);
            if (item != null)
            {
                databaseContext.Protocols.Remove(item);
                databaseContext.SaveChanges();
            }
            else
            {
                throw new Exception("Protocol not found.");
            }
        }
    }
}
