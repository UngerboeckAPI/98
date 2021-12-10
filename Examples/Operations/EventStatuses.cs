using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventStatuses : Base
  {
    public EventStatuses(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventStatusesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.EventStatuses.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventStatusesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.EventStatuses.Search(orgCode, $"{nameof(EventStatusesModel.Description)} eq '{searchValue}'");
    }

  }
}
