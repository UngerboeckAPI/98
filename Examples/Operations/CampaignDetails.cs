using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CampaignDetails : Base
  {
    public CampaignDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public CampaignDetailsModel Get(string orgCode, string campaignDesignation, string campaign, int sequenceNumber)
    {
      return apiClient.Endpoints.CampaignDetails.Get( orgCode, campaignDesignation, campaign, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CampaignDetailsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.CampaignDetails.Search(orgCode, $"{nameof(CampaignDetailsModel.CampaignDesignation)} eq '{searchValue}'");
    }

  }
}
