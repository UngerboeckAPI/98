using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ExternalInvoices : Base
  {
    public ExternalInvoices(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public ExternalInvoicesModel Get(int headerId)
    {
      return apiClient.Endpoints.ExternalInvoices.Get( headerId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ExternalInvoicesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.ExternalInvoices.Search($"{nameof(ExternalInvoicesModel.SupplierNameExt)} eq '{searchValue}'");
    }

  }
}
