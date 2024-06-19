using System.Text.Json.Serialization;
using ST.Core.Infra.Models.Accounts.Entities;
using ST.Core.Infra.Models.Auth.Service.Results;

namespace ST.Core.Infra.Models.Accounts.Results
{
	public class AuthenticatedAccount
	{
		public AuthenticatedAccount(AuthCredential credential, UserEntity user)
		{
			Credential = credential;
			User = user;
		}

		public AuthCredential Credential { get; set; }
		public UserEntity User { get; set; }



	}
}
