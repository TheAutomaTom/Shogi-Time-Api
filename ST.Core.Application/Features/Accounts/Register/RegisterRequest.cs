using ST.Core.Infra.ResultTypes;
using Mediator;
using ST.Core.Infra.Models.Auth.Service;
using ST.Core.Infra.Models.Auth.Service.RequestDtos.Create;
using ST.Core.Infra.Models.Emails;
using ST.Core.Infra.Models.Accounts.Results;

namespace ST.Core.Application.Features.Accounts.Register
{
	public class RegisterRequest : IRequest<Result<AuthenticatedAccount>>
	{
		public RegisterRequest(string username, string firstName, string lastName, string email, string password)
		{
			Username = username;
			Email = email;
			FirstName = firstName;
			LastName = lastName;
			Password = password;
			
		}

		public RegisterRequest(){ }

		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		

		

	}



}
