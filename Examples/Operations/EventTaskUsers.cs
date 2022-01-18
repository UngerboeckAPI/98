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
  public class EventTaskUsers : Base
  {
    public EventTaskUsers(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public EventTaskUsersModel Get(int eventTaskUsersID)
    {
      return apiClient.Endpoints.EventTaskUsers.Get(eventTaskUsersID);
    }


    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventTaskUsersModel> SearchByAccount(string searchValue)
    {
      return apiClient.Endpoints.EventTaskUsers.Search($"{nameof(EventTaskUsersModel.AccountCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// An example of retrieving a specific task's data
    /// </summary>
    /// <param name="taskID"></param>
    public SearchResponse<EventTaskUsersModel> SearchByTask(int taskID)
    {
      return apiClient.Endpoints.EventTaskUsers.Search($"{nameof(EventTaskUsersModel.EventTaskID)} eq {taskID}");
    }

  }
}
