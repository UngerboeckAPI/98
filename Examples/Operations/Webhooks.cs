using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Webhooks : Base
  {
    public Webhooks(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public WebhooksModel Get(string orgCode, int sequenceNbr)
    {
      return apiClient.Endpoints.Webhooks.Get( orgCode, sequenceNbr);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<WebhooksModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Webhooks.Search(orgCode, $"{nameof(WebhooksModel.Description)} eq '{searchValue}'");
    }
  }
}
