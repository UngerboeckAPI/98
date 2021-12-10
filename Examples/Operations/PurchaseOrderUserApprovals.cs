using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class PurchaseOrderUserApprovals : Base
  {
    public PurchaseOrderUserApprovals(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrderUserApprovalsModel Get(string orgCode, int sequence)
    {
      return apiClient.Endpoints.PurchaseOrderUserApprovals.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<PurchaseOrderUserApprovalsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PurchaseOrderUserApprovals.Search(orgCode, $"{nameof(PurchaseOrderUserApprovalsModel.User)} eq '{searchValue}'");
    }
  }
}
