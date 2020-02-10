
using System.Threading.Tasks;
using FinancialData.API.Application.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialData.API.Controllers
{
  // Since all endpoints in the app are protected, AllowAnonymous overrides this and allows access
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(Login.Query query)
    {
      return await _mediator.Send(query);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(Register.Command command)
    {
      return await _mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<User>> CurrentUser()
    {
      return await _mediator.Send(new CurrentUser.Query());
    }
  }
}