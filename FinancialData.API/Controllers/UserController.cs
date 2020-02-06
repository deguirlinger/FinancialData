
using System.Threading.Tasks;
using FinancialData.API.Application.User;
using FinancialData.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialData.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(Login.Query query)
    {
      return await _mediator.Send(query);
    }
  }
}