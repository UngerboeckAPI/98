using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class VoucherPaymentInstructions : Base
  {
    public VoucherPaymentInstructions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public VoucherPaymentInstructionsModel Get(string orgCode, int voucher, int sequenceNumber)
    {
      return apiClient.Endpoints.VoucherPaymentInstructions.Get( orgCode, voucher, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<VoucherPaymentInstructionsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.VoucherPaymentInstructions.Search(orgCode, $"{nameof(VoucherPaymentInstructionsModel.Voucher)} eq {searchValue}");
    }
  }
}
