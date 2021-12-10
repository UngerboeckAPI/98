using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Concessions : Base
  {
    public Concessions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ConcessionsModel Get(string orgCode, int sequenceNumber)
    {
      return apiClient.Endpoints.Concessions.Get( orgCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ConcessionsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Concessions.Search(orgCode, $"{nameof(ConcessionsModel.MeetingAccount)} eq '{searchValue}'");
    }
  }
}
