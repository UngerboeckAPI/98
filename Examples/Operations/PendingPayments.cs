using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PendingPayments : Base
  {
    public PendingPayments(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public PendingPaymentsModel Get(string orgCode, int pendingPaymentID)
    {
      return apiClient.Endpoints.PendingPayments.Get( orgCode, pendingPaymentID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PendingPaymentsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PendingPayments.Search(orgCode, $"{nameof(PendingPaymentsModel.TransactionTSM)} eq '{searchValue}'");
    }

  }
}
