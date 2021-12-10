using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class MarketLists : Base
  {
    public MarketLists(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public MarketListsModel Get(string orgCode, string Code)
    {
      return apiClient.Endpoints.MarketLists.Get(orgCode, Code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<MarketListsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.MarketLists.Search(orgCode, $"{nameof(MarketListsModel.Description)} eq '{searchValue}'");
    }
  }
}
