using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class WorkOrderItems : Base
  {
    public WorkOrderItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public WorkOrderItemsModel Get(string orgCode, int orderNbr, int orderLineNbr)
    {
      return apiClient.Endpoints.WorkOrderItems.Get( orgCode, orderNbr, orderLineNbr);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<WorkOrderItemsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.WorkOrderItems.Search(orgCode, $"{nameof(WorkOrderItemsModel.OrderNumber)} eq {searchValue}");
    }
  }
}
