using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventsPriceList : Base
  {
    public EventsPriceList(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventsPriceListModel Get(string orgCode, string code, int eventID)
    {
      return apiClient.Endpoints.EventsPriceList.Get( orgCode, code, eventID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventsPriceListModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.EventsPriceList.Search(orgCode, $"{nameof(EventsPriceListModel.EventID)} eq {searchValue}");
    }
  }
}
