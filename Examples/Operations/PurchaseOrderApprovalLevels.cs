using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class PurchaseOrderApprovalLevels : Base
  {
    public PurchaseOrderApprovalLevels(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrderApprovalLevelsModel Get(string orgCode, string approvalType, int approvalLevel)
    {
      return apiClient.Endpoints.PurchaseOrderApprovalLevels.Get( orgCode, approvalType, approvalLevel);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<PurchaseOrderApprovalLevelsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PurchaseOrderApprovalLevels.Search(orgCode, $"{nameof(PurchaseOrderApprovalLevelsModel.Type)} eq '{searchValue}'");
    }
  }
}
