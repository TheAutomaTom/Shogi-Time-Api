using Mediator;
using ST.Core.Infra.ResultTypes;

namespace ST.Core.Application.Features.Cruds.DeleteCrudById
{
	public class DeleteCrudByIdRequest : IRequest<Result>
  {
    public DeleteCrudByIdRequest(int id)
    {
      Id = id;
    }

    public int Id { get; }
  }
}
