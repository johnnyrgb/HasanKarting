using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        private string connectionString;

        public DatabaseContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Car> Cars { get; set; }

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this.connectionString);
        }
        public class CarConfiguration : IEntityTypeConfiguration<Car>
        {
            public void Configure(EntityTypeBuilder<Car> builder)
            {
                // Первичный ключ
                builder.HasKey(c => c.Id);

                // Все поля не nullable
                builder.Property(c => c.Id).IsRequired();
                builder.Property(c => c.Manufacturer).IsRequired();
                builder.Property(c => c.Model).IsRequired();
                builder.Property(c => c.Power).IsRequired();
                builder.Property(c => c.Mileage).IsRequired();
                builder.Property(c => c.Weight).IsRequired();
            }
        }
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                // Первичный ключ
                builder.HasKey(u => u.Id);

                // Все поля не nullable
                builder.Property(u => u.Id).IsRequired();
                builder.Property(u => u.Firstname).IsRequired();
                builder.Property(u => u.Lastname).IsRequired();
                builder.Property(u => u.Email).IsRequired();
                builder.Property(u => u.Password).IsRequired();
                builder.Property(u => u.Username).IsRequired();
            }
        }

        public class RaceConfiguration : IEntityTypeConfiguration<Race>
        {
            public void Configure(EntityTypeBuilder<Race> builder)
            {
                // Первичный ключ
                builder.HasKey(r => r.Id);

                // Внешний ключ
                builder.HasOne(r => r.Protocol)
                    .WithMany()
                    .HasForeignKey(r => r.ProtocolId)
                    .IsRequired();

                // Все поля не nullable
                builder.Property(r => r.Id).IsRequired();
                builder.Property(r => r.Date).IsRequired();
                builder.Property(r => r.Status).IsRequired();
                builder.Property(r => r.ProtocolId).IsRequired();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Protocol>()
            .HasKey(p => new { p.RaceId, p.RacerId, p.CarId });
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
        }

        #endregion

    }
}
