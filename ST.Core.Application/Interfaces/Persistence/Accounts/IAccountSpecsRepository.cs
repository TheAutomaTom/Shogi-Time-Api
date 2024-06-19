using ST.Core.Application.Interfaces.Persistence.Common;
using ST.Core.Infra.Models.Accounts.Entities;

namespace ST.Core.Application.Interfaces.Persistence.Accounts
{
	public interface IAccountSpecsRepository : IEfCoreRepository<UserEntity>
	{		
		Task<UserEntity> Read(string guid);


	}
}
