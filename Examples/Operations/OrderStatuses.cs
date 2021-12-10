using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OrderStatuses : Base
  {
    public OrderStatuses(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public OrderStatusesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.OrderStatuses.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<OrderStatusesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.OrderStatuses.Search(orgCode, $"{nameof(OrderStatusesModel.Description)} eq '{searchValue}'");
    }

  }
}
