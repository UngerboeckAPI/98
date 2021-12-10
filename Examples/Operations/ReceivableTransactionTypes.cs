using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ReceivableTransactionTypes : Base
  {
    public ReceivableTransactionTypes(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public ReceivableTransactionTypesModel Get(string orgCode, string TSM)
    {
      return apiClient.Endpoints.ReceivableTransactionTypes.Get( orgCode, TSM);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ReceivableTransactionTypesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.ReceivableTransactionTypes.Search(orgCode, $"{nameof(ReceivableTransactionTypesModel.Description)} eq '{searchValue}'");
    }

  }
}
