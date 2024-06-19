using ST.Core.Domain.Models.Cruds.Responses;
using Mediator;
using ST.Core.Domain.Models.Cruds;
using ST.Core.Infra.ResultTypes;

namespace ST.Core.Application.Features.Cruds.UpdateCrud
{
	public class UpdateCrudRequest : IRequest<Result<Crud>>
  {
    public UpdateCrudRequest()
    {
      
    }

    public UpdateCrudRequest(CrudUpdate crud)
    {

      Id = crud.Id;
      Name = crud.Name;
      Department = crud.Department;
      Description = crud.Description;
      Tags = crud.Tags;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Department { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> Tags { get; set; }


  }
}
