using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class VoucherApprovals: Base
  {
    public VoucherApprovals(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public VoucherApprovalsModel Get(string orgCode, int voucher, int voucherDistrSeq, int sequence)
    {
      return apiClient.Endpoints.VoucherApprovals.Get( orgCode, voucher, voucherDistrSeq, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<VoucherApprovalsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.VoucherApprovals.Search(orgCode, $"{nameof(VoucherApprovalsModel.VoucherNumber)} eq {searchValue}");
    }
  }
}
