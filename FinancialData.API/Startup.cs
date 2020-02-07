using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialData.API.Application.Interfaces;
using FinancialData.API.Data;
using FinancialData.API.Infrastructure;
using FinancialData.API.Middleware;
using FinancialData.API.Models;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FinancialData.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DataContext>(opt =>
      {
        opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddCors(opt =>
      {
        opt.AddPolicy("CorsPolicy", policy =>
        {
          policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000");
        });
      });

      services.AddMediatR(typeof(Startup).Assembly);

      services
        .AddControllers(opt =>
        {
          // Require authentication to access every endpoint in application
          var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
          opt.Filters.Add(new AuthorizeFilter(policy));
        })
        .AddFluentValidation(cfg =>
        {
          cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
        });

      var builder = services.AddIdentityCore<AppUser>();
      var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
      // Enables the creation of users
      builder.AddEntityFrameworkStores<DataContext>();
      // Enables sign in with username and password
      identityBuilder.AddSignInManager<SignInManager<AppUser>>();

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opt =>
        {
          opt.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateAudience = false,
            ValidateIssuer = false
          };
        });

      // Make JWT Generator available to classes when using it
      services.AddScoped<IJwtGenerator, JwtGenerator>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ErrorHandlingMiddleware>();

      if (env.IsDevelopment())
      {
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("CorsPolicy");

      // Adding during JWT Token implementation
      app.UseAuthentication();
      // Allows use of Authorization annotation in controllers
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}