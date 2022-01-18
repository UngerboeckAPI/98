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
  public class Tasks : Base
  {
    public Tasks(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public TasksModel Get(int taskID)
    {
      return apiClient.Endpoints.Tasks.Get(taskID);
    }

    /// <summary>
    /// An example of retrieving a specific task's data
    /// </summary>
    /// <param name="taskID"></param>
    public SearchResponse<TasksModel> Search(int taskID)
    {
      return apiClient.Endpoints.Tasks.Search($"{nameof(TasksModel.ID)} eq {taskID}");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<TasksModel> SearchByOrgCodeAndDescription(string orgCode, string description)
    {
      return apiClient.Endpoints.Tasks.Search($"{nameof(TasksModel.OrganizationCode)} eq '{orgCode}' AND {nameof(TasksModel.Description)} eq '{description}'");
    }
    
  }
}
