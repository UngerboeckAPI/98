using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MarketSegments : Base
  {
    public MarketSegments(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MarketSegmentsModel Get(string orgCode, string major, string minor)
    {
      return apiClient.Endpoints.MarketSegments.Get( orgCode, major, minor);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MarketSegmentsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.MarketSegments.Search(orgCode, $"{nameof(MarketSegmentsModel.Major)} eq '{searchValue}'");
    }
  }
}
