using Bogus;
using ST.Core.Application.Features.Accounts.Register;
using Swashbuckle.AspNetCore.Filters;

namespace ST.Api.Controllers.ExamplesRequests
{
	public class Example_CreateAccountRequest : IExamplesProvider<RegisterRequest>
	{

		public RegisterRequest GetExamples()
		{

			var faker = new Faker<RegisterRequest>()
				.RuleFor(x => x.Username, f => f.Person.UserName)
				.RuleFor(x => x.Email, f => f.Person.Email)
				.RuleFor(x => x.FirstName, f => f.Person.FirstName)
				.RuleFor(x => x.LastName, f => f.Person.LastName)
				.RuleFor(x => x.Password, f => "Admin123!");
			
			return faker.Generate();

		}



	}
}
