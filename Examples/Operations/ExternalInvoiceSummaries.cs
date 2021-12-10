using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ExternalInvoiceSummaries : Base
  {
    public ExternalInvoiceSummaries(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public ExternalInvoiceSummariesModel Get(int summaryId)
    {
      return apiClient.Endpoints.ExternalInvoiceSummaries.Get( summaryId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ExternalInvoiceSummariesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.ExternalInvoiceSummaries.Search($"{nameof(ExternalInvoiceSummariesModel.Status)} eq '{searchValue}'");
    }

  }
}
