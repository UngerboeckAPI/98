using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ExternalInvoiceDetails : Base
  {
    public ExternalInvoiceDetails(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public ExternalInvoiceDetailsModel Get(int detailId)
    {
      return apiClient.Endpoints.ExternalInvoiceDetails.Get( detailId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ExternalInvoiceDetailsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.ExternalInvoiceDetails.Search($"{nameof(ExternalInvoiceDetailsModel.DetailIDExt)} eq {searchValue}");
    }

  }
}
