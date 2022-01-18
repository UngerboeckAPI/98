using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace Examples.Operations
{
  public class EventTaskDetails : Base
  {
    public EventTaskDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public EventTaskDetailsModel Get(int eventTaskConfigurationID)
    {
      return apiClient.Endpoints.EventTaskDetails.Get(eventTaskConfigurationID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventTaskDetailsModel> Search(string orgCode, int eventId)
    {
      return apiClient.Endpoints.EventTaskDetails.Search($"{nameof(EventTaskDetailsModel.OrganizationCode)} eq '{orgCode}' AND {nameof(EventTaskDetailsModel.Event)} eq {eventId}");
    }

    /// <summary>
    /// An example of retrieving a specific task's data
    /// </summary>
    /// <param name="taskID"></param>
    public SearchResponse<EventTaskDetailsModel> SearchByTask(int taskID)
    {
      return apiClient.Endpoints.EventTaskDetails.Search($"{nameof(EventTaskDetailsModel.EventTaskID)} eq {taskID}");
    }

  }
}
