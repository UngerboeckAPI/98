using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PaymentPlans : Base
  {
    public PaymentPlans(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PaymentPlansModel Get(string orgCode, int paymentPlanID)
    {
      return apiClient.Endpoints.PaymentPlans.Get( orgCode, paymentPlanID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PaymentPlansModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PaymentPlans.Search(orgCode, $"{nameof(PaymentPlansModel.Description)} eq '{searchValue}'");
    }
  }
}
