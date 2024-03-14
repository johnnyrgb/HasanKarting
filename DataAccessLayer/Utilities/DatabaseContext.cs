using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public class DatabaseContext : DbContext
    {
        #region Fields
        private string connectionString;

        public DatabaseContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Car> Cars { get; set; }
        #endregion
        #region FluentAPI Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
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

                builder.HasMany(c => c.Protocols)
                       .WithOne()
                       .IsRequired();
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
                builder.Property(u => u.Role).IsRequired();

                builder.HasMany(u => u.Protocols)
                       .WithOne()
                       .IsRequired();
            }
        }

        public class RaceConfiguration : IEntityTypeConfiguration<Race>
        {
            public void Configure(EntityTypeBuilder<Race> builder)
            {
                // Первичный
                builder.HasKey(r => r.Id);

                // Все поля не nullable
                builder.Property(r => r.Id).IsRequired();
                builder.Property(r => r.Date).IsRequired();
                builder.Property(r => r.Status).IsRequired();

                builder.HasMany(r => r.Protocols)
                       .WithOne()
                       .IsRequired();
            }
        }
        public class ProtocolConfiguration : IEntityTypeConfiguration<Protocol>
        {
            public void Configure(EntityTypeBuilder<Protocol> builder)
            {
                // Составной первичный ключ
                builder.HasKey(p => new { p.RaceId, p.UserId, p.CarId });

                // Внешние ключи
                builder.HasOne(p => p.Race)
                       .WithMany(r => r.Protocols)
                       .HasForeignKey(p => p.RaceId)
                       .IsRequired();

                builder.HasOne(p => p.User)
                       .WithMany(u => u.Protocols)
                       .HasForeignKey(p => p.UserId)
                       .IsRequired();

                builder.HasOne(p => p.Car)
                       .WithMany(c => c.Protocols)
                       .HasForeignKey(p => p.CarId)
                       .IsRequired();

                // CompletionTime - nullable
                builder.Property(p => p.CompletionTime).IsRequired(false);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<>).Assembly);
        }
        #endregion
    }
}
