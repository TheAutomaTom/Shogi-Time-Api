using ST.Core.Infra.ResultTypes;
using ST.Core.Infra.Models.Auth.Service;
using ST.Core.Infra.Models.Auth.Service.RequestDtos.Create;
using ST.Core.Infra.Models.Auth.Service.ResponseDtos;
using ST.Core.Infra.Models.Auth.Service.Results;

namespace ST.Core.Application.Interfaces.Infrastructure
{
	public interface IManageAuth
	{
		Task<Result<User>> CreateUser(UserCreateRequestDto user);
		
		Task<Result<AuthCredential>> AuthenticateUser(string username, string password);



	}
}
