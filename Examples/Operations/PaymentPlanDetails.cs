using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PaymentPlanDetails : Base
  {
    public PaymentPlanDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentPlanDetailsModel Get(string orgCode, int payPlanID, int payNumber, int sequence)
    {
      return apiClient.Endpoints.PaymentPlanDetails.Get( orgCode, payPlanID, payNumber, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PaymentPlanDetailsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.PaymentPlanDetails.Search(orgCode, $"{nameof(PaymentPlanDetailsModel.PayPlanID)} eq {searchValue}");
    }
  }
}
