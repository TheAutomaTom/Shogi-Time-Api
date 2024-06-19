﻿using ST.Core.Application.Interfaces.Infrastructure;
using ST.Core.Domain.Models.Cruds;
using ST.Data.Persistence.Cache;
using ST.TestSetup.Config;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Testcontainers.Redis;
using static ST.TestSetup.MockData.BogusGenerators;

namespace ST.Tests.Integration
{
	public class Test_Connectivity
	{
		/* Lifecycle.....................................................*/

		E2ETestingWebAppFactory _factory;
		readonly RedisContainer _redisContainer;
		//HttpClient _client;
		Random _rando = new Random();

		public Test_Connectivity()
		{
			// This ctor sets the environment variable.
			_factory = new E2ETestingWebAppFactory();


			_redisContainer = new RedisBuilder().Build();
			_redisContainer.StartAsync().Wait();
			var cs = _redisContainer.GetConnectionString();
			Environment.SetEnvironmentVariable("RedisCache-Testing", cs);




		}


		public void Dispose()
		{
			_factory.Dispose();
			_redisContainer.DisposeAsync().AsTask();
		}

		/* ...lifecycle``````````````````````````````````````````````````*/


		[Fact]
		public async Task DistributedCache_IsOk()
		{
			var service = _factory.Services.GetService<ICache>() as CacheService;

			// TODO: Parse service.GetStatus() for health check.
			var isConnected = service.GetStatus();

			var key1 = $"TestString-{_rando.Next(1, 999)}";
			var value1 = Guid.NewGuid().ToString();

			var isCachingStrings = await service.Create(key1, value1);
			Assert.True(isCachingStrings.IsOk);

			var isReadingStrings = await service.ReadString(key1);
			Assert.True(isReadingStrings.IsOk);
			Assert.Equal(value1, isReadingStrings.Data);


			var key2 = $"TestCrud-{_rando.Next(1, 999)}";
			var value2 = CrudFaker.Generate().First();

			var isCachingObjects = await service.Create<Crud>(key2, value2, new TimeSpan(0, 0, 3));
			Assert.True(isCachingObjects.IsOk);

			var isReadingObjects = await service.Read<Crud>(key2);
			Assert.True(isReadingObjects.IsOk);
			Assert.NotNull(isReadingObjects.Data);
			Assert.Equal(value2.Id, isReadingObjects.Data.Id);
			Assert.Equal(value2.Name, isReadingObjects.Data.Name);
			Assert.Equal(value2.Detail.Id, isReadingObjects.Data.Detail.Id);
			Assert.Equal(value2.Detail.Tags, isReadingObjects.Data.Detail.Tags);

			Thread.Sleep(3000); // Wait for isCachingObjects to expire;      

			var objectsExpire = await service.Read<Crud>(key2);
			Assert.True(objectsExpire.IsOk);
			Assert.Null(objectsExpire.Data);




		}









[Fact]
public void IntToBinary()
{
 Random rando = new();
 int input = rando.Next(1, 999); // EX: 8
 
 string asBinary = "";

 while (input > 0)
 {
  //if (decimalInput >= 1)
  var remainder = input % 2;
  asBinary = remainder.ToString() + asBinary;
  input /= 2;
  
  // TODO: Handle fractional values
  //if (decimalInput < 1)
 }
 asBinary += (Char)8322;

 Assert.Equal($"{Convert.ToString(input, 2)}{(Char)8322}", asBinary);
 //Assert.True(Math.Quiz("fun"));
}



	}
}

