using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class DailyRevenueAndCostAnalysis : Base
  {
    public DailyRevenueAndCostAnalysis(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public DailyRevenueAndCostAnalysisModel Get(string orgCode,int revenueSequence)
    {
      return apiClient.Endpoints.DailyRevenueAndCostAnalysis.Get( orgCode,revenueSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<DailyRevenueAndCostAnalysisModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.DailyRevenueAndCostAnalysis.Search(orgCode, $"{nameof(DailyRevenueAndCostAnalysisModel.RevenueAmount)} gt {searchValue}");
    }
  }
}
