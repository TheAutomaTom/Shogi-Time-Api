using ST.Api.GraphQL.Queries;

namespace ST.Api.Config
{
  public static class GraphQLConfig
  {

    public static IServiceCollection AddGraphQL(this IServiceCollection services, IConfiguration config)
    {

      services
        .AddGraphQLServer()
        .AddQueryType<CrudQueries>();
      //.AddMutationType<BaseMutation>();
      //.AddMutationType<BaseSubscription>();

      return services;
    }


  }
}
