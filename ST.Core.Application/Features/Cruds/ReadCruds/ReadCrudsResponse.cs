using ST.Core.Domain.Models.Cruds;
using ST.Core.Infra.Models.SearchParams;

namespace ST.Core.Application.Features.Cruds.ReadCruds
{
	public class ReadCrudsResponse
  {
    public IEnumerable<Crud> Cruds {get; set;}
    public Paging? Paging {get; set;}
    public DateRangeFilter? UpdatedDateRange { get; set; }
		
		public ReadCrudsResponse(IEnumerable<Crud> cruds, Paging? paging, DateRangeFilter? updatedDateRange) : base()
    {
      Cruds = cruds;
    }
  }
}
