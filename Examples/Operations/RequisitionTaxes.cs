using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RequisitionTaxes : Base
  {

    public RequisitionTaxes(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public RequisitionTaxesModel Get(string orgCode, int number, int line, int sequence)
    {
      return apiClient.Endpoints.RequisitionTaxes.Get( orgCode, number, line, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<RequisitionTaxesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.RequisitionTaxes.Search(orgCode, $"{nameof(RequisitionTaxesModel.Number)} eq {searchValue}");
    }
  }
}
