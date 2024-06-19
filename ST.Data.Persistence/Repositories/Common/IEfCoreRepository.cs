using ST.Core.Infra.Models.Common;

namespace ST.Data.Persistence.Repositories.Common
{
	public interface IEfCoreRepository<T> : IRepository<T> where T : AuditableEntity
	{
		Task<T> Create(T item);
	}
}
