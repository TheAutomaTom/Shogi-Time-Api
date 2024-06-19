﻿using ST.Core.Application.Interfaces.Infrastructure;
using ST.Core.Application.Interfaces.Persistence.Cruds;
using ST.Core.Domain.Models.Cruds;
using ST.Core.Domain.Models.Cruds.Repo;
using ST.Core.Infra.ResultTypes;
using Mediator;
using Microsoft.Extensions.Logging;

namespace ST.Core.Application.Features.Cruds.CreateCrud
{
	public class CreateCrudHandler : IRequestHandler<CreateCrudRequest, Result<Crud>>
  {
    readonly ICrudDetailsRepository _details;
    readonly ICrudEntitiesRepository _entities;
    readonly ICache _cache;
    readonly ILogger<CreateCrudHandler> _logger;

    public CreateCrudHandler(ILogger<CreateCrudHandler> logger, ICache cache, ICrudEntitiesRepository entities, ICrudDetailsRepository details)
    {
      _logger = logger;
      _cache = cache;
      _entities = entities;
      _details = details;
    }

    public async ValueTask<Result<Crud>> Handle(CreateCrudRequest request, CancellationToken ct)
    {
      var validator = new CreateCrudValidator();
      var validationResult = await validator.ValidateAsync(request);

      if (validationResult.Errors.Count > 0)
      {
        return Result<Crud>.Fail(validationResult.Errors);
      }

      try
      {
        var entity = new Crud(request.Name, request.Department);
        var created = await _entities.Create(entity);

        if (created == null)
        {
          var e = new ExpectedError(ErrorCode.Connectivity, "Failed to create Entity.");
          return Result<Crud>.Fail(e);
        }

        var detail = new CrudDetail(created.Id, request.Description, request.Tags);
        var createdDetailId = await _details.Create(detail);
        if (createdDetailId == 0)
        {
          var e = new ExpectedError(ErrorCode.Connectivity, "Failed to create Detail.  There may be remnants of a Entity with no related Detail.");
          return Result<Crud>.Fail(e);
        }

        var result = new Crud(created.Id, entity, detail);

        try
        {        
          var cache = await _cache.Create(CacheKey.Key(result.Id), result);
        }
        catch (Exception ex)
        {
          _logger.LogWarning($"Cache Failed while updating Crud ID# {result.Id}. {ex.Message}");
        }

        return Result<Crud>.Ok(result);

      }
      catch (Exception ex)
      {
        return Result<Crud>.Fail(ex);
      }
    }





  }
}
