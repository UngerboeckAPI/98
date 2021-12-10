using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SpaceFeatures : Base
  {
    public SpaceFeatures(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceFeaturesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.SpaceFeatures.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceFeaturesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceFeatures.Search(orgCode, $"{nameof(SpaceFeaturesModel.Description)} eq '{searchValue}'");
    }
  }
}
