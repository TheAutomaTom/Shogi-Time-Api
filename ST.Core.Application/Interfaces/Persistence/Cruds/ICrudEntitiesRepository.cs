using ST.Core.Application.Interfaces.Persistence.Common;
using ST.Core.Domain.Models.Cruds.Repo;
using Nest;
using ST.Core.Infra.Models.SearchParams;

namespace ST.Core.Application.Interfaces.Persistence.Cruds
{
  public interface ICrudEntitiesRepository : IEfCoreRepository<CrudEntity>
  { 



  }
}
