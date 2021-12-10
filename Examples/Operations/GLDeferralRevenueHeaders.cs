using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLDeferralRevenueHeaders : Base
  {
    public GLDeferralRevenueHeaders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public GLDeferralRevenueHeadersModel Get(int sequence)
    {
      return apiClient.Endpoints.GLDeferralRevenueHeaders.Get( sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GLDeferralRevenueHeadersModel> Search(string searchValue)
    {
      return apiClient.Endpoints.GLDeferralRevenueHeaders.Search($"{nameof(GLDeferralRevenueHeadersModel.Description)} eq '{searchValue}'");
    }
  }
}

