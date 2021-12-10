using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
 public class PurchaseOrderApproval : Base
  {
    public PurchaseOrderApproval(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrderApprovalModel Get(string orgCode, int number, int itemSequence, int sequence)
    {
      return apiClient.Endpoints.PurchaseOrderApproval.Get( orgCode, number, itemSequence, sequence);
    }

    public PurchaseOrderApprovalModel Add(string orgCode, int number, int itemSequence)
    {
      var purchaseOrderApprovalModel = new PurchaseOrderApprovalModel
      {
        Organization = orgCode,
        Number = number,
        ItemSequence = itemSequence,
        Level = "9",
        Action = "A",
        Note = "Purchase Order Approved by APIUNIT user",
      };

      return apiClient.Endpoints.PurchaseOrderApproval.Add( purchaseOrderApprovalModel);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PurchaseOrderApprovalModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PurchaseOrderApproval.Search(orgCode, $"{nameof(PurchaseOrderApprovalModel.Level)} eq '{searchValue}'");
    }
  }
}
