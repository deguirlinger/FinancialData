using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FinancialData.API.Application.Errors;
using FinancialData.API.Application.Interfaces;
using FinancialData.API.Application.Validators;
using FinancialData.API.Data;
using FinancialData.API.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinancialData.API.Application.User
{
  public class Register
  {
    public class Command : IRequest<User>
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Username { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
      public string PasswordConfirm { get; set; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(u => u.LastName).NotEmpty();
        RuleFor(u => u.FirstName).NotEmpty();
        RuleFor(u => u.Username).NotEmpty();
        RuleFor(u => u.Email).NotEmpty().EmailAddress();
        RuleFor(u => u.Password).Password();
        RuleFor(u => u.PasswordConfirm).Equal(u => u.Password).WithMessage("Passwords do not match.");
      }
    }

    public class Handler : IRequestHandler<Command, User>
    {
      private readonly DataContext _context;
      private readonly UserManager<AppUser> _userManager;
      private readonly IJwtGenerator _jwtGenerator;
      public Handler(
          DataContext context,
          UserManager<AppUser> userManager,
          IJwtGenerator jwtGenerator)
      {
        _context = context;
        _userManager = userManager;
        _jwtGenerator = jwtGenerator;
      }

      public async Task<User> Handle(Command request, CancellationToken cancellationToken)
      {
        if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
          throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

        if (await _context.Users.Where(x => x.UserName == request.Username).AnyAsync())
          throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

        var user = new AppUser
        {
          FirstName = request.FirstName,
          LastName = request.LastName,
          UserName = request.Username,
          Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
          return new User
          {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.UserName,
            Token = _jwtGenerator.CreateToken(user),
            Image = null
          };
        }

        throw new Exception("Problem creating user");
      }
    }
  }
}