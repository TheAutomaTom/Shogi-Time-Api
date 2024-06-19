using HotChocolate.Types;

namespace ST.Core.Infra.Models.Common
{
  // This allows multiple types to be returned in query results as an object named "SearchResult"
  [UnionType("SearchResult")]
  public interface IGqlResultType
  {



  }
}
