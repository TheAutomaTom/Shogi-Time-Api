﻿using ST.Core.Infra.Models.Common;
using ST.Core.Infra.Models.SearchParams;

namespace ST.Core.Application.Interfaces.Persistence.Common
{
	public interface IElasticRepository<T> where T : AuditableEntity
  {
    Task<int> Create(T item);
    Task<int> Delete(int id);
    Task<int> Delete(T item);
    Task<IReadOnlyList<T>> Read();
    Task<IReadOnlyList<T>> Read(Paging? paging = null, DateRangeFilter? dateRange = null);
    Task<T> Read(int id);
    Task<bool> Update(T item);
  }
}