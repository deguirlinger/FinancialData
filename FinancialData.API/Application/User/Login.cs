using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FinancialData.API.Application.Errors;
using FinancialData.API.Application.Interfaces;
using FinancialData.API.Data;
using FinancialData.API.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FinancialData.API.Application.User
{
  public class Login
  {
    public class Query : IRequest<User>
    {
      public string Email { get; set; }
      public string Password { get; set; }
    }

    public class QueryValidator : AbstractValidator<Query>
    {
      public QueryValidator()
      {
        RuleFor(au => au.Email).NotEmpty();
        RuleFor(au => au.Password).NotEmpty();
      }
    }

    public class Handler : IRequestHandler<Query, User>
    {
      private readonly UserManager<AppUser> _userManager;
      private readonly SignInManager<AppUser> _signInManager;
      private readonly IJwtGenerator _jwtGenerator;
      public Handler(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IJwtGenerator jwtGenerator)
      {
        _jwtGenerator = jwtGenerator;
        _signInManager = signInManager;
        _userManager = userManager;
      }

      public async Task<User> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
          throw new RestException(HttpStatusCode.Unauthorized);

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded)
        {
          // TODO: generate token
          return new User
          {
            DisplayName = user.DisplayName,
            Token = _jwtGenerator.CreateToken(user),
            UserName = user.UserName,
            Image = null
          };
        }

        throw new RestException(HttpStatusCode.Unauthorized);
      }
    }
  }
}