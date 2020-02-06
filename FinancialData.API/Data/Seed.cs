using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialData.API.Models;
using Microsoft.AspNetCore.Identity;

namespace FinancialData.API.Data
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    {
      if (!userManager.Users.Any())
      {
        var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        UserName = "john",
                        Email = "john@test.com",
                        DisplayName = "Johnny",
                        LastName = "Smith",
                        FirstName = "Jonathan"
                    },
                    new AppUser
                    {
                        Id = "b",
                        UserName = "mary",
                        Email = "mary@test.com",
                        DisplayName = "Queen Mary",
                        LastName = "Williams",
                        FirstName = "Mary"
                    },
                    new AppUser
                    {
                        Id = "c",
                        UserName = "will",
                        Email = "will@test.com",
                        DisplayName = "Willy",
                        LastName = "Johnson",
                        FirstName = "William"
                    }
                };

        foreach (var user in users)
        {
          await userManager.CreateAsync(user, "Pa$$w0rd");
        }
      }
    }
  }
}