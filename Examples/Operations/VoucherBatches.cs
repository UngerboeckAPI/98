using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class VoucherBatches : Base
  {
    public VoucherBatches(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public VoucherBatchesModel Get(string orgCode, string batch)
    {
      return apiClient.Endpoints.VoucherBatches.Get( orgCode, batch);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<VoucherBatchesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.VoucherBatches.Search(orgCode, $"{nameof(VoucherBatchesModel.Description)} eq '{searchValue}'");
    }
  }
}
