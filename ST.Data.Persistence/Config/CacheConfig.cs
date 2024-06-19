using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ST.Core.Application.Interfaces.Infrastructure;
using ST.Data.Persistence.Cache;
using ST.Core.Infra.Models.Cache;

namespace ST.Data.Persistence.Config
{
  public static class CacheConfig
  {
    public static IServiceCollection AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("Cache");
      services.Configure<CacheSettings>(settings);
      services.AddTransient<ICache, CacheService>();

      return services;
    }
  }
}



