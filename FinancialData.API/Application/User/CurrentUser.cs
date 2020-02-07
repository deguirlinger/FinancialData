using System.Threading;
using System.Threading.Tasks;
using FinancialData.API.Application.Interfaces;
using FinancialData.API.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinancialData.API.Application.User
{
  public class CurrentUser
  {
    public class Query : IRequest<User> { }

    public class Handler : IRequestHandler<Query, User>
    {
      private readonly UserManager<AppUser> _userManager;
      private readonly IJwtGenerator _jwtGenerator;
      private readonly IUserAccessor _userAccessor;
      public Handler(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
      {
        _userAccessor = userAccessor;
        _jwtGenerator = jwtGenerator;
        _userManager = userManager;
      }

      public async Task<User> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

        return new User
        {
          FirstName = user.FirstName,
          LastName = user.LastName,
          Username = user.UserName,
          // Not necessary, but is used to give the user a new token without the need to log in if they have closed and reopened their browser
          Token = _jwtGenerator.CreateToken(user),
          Image = null
        };
      }
    }
  }
}