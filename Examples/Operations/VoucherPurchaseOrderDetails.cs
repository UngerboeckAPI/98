using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class VoucherPurchaseOrderDetails: Base
  {
    public VoucherPurchaseOrderDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public VoucherPurchaseOrderDetailsModel Get(string orgCode, int voucher, int purchaseOrderNumber, int sequence)
    {
      return apiClient.Endpoints.VoucherPurchaseOrderDetails.Get( orgCode, voucher, purchaseOrderNumber, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<VoucherPurchaseOrderDetailsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.VoucherPurchaseOrderDetails.Search(orgCode, $"{nameof(VoucherPurchaseOrderDetailsModel.Voucher)} eq {searchValue}");
    }
  }
}
