using Microsoft.AspNetCore.Identity;

namespace FinancialData.API.Models
{
  public class AppUser : IdentityUser
  {
    public string DisplayName { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
  }
}