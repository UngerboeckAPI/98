using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class MarketListItems : Base
  {
    public MarketListItems(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public MarketListItemsModel Get(string orgCode, string MarketList, int Sequence)
    {
      return apiClient.Endpoints.MarketListItems.Get(orgCode, MarketList, Sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<MarketListItemsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.MarketListItems.Search(orgCode, $"{nameof(MarketListItemsModel.MarketList)} eq '{searchValue}'");
    }
  }
}
