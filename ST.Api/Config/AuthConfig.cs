using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

namespace ST.Api.Config
{
	public static class AuthConfig
  {

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config, string env)
    {

			// Add services to the container.
			services.AddKeycloakWebApiAuthentication(config, o =>
			{

				if (env == "Development" || env == "Test")
				{
					o.RequireHttpsMetadata = false; // Disable typical Https requirement.
				}
				//options.Audience = configuration.GetSection("Keycloak:audience").Value; // Is an audience required?
			});

			services.AddAuthorization(options =>
      {
        //options.AddPolicy("Unregistered", p => { p.RequireResourceRoles("Unregistered" /* OR */, "registered-player"); });
        options.AddPolicy("Registered-Player", p => { p.RequireResourceRoles("registered-player"); });
      });

      services.AddKeycloakAuthorization(config);

      return services;
    }


  }
}
