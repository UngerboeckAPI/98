using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class VoucherTaxes: Base
  {
    public VoucherTaxes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public VoucherTaxesModel Get(string orgCode, int voucher, int sequence)
    {
      return apiClient.Endpoints.VoucherTaxes.Get( orgCode, voucher, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<VoucherTaxesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.VoucherTaxes.Search(orgCode, $"{nameof(VoucherTaxesModel.GLAccount)} eq '{searchValue}'");
    }
  }
}
