using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class InventoryStats : Base
  {
    public InventoryStats(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public InventoryStatsModel Get(string orgCode, string item, string space, string lotSerialNumber)
    {
      return apiClient.Endpoints.InventoryStats.Get( orgCode, item, space, lotSerialNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<InventoryStatsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.InventoryStats.Search(orgCode, $"{nameof(InventoryStatsModel.Item)} eq '{searchValue}'");
    }

  }
}
