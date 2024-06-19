using ST.Core.Application.Features.Cruds.CreateCrud;
using ST.Core.Application.Interfaces.Infrastructure;
using ST.Core.Application.Interfaces.Persistence;
using ST.Core.Application.Interfaces.Persistence.Cruds;
using FluentValidation.Results;
using Mediator;
using Microsoft.Extensions.Logging;
using ST.Core.Infra.ResultTypes;

namespace ST.Core.Application.Features.Cruds.DeleteCrudById
{
	public class DeleteCrudByIdHandler : IRequestHandler<DeleteCrudByIdRequest, Result>
  {
    readonly ICrudDetailsRepository _details;
    readonly ICrudEntitiesRepository _entities;
    readonly ICache _cache;
    readonly ILogger<DeleteCrudByIdHandler> _logger;

    public DeleteCrudByIdHandler(ILogger<DeleteCrudByIdHandler> logger, ICache cache, ICrudEntitiesRepository entities, ICrudDetailsRepository details)
    {
      _logger = logger;
      _cache = cache;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result> Handle(DeleteCrudByIdRequest request, CancellationToken cancellationToken)
    {
      var validator = new DeleteCrudByIdValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        return Result.Fail(validationResult.Errors);
      }

      try
      {
        var errors = new List<ExpectedError>();

        var entityAttempt = await _entities.Delete(request.Id);
        if (entityAttempt == 0)
        {
          errors.Add( new ExpectedError(ErrorCode.Connectivity, $"{nameof(_entities)} Failed to delete entity ID# {request.Id}."));
        }

        var detailAttempt = await _details.Delete(request.Id);
        if (detailAttempt == 0)
        {
          errors.Add(new ExpectedError(ErrorCode.Connectivity, $"{nameof(_details)} Failed to delete detail ID# {request.Id}."));
          
        }

        if (errors.Any())
        {
          return Result.Fail(errors);
        }

        return Result.Ok();

      }
      catch (Exception ex)
      {
        return Result.Fail(ex);
      }
    }





  }
}

