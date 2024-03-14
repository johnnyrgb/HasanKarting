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
                        new User { Id = 0, Firstname = "Дядя", Lastname = "Фридрих", Email = "unclefriedrich@example.com", Password = "unclefriedrich", Username = "unclefriedrich", Role = Role.Admin },
                        new User { Id = 1, Firstname = "Серёга", Lastname = "Нулёвкин", Email = "nulyovka37@example.com", Password = "nulyovka37", Username = "nulyovka37", Role = Role.Racer },
                        new User { Id = 2, Firstname = "Валера", Lastname = "Тудасюдаевич", Email = "cudatuda@example.com", Password = "cudatuda", Username = "cudatuda", Role = Role.Racer },
                        new User { Id = 3, Firstname = "Тёма", Lastname = "Четверкин", Email = "chetyresyra@example.com", Password = "chetyresyra", Username = "chetyresyra", Role = Role.Racer },
                        new User { Id = 4, Firstname = "Рататуй", Lastname = "Смирнов", Email = "polushuyskiy@example.com", Password = "polushuyskiy", Username = "polushuyskiy", Role = Role.Racer },
                    };
                    foreach (User item in users)
                    {
                        databaseContext.Users.Add(item);
                    }
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
