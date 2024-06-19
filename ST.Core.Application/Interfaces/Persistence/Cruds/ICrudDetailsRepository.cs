using ST.Core.Application.Interfaces.Persistence.Common;
using ST.Core.Domain.Models.Cruds;
using ST.Core.Domain.Models.Cruds.Repo;

namespace ST.Core.Application.Interfaces.Persistence.Cruds
{
  public interface ICrudDetailsRepository : IElasticRepository<CrudDetail>
  {
    Task<IReadOnlyList<Crud>> Read(IEnumerable<CrudEntity> entities);
    Task<bool> Update(CrudDetail detail);
  }
}
