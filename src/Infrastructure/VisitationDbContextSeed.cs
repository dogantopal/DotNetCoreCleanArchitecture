using Domain.Entities;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class VisitationDbContextSeed
    {
        public static async Task SeedAsync(VisitationDbContext context)
        {
            await SeedAccountsAsync(context);
            await SeedUsersAsync(context);
            await SeedVisitsAsync(context);
        }

        private static async Task SeedAccountsAsync(VisitationDbContext context)
        {
            if (!context.Accounts.Any())
            {
                using (FileStream fileStream = File.Open("../Infrastructure/Data/accounts.json", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var dataAsString = reader.ReadToEnd();

                        var data = JsonSerializer.Deserialize<List<Account>>(dataAsString);

                        context.Accounts.AddRange(data);

                        await context.Database.OpenConnectionAsync();
                        try
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[Accounts] ON;");
                            await context.SaveChangesAsync();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[Accounts] OFF;");
                        }
                        finally
                        {
                            await context.Database.CloseConnectionAsync();
                        }
                    }
                }
            }
        }

        private static async Task SeedUsersAsync(VisitationDbContext context)
        {
            if (!context.Users.Any())
            {
                var password = "admin";

                byte[] passwordHash, passwordSalt;
                PasswordHelper.CreatePasswordHashAndSalt(password, out passwordHash, out passwordSalt);

                User user = new User
                {
                    Id = 1,
                    Email = "admin@visitation.com",
                    Name = "John",
                    Surname = "Doe",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Username = "admin"
                };

                context.Users.Add(user);

                await context.Database.OpenConnectionAsync();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[Users] ON;");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[Users] OFF;");
                }
                finally
                {
                    await context.Database.CloseConnectionAsync();
                }

            }
        }

        private static async Task SeedVisitsAsync(VisitationDbContext context)
        {
            if (!context.Visits.Any())
            {
                Visit visit1 = new Visit
                {
                    Id = 1,
                    AccountId = 1,
                    Description = "Ordinary Montly Company Visit",
                    IntendedDate = DateTime.Now.AddDays(-2),
                    UserId = 1,
                    VisitDate = DateTime.Now
                };

                context.Visits.Add(visit1);

                Visit visit2 = new Visit
                {
                    Id = 2,
                    AccountId = 1,
                    Description = "Attend company party",
                    IntendedDate = DateTime.Now.AddDays(-10),
                    UserId = 1,
                    VisitDate = DateTime.Now.AddDays(-10)
                };

                context.Visits.Add(visit2);

                Visit visit3 = new Visit
                {
                    Id = 3,
                    AccountId = 2,
                    Description = "For listening new company global projects",
                    IntendedDate = DateTime.Now.AddDays(5),
                    UserId = 1
                };

                context.Visits.Add(visit3);

                await context.Database.OpenConnectionAsync();
                try
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[Visits] ON;");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[Visits] OFF;");
                }
                finally
                {
                    await context.Database.CloseConnectionAsync();
                }

            }
        }


    }
}
