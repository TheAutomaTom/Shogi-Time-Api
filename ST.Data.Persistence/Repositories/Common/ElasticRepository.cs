﻿using ST.Core.Domain.Models.Cruds.Repo;
using ST.Core.Infra.Models.Common;
using ST.Core.Infra.Models.SearchParams;
using Nest;

namespace ST.Data.Persistence.Repositories.Common
{
	public abstract class ElasticRepository<T> : IElasticRepository<T> where T : AuditableEntity
  {
    protected readonly IElasticClient _client;

    protected ElasticRepository(IElasticClient client)
    {
      _client = client;
    }

    public async Task<int> Create(T item)
    {

      var indexRequest = new IndexRequest<T>(item);
      var result = await _client.IndexAsync(indexRequest);

      if (result.ServerError != null)
      {
        throw new Exception(result.ServerError.Error.Reason);
      }

      return Int32.Parse(result.Id);

    }

    /// <summary> This is, realistically, only used by Entities. </summary>
    public Task<IReadOnlyList<T>> Read(Paging? paging = null, ST.Core.Infra.Models.SearchParams.DateRangeFilter? dateRange = null)
    {
      throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<T>> Read()
    {
      var responses = _client.Search<T>(s =>
          s.Query(q => q
           .MatchAll()
          )
      );
      var results = new List<T>();
      foreach (var response in responses.Documents)
      {
        results.Add(response);
      }
      return results;

    }

    public async Task<T> Read(int id)
    {
      var response = await _client.GetAsync<CrudDetail>(id);
      if (response.Source != null)
      {
        return response.Source as T;
      }
      return null;

    }

    public async Task<bool> Update(T item)
    {

      // I think the intent of <T, K> is to allow for smaller Dtos to be sent as updates to T.
      var request = new UpdateRequest<T, T>(item.Id)
      {
        Doc = item
      };


      var result = await _client.UpdateAsync(request);

      if (result.ServerError != null)
      {
        throw new Exception(result.ServerError.Error.Reason);
      }

      return result.IsValid;
    }


    public async Task<int> Delete(int id)
    {
      var deleteRequest = new DeleteRequest<T>(id);
      var result = await _client.DeleteAsync(deleteRequest);

      if (result.ServerError != null)
      {
        throw new Exception(result.ServerError.Error.Reason);
      }

      return result.IsValid ? 1 : 0;
    }

    public async Task<int> Delete(T item)
    {
      var deleteRequest = new DeleteRequest<T>(item.Id);
      var result = await _client.DeleteAsync(deleteRequest);

      if (result.ServerError != null)
      {
        throw new Exception(result.ServerError.Error.Reason);
      }

      return result.IsValid ? 1 : 0;
    }



	}
}
