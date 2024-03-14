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
    public class ProtocolRepository : IRepository<Protocol>
    {
        private DatabaseContext databaseContext;

        public ProtocolRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Protocol item)
        {
            await databaseContext.Protocols.AddAsync(item);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Protocol>> GetAll()
        {
            return await databaseContext.Protocols.ToListAsync();
        }

        public async Task<Protocol> GetItem(int id)
        {
            Protocol? item = await databaseContext.Protocols.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("Protocol not found.");
            }
        }

        public async Task Update(Protocol item)
        {
            databaseContext.Protocols.Update(item);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Protocol? item = await databaseContext.Protocols.FindAsync(id);
            if (item != null)
            {
                databaseContext.Protocols.Remove(item);
                await databaseContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Protocol not found.");
            }
        }
    }
}
