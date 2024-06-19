using ST.Core.Infra.Models.Common;
using ST.Core.Infra.Models.SearchParams;

namespace ST.Core.Application.Interfaces.Persistence.Common
{
	public interface IEfCoreRepository<T> where T : AuditableEntity
  {
    Task<T> Create(T item);
    Task<IReadOnlyList<T>> Read();
		Task<IReadOnlyList<T>> Read(Paging paging = null, DateRangeFilter dateRange = null);
    Task<T> Read(int id);
		Task<bool> Update(T item);
    Task<int> Delete(T item);
    Task<int> Delete(int id);
  }
}