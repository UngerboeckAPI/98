using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class WorkOrders : Base
  {
    public WorkOrders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public WorkOrdersModel Get(string orgCode, int order, string department)
    {
      return apiClient.Endpoints.WorkOrders.Get( orgCode, order, department);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<WorkOrdersModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.WorkOrders.Search(orgCode, $"{nameof(WorkOrdersModel.Event)} eq {searchValue}");
    }
  }
}
