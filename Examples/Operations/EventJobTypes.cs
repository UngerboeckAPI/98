using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventJobTypes : Base
  {
    public EventJobTypes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventJobTypesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.EventJobTypes.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventJobTypesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.EventJobTypes.Search(orgCode, $"{nameof(EventJobTypesModel.Description)} eq '{searchValue}'");
    }

  }
}
