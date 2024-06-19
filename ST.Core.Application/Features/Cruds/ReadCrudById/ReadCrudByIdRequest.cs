using ST.Core.Domain.Models.Cruds;
using Mediator;
using ST.Core.Infra.ResultTypes;

namespace ST.Core.Application.Features.Cruds.ReadCrudById
{
	public class ReadCrudByIdRequest : IRequest<Result<Crud>>
  {
    public ReadCrudByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }

  }
}
