using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class InventoryBatchDetails : Base
  {
    public InventoryBatchDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public InventoryBatchDetailsModel Get(string orgCode, string batchID, int sequence)
    {
      return apiClient.Endpoints.InventoryBatchDetails.Get( orgCode, batchID, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<InventoryBatchDetailsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.InventoryBatchDetails.Search(orgCode, $"{nameof(InventoryBatchDetailsModel.Batch)} eq '{searchValue}'");
    }
  }
}
