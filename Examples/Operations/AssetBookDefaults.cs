using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class AssetBookDefaults : Base
  {
    public AssetBookDefaults(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public AssetBookDefaultsModel Get(string orgCode, int sequenceNumber)
    {
      return apiClient.Endpoints.AssetBookDefaults.Get( orgCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AssetBookDefaultsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AssetBookDefaults.Search(orgCode, $"{nameof(AssetBookDefaultsModel.Method)} eq '{searchValue}'");
    }
  }
}
