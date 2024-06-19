using ST.Core.Application.Interfaces.Persistence.Cruds;
using ST.Core.Domain.Models.Cruds.Repo;
using ST.Data.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using ST.Data.Persistence.Config.DbContexts;
using ST.Core.Infra.Models.SearchParams;

namespace ST.Data.Persistence.Repositories.Cruds
{
	public class CrudEntitiesRepository : EfCoreRepository<CrudEntity>, ICrudEntitiesRepository
	{
		public CrudEntitiesRepository(GeneralDbContext context) : base(context)
		{

		}





	}
}
