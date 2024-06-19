﻿using System.Text;
using ST.Core.Application.Interfaces.Persistence;
using ST.Core.Application.Interfaces.Persistence.Cruds;
using ST.Core.Domain.Models.Cruds.Repo;
using ST.Data.Persistence.Repositories.Cruds;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace ST.Data.Persistence.Config
{
	public static class ElasticConfig
  {

    public static void AddElasticsearch(this IServiceCollection services, IConfiguration config)
    {
      var url = config["Elastic:Url"];
      var user = config["Elastic:Username"];
      var pass = config["Elastic:Password"];
      var defaultIndex = config["Elastic:IndexUnconfigured"];
      var crudIndex = config["Elastic:CrudIndex"];

      var settings = new ConnectionSettings(new Uri(url))
          .PrettyJson() // Return human readable search results
          .DefaultIndex(defaultIndex)
          .DefaultMappingFor<CrudDetail>(m => m.IndexName(crudIndex))
          .BasicAuthentication(user, pass)
          //.EnableHttpCompression()
          .OnRequestCompleted(response => LogTransactions(response))
          .DisableDirectStreaming();

      var client = new ElasticClient(settings);

      // This may be redundant because of .DefaultMappingFor<CrudDetail>(m => m.IndexName(crudIndex)) above.
      client.Map<CrudDetail>(m => m.Index(crudIndex).AutoMap()); 

      services.AddSingleton<IElasticClient>(client);
      services.AddScoped<ICrudDetailsRepository, CrudDetailsRepository>();

    }


    public static void LogTransactions(IApiCallDetails details)
    {
      // Log request
      if (details.RequestBodyInBytes != null)
      {
        Console.WriteLine(
        $"{details.HttpMethod} {details.Uri} \n" +
            $"{Encoding.UTF8.GetString(details.RequestBodyInBytes)}\n\r");
      }
      else
      {
        Console.WriteLine($"{details.HttpMethod} {details.Uri}\n\r");
      }
      //Log details
      if (details.ResponseBodyInBytes != null)
      {
        Console.WriteLine(
            $"{details.HttpMethod} {details.Uri} \n");
      }
      else
      {
        Console.WriteLine($"Status: {details.HttpMethod}\n");
      }

      Console.WriteLine($"{new string('-', 30)}\n\r");
    }



  }
}
