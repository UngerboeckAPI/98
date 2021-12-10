using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OpportunityStatuses : Base
  {
    public OpportunityStatuses(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public OpportunityStatusesModel Get(string orgCode, string code, string designation)
    {
      return apiClient.Endpoints.OpportunityStatuses.Get( orgCode, code, designation);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<OpportunityStatusesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.OpportunityStatuses.Search(orgCode, $"{nameof(OpportunityStatusesModel.Designation)} eq '{searchValue}'");
    }
  }
}
