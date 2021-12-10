using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLDeferralRevenueDetails : Base
  {
    public GLDeferralRevenueDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public GLDeferralRevenueDetailsModel Get(int HdrSequence, int sequence)
    {
      return apiClient.Endpoints.GLDeferralRevenueDetails.Get( HdrSequence, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GLDeferralRevenueDetailsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.GLDeferralRevenueDetails.Search($"{nameof(GLDeferralRevenueDetailsModel.HdrSequence)} eq {searchValue}");
    }
  }
}

