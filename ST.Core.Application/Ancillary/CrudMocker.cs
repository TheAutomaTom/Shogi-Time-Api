﻿using Bogus;
using ST.Core.Domain.Models.Cruds;
using ST.Core.Domain.Models.Cruds.Repo;
using ST.Core.Domain.Models.Cruds.Responses;

namespace ST.Core.Application.Ancillary
{
  public class CrudMocker
  {
    readonly static Random _rando = new Random();
    readonly static int _descLength = _rando.Next(3, 15);
    readonly static int _tagsCount = _rando.Next(1, 8);

    //readonly Faker<CrudEntity> _crudEntityFaker;
    //readonly Faker<CrudDetail> _crudDetailFaker;
    readonly Faker<Crud> _crudFaker;

    public CrudMocker()
    {
      _crudFaker = new Faker<Crud>()
          .RuleFor(c => c.Id, f => f.Random.Int())
          .RuleFor(c => c.Name, f => f.Commerce.ProductName())
          .RuleFor(c => c.Department, f => f.Commerce.Department())
          .RuleFor(c => c.Detail, f => new Faker<CrudDetail>()
            //.RuleFor((d, c) => d.Id, d => c.Id) // Bogus may not be able to do this.
            .RuleFor(d => d.Description, f => f.Lorem.Lines(_descLength))
            .RuleFor(d => d.Tags, f => f.Lorem.Words(_tagsCount))
          );

    }

    /// <summary> This method ensures the CrudDetail.Id matches it's CrudEntity.Id </summary>
    public IEnumerable<CrudUpdate> Generate(int count = 1)
    {
      var fakes = _crudFaker.Generate(count);
      var results = new List<CrudUpdate>();
      foreach (var crud in fakes)
      {
        results.Add(new CrudUpdate()
        {
          Name = crud.Name,
          Department = crud.Department,
          Description = crud.Detail.Description,
          Tags = crud.Detail.Tags
        });
      }

      return results;
    }


  }
}
