using Autofac;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;

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
        }
    }
}
