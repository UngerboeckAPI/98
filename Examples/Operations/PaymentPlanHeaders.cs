using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PaymentPlanHeaders : Base
  {
    public PaymentPlanHeaders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentPlanHeadersModel Get(string orgCode, int payPlanID, int payNumber)
    {
      return apiClient.Endpoints.PaymentPlanHeaders.Get( orgCode, payPlanID, payNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PaymentPlanHeadersModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.PaymentPlanHeaders.Search(orgCode, $"{nameof(PaymentPlanHeadersModel.PayPlanID)} eq {searchValue}");
    }
  }
}
