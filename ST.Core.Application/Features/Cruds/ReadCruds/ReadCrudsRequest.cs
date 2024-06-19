using Mediator;
using ST.Core.Infra.Models.SearchParams;
using ST.Core.Infra.ResultTypes;

namespace ST.Core.Application.Features.Cruds.ReadCruds
{
	public class ReadCrudsRequest : IRequest<Result<ReadCrudsResponse>>
  {
    public ReadCrudsRequest(Paging? paging, DateRangeFilter? updatedRange)
    {
      Paging = paging;
      UpdatedDateRange = updatedRange;
    }
    public Paging? Paging { get; set; }
    public DateRangeFilter? UpdatedDateRange { get; set; }
  }
}
