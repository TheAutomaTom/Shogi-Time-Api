﻿using Microsoft.Extensions.DependencyInjection;

namespace ST.Core.Application.Config
{
  public static class MediatorConfig
  {
    public static IServiceCollection AddMediatorSupport(this IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Transient);
      return services;
    }
  }
}
