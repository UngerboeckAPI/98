using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class DailyRevenueJobControls : Base
  {
    public DailyRevenueJobControls(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public DailyRevenueJobControlsModel Get(string orgCode,int sequence)
    {
      return apiClient.Endpoints.DailyRevenueJobControls.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<DailyRevenueJobControlsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.DailyRevenueJobControls.Search(orgCode, $"{nameof(DailyRevenueJobControlsModel.RecordType)} eq '{searchValue}'");
    }
  }
}
