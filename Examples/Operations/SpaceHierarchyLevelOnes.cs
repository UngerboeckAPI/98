using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SpaceHierarchyLevelOnes : Base
  {
    public SpaceHierarchyLevelOnes(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceHierarchyLevelOnesModel Get(string orgCode, int sequence)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelOnes.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceHierarchyLevelOnesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceHierarchyLevelOnes.Search(orgCode, $"{nameof(SpaceHierarchyLevelOnesModel.Description)} eq '{searchValue}'");
    }
  }
}
