using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ST.Core.Application.Interfaces.Infrastructure;
using ST.Core.Infra.Models.Auth.Service.Config;
using ST.Data.Infra.Auth;


namespace ST.Data.Infra.Auth.Config
{
	public static class AuthServiceConfig
  {
    public static IServiceCollection AddAuthService(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection("AuthServiceSettings");
      services.Configure<AuthServiceSettings>(settings);
      services.AddTransient<IManageAuth, AuthService>();

      return services;
    }
  }
}
