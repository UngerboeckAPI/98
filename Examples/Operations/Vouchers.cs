using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Vouchers : Base
  {
    public Vouchers(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public VouchersModel Get(string orgCode, int voucher)
    {
      return apiClient.Endpoints.Vouchers.Get( orgCode, voucher);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<VouchersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Vouchers.Search(orgCode, $"{nameof(VouchersModel.City)} eq '{searchValue}'");
    }
  }
}


