using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PurchaseOrderTaxes : Base
  {
    public PurchaseOrderTaxes(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public PurchaseOrderTaxesModel Get(string orgCode, int number, int itemSequence, int sequence)
    {
      return apiClient.Endpoints.PurchaseOrderTaxes.Get( orgCode, number, itemSequence, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PurchaseOrderTaxesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.PurchaseOrderTaxes.Search(orgCode, $"{nameof(PurchaseOrderTaxesModel.Number)} eq {searchValue}");
    }

  }
}
