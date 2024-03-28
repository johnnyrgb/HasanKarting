using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utilities
{
    public static class Seed
    {
        public static async Task SeedAsync(DatabaseContext databaseContext)
        {
            try
            {
                databaseContext.Database.EnsureCreated();
                if (databaseContext.Users.Any()) // Спартак здесь?
                    return;
                else
                {
                    var users = new User[] // Все на месте спортсмены
                    {
                        new User { Id = 1, Firstname = "Дядя", Lastname = "Фридрих", Email = "unclefriedrich@example.com", Password = "unclefriedrich", Username = "unclefriedrich", Role = Role.Admin },
                        new User { Id = 2, Firstname = "Серёга", Lastname = "Нулёвкин", Email = "nulyovka37@example.com", Password = "nulyovka37", Username = "nulyovka37", Role = Role.Racer },
                        new User { Id = 3, Firstname = "Валера", Lastname = "Тудасюдаевич", Email = "cudatuda@example.com", Password = "cudatuda", Username = "cudatuda", Role = Role.Racer },
                        new User { Id = 4, Firstname = "Тёма", Lastname = "Четверкин", Email = "chetyresyra@example.com", Password = "chetyresyra", Username = "chetyresyra", Role = Role.Racer },
                        new User { Id = 5, Firstname = "Рататуй", Lastname = "Смирнов", Email = "polushuyskiy@example.com", Password = "polushuyskiy", Username = "polushuyskiy", Role = Role.Racer },
                    };

                    foreach (User item in users)
                        databaseContext.Users.Add(item);
                    
                    var cars = new Car[]
                    {
                        new Car { Id = 1, Manufacturer = "Speedster", Model = "X200", Power = 250, Mileage = 5000.0, Weight = 650.5 },
                        new Car { Id = 2, Manufacturer = "RapidRacer", Model = "GT", Power = 300, Mileage = 1500.0, Weight = 700.0 },
                        new Car { Id = 3, Manufacturer = "Blitz", Model = "Thunder", Power = 350, Mileage = 3000.0, Weight = 720.3 },
                        new Car { Id = 4, Manufacturer = "AeroMax", Model = "Pro", Power = 220, Mileage = 2000.0, Weight = 600.0 },
                        new Car { Id = 5, Manufacturer = "TurboFleet", Model = "Zephyr", Power = 280, Mileage = 3500.0, Weight = 680.0 },
                        new Car { Id = 6, Manufacturer = "Velocity", Model = "Vortex", Power = 260, Mileage = 4200.0, Weight = 640.0 },
                        new Car { Id = 7, Manufacturer = "DynoDash", Model = "Flash", Power = 310, Mileage = 2700.0, Weight = 710.0 },
                        new Car { Id = 8, Manufacturer = "SpeedShift", Model = "Edge", Power = 300, Mileage = 3900.0, Weight = 655.0 },
                    };

                    foreach (Car item in cars)
                        databaseContext.Cars.Add(item);

                    var races = new Race[]
                    {
                        new Race { Id = 1, Date = new DateTime(2024, 1, 20), Status = Status.Completed },
                        new Race { Id = 2, Date = new DateTime(2024, 2, 10), Status = Status.Completed },
                        new Race { Id = 3, Date = new DateTime(2024, 7, 15), Status = Status.Scheduled },
                        new Race { Id = 4, Date = new DateTime(2024, 8, 5), Status = Status.Scheduled },
                        new Race { Id = 5, Date = new DateTime(2024, 9, 25), Status = Status.Scheduled },
                    };

                    foreach (Race item in races)
                        databaseContext.Races.Add(item);

                    var protocols = new Protocol[]
                    {
                        // RaceId = 1
                        new Protocol { RaceId = 1, UserId = 2, CarId = 1, CompletionTime = new TimeOnly(0, 53, 32, 125) },
                        new Protocol { RaceId = 1, UserId = 3, CarId = 2, CompletionTime = new TimeOnly(0, 53, 30, 329) },
                        new Protocol { RaceId = 1, UserId = 4, CarId = 3, CompletionTime = new TimeOnly(0, 53, 21, 762) },
                        new Protocol { RaceId = 1, UserId = 5, CarId = 4, CompletionTime = new TimeOnly(0, 53, 23, 301) },
                        // RaceId = 2
                        new Protocol { RaceId = 2, UserId = 2, CarId = 5, CompletionTime = new TimeOnly(0, 52, 58, 988) },
                        new Protocol { RaceId = 2, UserId = 3, CarId = 6, CompletionTime = new TimeOnly(0, 52, 55, 234) },
                        new Protocol { RaceId = 2, UserId = 4, CarId = 7, CompletionTime = new TimeOnly(0, 52, 51, 745) },
                        new Protocol { RaceId = 2, UserId = 5, CarId = 8, CompletionTime = new TimeOnly(0, 53, 1, 093) },
                    };

                    foreach (Protocol item in protocols)
                        databaseContext.Protocols.Add(item);

                    await databaseContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
