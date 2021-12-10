using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class VoucherDistribution: Base
  {
    public VoucherDistribution(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public VoucherDistributionModel Get(string orgCode, int voucher, int sequence)
    {
      return apiClient.Endpoints.VoucherDistribution.Get( orgCode, voucher, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<VoucherDistributionModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.VoucherDistribution.Search(orgCode, $"{nameof(VoucherDistributionModel.Voucher)} eq {searchValue}");
    }
  }
}
