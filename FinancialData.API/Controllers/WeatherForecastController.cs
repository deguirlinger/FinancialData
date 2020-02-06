using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialData.API.Data;
using FinancialData.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinancialData.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WeatherForecastsController : ControllerBase
  {
    private readonly DataContext _context;

    public WeatherForecastsController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
    {
      var weatherForecasts = await _context.WeatherForecasts.ToListAsync();
      return Ok(weatherForecasts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> Get(string id)
    {
      var weatherForecast = await _context.WeatherForecasts.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
      return Ok(weatherForecast);
    }
  }
}