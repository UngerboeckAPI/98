using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class InventoryBalances : Base
  {

    public InventoryBalances(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public InventoryBalancesModel Get(string orgCode, string item, string lotSerialNumber, string location, int fiscalYear, int fiscalPeriod)
    {
      return apiClient.Endpoints.InventoryBalances.Get( orgCode, item, lotSerialNumber, location, fiscalYear, fiscalPeriod);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<InventoryBalancesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.InventoryBalances.Search(orgCode, $"Location eq '{searchValue}'");
    }
  }
}
