using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class AssetTransactions: Base
  {
    public AssetTransactions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public AssetTransactionsModel Get(string orgCode, string assetCode, string bookCode, int sequence)
    {
      return apiClient.Endpoints.AssetTransactions.Get( orgCode, assetCode, bookCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AssetTransactionsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AssetTransactions.Search(orgCode, $"{nameof(AssetTransactionsModel.Asset)} eq '{searchValue}'");
    }
  }
}
