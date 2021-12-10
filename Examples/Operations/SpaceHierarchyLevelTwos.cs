using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
namespace Examples.Operations
{
  public class SpaceHierarchyLevelTwos : Base
  {
    public SpaceHierarchyLevelTwos(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceHierarchyLevelTwosModel Get(string orgCode, int levelOneSequence, int levelTwoSequence)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelTwos.Get( orgCode, levelOneSequence, levelTwoSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceHierarchyLevelTwosModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelTwos.Search(orgCode, $"{nameof(SpaceHierarchyLevelTwosModel.Description)} eq '{searchValue}'");
    }
  }
}
