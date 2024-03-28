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

                r.Property(r => r.Date).HasColumnType("timestamp without time zone");

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

                p.Property(p => p.CompletionTime).HasColumnType("time");
            });
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Firstname = "Дядя", Lastname = "Фридрих", Email = "unclefriedrich@example.com", Password = "unclefriedrich", Username = "unclefriedrich", Role = Role.Admin },
                new User { Id = 2, Firstname = "Серёга", Lastname = "Нулёвкин", Email = "nulyovka37@example.com", Password = "nulyovka37", Username = "nulyovka37", Role = Role.Racer },
                new User { Id = 3, Firstname = "Валера", Lastname = "Тудасюдаевич", Email = "cudatuda@example.com", Password = "cudatuda", Username = "cudatuda", Role = Role.Racer },
                new User { Id = 4, Firstname = "Тёма", Lastname = "Четверкин", Email = "chetyresyra@example.com", Password = "chetyresyra", Username = "chetyresyra", Role = Role.Racer },
                new User { Id = 5, Firstname = "Рататуй", Lastname = "Смирнов", Email = "polushuyskiy@example.com", Password = "polushuyskiy", Username = "polushuyskiy", Role = Role.Racer }
                );
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Manufacturer = "Speedster", Model = "X200", Power = 250, Mileage = 5000.0, Weight = 650.5 },
                new Car { Id = 2, Manufacturer = "RapidRacer", Model = "GT", Power = 300, Mileage = 1500.0, Weight = 700.0 },
                new Car { Id = 3, Manufacturer = "Blitz", Model = "Thunder", Power = 350, Mileage = 3000.0, Weight = 720.3 },
                new Car { Id = 4, Manufacturer = "AeroMax", Model = "Pro", Power = 220, Mileage = 2000.0, Weight = 600.0 },
                new Car { Id = 5, Manufacturer = "TurboFleet", Model = "Zephyr", Power = 280, Mileage = 3500.0, Weight = 680.0 },
                new Car { Id = 6, Manufacturer = "Velocity", Model = "Vortex", Power = 260, Mileage = 4200.0, Weight = 640.0 },
                new Car { Id = 7, Manufacturer = "DynoDash", Model = "Flash", Power = 310, Mileage = 2700.0, Weight = 710.0 },
                new Car { Id = 8, Manufacturer = "SpeedShift", Model = "Edge", Power = 300, Mileage = 3900.0, Weight = 655.0 }
                );
            modelBuilder.Entity<Race>().HasData(
                new Race { Id = 1, Date = new DateTime(2024, 1, 20), Status = Status.Completed },
                new Race { Id = 2, Date = new DateTime(2024, 2, 10), Status = Status.Completed },
                new Race { Id = 3, Date = new DateTime(2024, 7, 15), Status = Status.Scheduled },
                new Race { Id = 4, Date = new DateTime(2024, 8, 5), Status = Status.Scheduled },
                new Race { Id = 5, Date = new DateTime(2024, 9, 25), Status = Status.Scheduled }
                );
            modelBuilder.Entity<Protocol>().HasData(
                // RaceId = 1
                new Protocol { Id = 1, RaceId = 1, UserId = 2, CarId = 1, CompletionTime = new TimeOnly(0, 53, 32, 125) },
                new Protocol { Id = 2, RaceId = 1, UserId = 3, CarId = 2, CompletionTime = new TimeOnly(0, 53, 30, 329) },
                new Protocol { Id = 3, RaceId = 1, UserId = 4, CarId = 3, CompletionTime = new TimeOnly(0, 53, 21, 762) },
                new Protocol { Id = 4, RaceId = 1, UserId = 5, CarId = 4, CompletionTime = new TimeOnly(0, 53, 23, 301) },
                // RaceId = 2
                new Protocol { Id = 5, RaceId = 2, UserId = 2, CarId = 5, CompletionTime = new TimeOnly(0, 52, 58, 988) },
                new Protocol { Id = 6, RaceId = 2, UserId = 3, CarId = 6, CompletionTime = new TimeOnly(0, 52, 55, 234) },
                new Protocol { Id = 7, RaceId = 2, UserId = 4, CarId = 7, CompletionTime = new TimeOnly(0, 52, 51, 745) },
                new Protocol { Id = 8, RaceId = 2, UserId = 5, CarId = 8, CompletionTime = new TimeOnly(0, 53, 1, 093) }
                );
        }
        #endregion
    }
}
