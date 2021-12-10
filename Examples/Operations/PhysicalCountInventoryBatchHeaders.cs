using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class PhysicalCountInventoryBatchHeaders : Base
  {
    public PhysicalCountInventoryBatchHeaders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PhysicalCountInventoryBatchHeadersModel Get(string orgCode, string batchID)
    {
      return apiClient.Endpoints.PhysicalCountInventoryBatchHeaders.Get( orgCode, batchID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<PhysicalCountInventoryBatchHeadersModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.PhysicalCountInventoryBatchHeaders.Search(orgCode, $"{nameof(PhysicalCountInventoryBatchHeadersModel.TotalUnits)} eq {searchValue}");
    }
  }
}
