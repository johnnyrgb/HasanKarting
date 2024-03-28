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
            Database.EnsureCreated();
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<>).Assembly);
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);

                // Все поля не nullable
                u.Property(u => u.Id).IsRequired();
                u.Property(u => u.Firstname).IsRequired();
                u.Property(u => u.Lastname).IsRequired();
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.Password).IsRequired();
                u.Property(u => u.Username).IsRequired();
                u.Property(u => u.Role).IsRequired();

                u.HasMany(u => u.Protocols)
                 .WithOne()
                 .IsRequired();
            });
            modelBuilder.Entity<Car>(c =>
            {
                
                // Первичный ключ
                c.HasKey(c => c.Id);

                // Все поля не nullable
                c.Property(c => c.Id).IsRequired();
                c.Property(c => c.Manufacturer).IsRequired();
                c.Property(c => c.Model).IsRequired();
                c.Property(c => c.Power).IsRequired();
                c.Property(c => c.Mileage).IsRequired();
                c.Property(c => c.Weight).IsRequired();

                c.HasMany(c => c.Protocols)
                 .WithOne()
                 .IsRequired();
                
            });
            modelBuilder.Entity<Race>(r =>
            {
                // Первичный ключ
                r.HasKey(r => r.Id);

                // Все поля не nullable
                r.Property(r => r.Id).IsRequired();
                r.Property(r => r.Date).IsRequired();
                r.Property(r => r.Status).IsRequired();
                
                r.HasMany(r => r.Protocols)
                 .WithOne()
                 .IsRequired();
            });
            modelBuilder.Entity<Protocol>(p =>
            {
                // Первичный ключ
                p.HasKey(p => p.Id);

                // Внешние ключи
                p.HasOne(p => p.Race)
                       .WithMany(r => r.Protocols)
                       .HasForeignKey(p => p.RaceId)
                       .IsRequired();

                p.HasOne(p => p.User)
                       .WithMany(u => u.Protocols)
                       .HasForeignKey(p => p.UserId)
                       .IsRequired();

                p.HasOne(p => p.Car)
                       .WithMany(c => c.Protocols)
                       .HasForeignKey(p => p.CarId)
                       .IsRequired();

                // CompletionTime - nullable
                p.Property(p => p.CompletionTime).IsRequired(false);
            });
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Firstname = "Дядя", Lastname = "Фридрих", Email = "unclefriedrich@example.com", Password = "unclefriedrich", Username = "unclefriedrich", Role = Role.Admin },
                new User { Id = 2, Firstname = "Серёга", Lastname = "Нулёвкин", Email = "nulyovka37@example.com", Password = "nulyovka37", Username = "nulyovka37", Role = Role.Racer },
                new User { Id = 3, Firstname = "Валера", Lastname = "Тудасюдаевич", Email = "cudatuda@example.com", Password = "cudatuda", Username = "cudatuda", Role = Role.Racer },
                new User { Id = 4, Firstname = "Тёма", Lastname = "Четверкин", Email = "chetyresyra@example.com", Password = "chetyresyra", Username = "chetyresyra", Role = Role.Racer },
                new User { Id = 5, Firstname = "Рататуй", Lastname = "Смирнов", Email = "polushuyskiy@example.com", Password = "polushuyskiy", Username = "polushuyskiy", Role = Role.Racer }
                );
        }
        #endregion
    }
}
