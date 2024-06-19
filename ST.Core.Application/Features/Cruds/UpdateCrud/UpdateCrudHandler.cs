﻿using ST.Core.Application.Interfaces.Infrastructure;
using ST.Core.Application.Interfaces.Persistence.Cruds;
using ST.Core.Domain.Models.Cruds;
using ST.Core.Domain.Models.Cruds.Repo;
using ST.Core.Infra.ResultTypes;
using Mediator;
using Microsoft.Extensions.Logging;

namespace ST.Core.Application.Features.Cruds.UpdateCrud
{
	public class UpdateCrudHandler : IRequestHandler<UpdateCrudRequest, Result<Crud>>
  {
    readonly ICrudDetailsRepository _details;
    readonly ICrudEntitiesRepository _entities;
    readonly ICache _cache;
    readonly ILogger<UpdateCrudHandler> _logger;

    public UpdateCrudHandler(ILogger<UpdateCrudHandler> logger, ICache cache, ICrudEntitiesRepository entities, ICrudDetailsRepository details)
    {
      _logger = logger;
      _cache = cache;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result<Crud>> Handle(UpdateCrudRequest request, CancellationToken cancellationToken)
    {
      // Validate request
      var validator = new UpdateCrudValidator();
      var validationResult = await validator.ValidateAsync(request);
      if (validationResult.Errors.Count > 0)
      {
        return Result<Crud>.Fail(validationResult.Errors);
      }


      // Attempt process
      try
      {

        var toUpdate = new Crud()
        {
          Id = request.Id,
          Name = request.Name,
          Department = request.Department,
          Detail = new CrudDetail()
          {
            Id = request.Id,
            Description = request.Description,
            Tags = request.Tags
          }

        };

        var entityUpdate = await _entities.Update(toUpdate);
        if (!entityUpdate)
        {
          return Result<Crud>.Fail(new ExpectedError(ErrorCode.DoesNotExist, $"Cannot update non-existent Crud Id: {request.Id}"));
        }

        var detailUpdate = await _details.Update(toUpdate.Detail);
        if (!detailUpdate)
        {
          return Result<Crud>.Fail(new ExpectedError(ErrorCode.DoesNotExist, $"{nameof(_entities)} Failed to update Detail ID# {request.Id}.  There may be remnants of an Entity without Detail saved."));
        }

        try
        {
          var removeFromCache = await _cache.Delete(CacheKey.Key(toUpdate.Id));
          var cache = await _cache.Create(CacheKey.Key(toUpdate.Id), toUpdate);
        } catch (Exception ex)
        {
          _logger.LogWarning($"Cache Failed while updating Crud ID# {toUpdate.Id}. {ex.Message}");
        }

        return Result<Crud>.Ok(toUpdate);
      }
      catch (Exception ex)
      {
        return Result<Crud>.Fail(ex);
      }




    }




  }
}
