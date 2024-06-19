using ST.Core.Infra.Models.Common;

namespace ST.Data.Persistence.Repositories.Common
{
	public interface IElasticRepository<T> : IRepository<T> where T : AuditableEntity
	{
		Task<int> Create(T item);
	}
}
