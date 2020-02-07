using FluentValidation;

namespace FinancialData.API.Application.Validators
{
  public static class ValidatorExtensions
  {
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
      var options = ruleBuilder
          .NotEmpty()
          .MinimumLength(6).WithMessage("Password must have at least six characters.")
          .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
          .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
          .Matches("[0-9]").WithMessage("Password must contain at least one number.")
          .Matches("[^-a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

      return options;
    }
  }
}