using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventPortalMessages : Base
  {
    public EventPortalMessages(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventPortalMessagesModel Get(int id)
    {
      return apiClient.Endpoints.EventPortalMessages.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventPortalMessagesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.EventPortalMessages.Search($"{nameof(EventPortalMessagesModel.OrganizationCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// An example of retrieving a specific event's data
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="eventID"></param>
    public SearchResponse<EventPortalMessagesModel> SearchByEvent(string orgCode, int eventID)
    {
      return apiClient.Endpoints.EventPortalMessages.Search($"{nameof(EventPortalMessagesModel.OrganizationCode)} eq '{orgCode}' AND {nameof(EventPortalMessagesModel.Event)} eq {eventID}");
    }

  }
}
