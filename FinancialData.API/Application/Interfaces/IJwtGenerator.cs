using FinancialData.API.Models;

namespace FinancialData.API.Application.Interfaces
{
  public interface IJwtGenerator
  {
    string CreateToken(AppUser user);
  }
}