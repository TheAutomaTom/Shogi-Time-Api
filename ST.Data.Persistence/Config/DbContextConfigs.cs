using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ST.Core.Application.Interfaces.Persistence;
using ST.Core.Application.Interfaces.Persistence.Cruds;
using ST.Core.Domain.Models.Cruds.Repo;
using ST.Data.Persistence.Config.DbContexts;
using ST.Data.Persistence.Repositories.Cruds;
using ST.Core.Application.Interfaces.Persistence.Accounts;
using ST.Data.Persistence.Repositories.Accounts;

namespace ST.Data.Persistence.Config
{
	public static class DbContextConfigs
  {
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
      string connectionString;


      var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      if (env == "Test")
      {
        connectionString = Environment.GetEnvironmentVariable("GeneralDb-Testing");
      }
      else
      {
        connectionString = $"{configuration.GetConnectionString("GeneralDb")}Database=CleanCrud;";
      }

      services.AddDbContext<GeneralDbContext>(options => options.UseSqlServer(connectionString));
           
      services.AddScoped<ICrudEntitiesRepository, CrudEntitiesRepository>();
      services.AddScoped<IAccountSpecsRepository, AccountSpecsRepository>();

      return services;
    }
  }
}
