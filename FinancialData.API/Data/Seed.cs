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
                        FirstName = "Jonathan",
                        LastName = "Smith",
                        UserName = "john",
                        Email = "john@test.com"
                    },
                    new AppUser
                    {
                        Id = "b",
                        FirstName = "Mary",
                        LastName = "Williams",
                        UserName = "mary",
                        Email = "mary@test.com"
                    },
                    new AppUser
                    {
                        Id = "c",
                        FirstName = "William",
                        LastName = "Johnson",
                        UserName = "will",
                        Email = "will@test.com"
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