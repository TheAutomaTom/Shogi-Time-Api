﻿using ST.Core.Application.Interfaces.Persistence.Accounts;
using ST.Core.Application.Interfaces.Persistence.Common;
using ST.Core.Domain.Models.Cruds.Repo;
using ST.Core.Infra.Models.SearchParams;
using ST.Data.Persistence.Config.DbContexts;
using ST.Data.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using ST.Core.Infra.Models.Accounts.Entities;

namespace ST.Data.Persistence.Repositories.Accounts
{
	public class AccountSpecsRepository : EfCoreRepository<UserEntity>, IAccountSpecsRepository
	{
		public AccountSpecsRepository(GeneralDbContext context) : base(context)
		{

		}


		public async Task<UserEntity> Read(string guid)
		{
			var g = new Guid(guid);
			var result = await _dbContext.Accounts.Where(a => a.Guid == g).FirstOrDefaultAsync();
			if (result != null)
			{
				return result;
			}
			return null;			
		}



		public async Task<IReadOnlyList<CrudEntity>> Read(Paging paging = default, DateRangeFilter dateRange = default)
		{
			var results = await _dbContext.Set<CrudEntity>()
				.Take(paging.CountPer)
				.Skip(paging.Skip)
				.Where(c =>

				// I initialize ModifiedDate with CreationData in order to make this search more efficient.
				//(c.CreatedDate >= dateRange.From || c.LastModifiedDate >= dateRange.From)
				//&& (c.CreatedDate <= dateRange.Until || c.LastModifiedDate <= dateRange.Until)

				c.LastModifiedDate >= dateRange.From
					&& c.LastModifiedDate <= dateRange.Until
				).ToListAsync();

			return results;



		}

	}
}
