using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDbRepository
    {
        IRepository<User> Users { get; }
        IRepository<Car> Cars { get; }
        IRepository<Race> Races { get; }
        IRepository<Protocol> Protocols { get; }
        //IReportRepository Reports { get; }
        public Task<bool> SaveAsync();
    }
}
