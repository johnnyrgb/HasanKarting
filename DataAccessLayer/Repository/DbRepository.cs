using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class DbRepository : IDbRepository
    {
        private DatabaseContext databaseContext;
        private UserRepository? userRepository;
        private RaceRepository? raceRepository;
        private CarRepository? carRepository;
        private ProtocolRepository? protocolRepository;

        public DbRepository(string connectionString)
        {
            databaseContext = new DatabaseContext(connectionString);
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(this.databaseContext);
                return userRepository;
            }
        }

        public IRepository<Race> Races
        {
            get
            {
                if (raceRepository == null)
                    raceRepository = new RaceRepository(this.databaseContext);
                return raceRepository;
            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (Cars == null)
                    carRepository = new CarRepository(this.databaseContext);
                return carRepository;
            }

        }
        public IRepository<Protocol> Protocols
        {
            get
            {
                if (protocolRepository == null)
                    protocolRepository = new ProtocolRepository(this.databaseContext);
                return protocolRepository;
            }

        }

        public bool Save()
        {
            return databaseContext.SaveChanges() > 0;
        }
    }
}
