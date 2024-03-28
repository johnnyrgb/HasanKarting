using Autofac;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;


namespace PresentationLayer.Utilities
{
    public class RepositoryModule : Module
    {
        private string connectionString;
        public RepositoryModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbRepository>().As<IDbRepository>().SingleInstance().WithParameter(new TypedParameter(typeof(string), connectionString));
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RaceService>().As<IRaceService>();
            builder.RegisterType<ProtocolService>().As<IProtocolService>();
            builder.RegisterType<CarService>().As<ICarService>();
        }
    }
}
