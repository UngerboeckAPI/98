using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventJobClasses : Base
  {
    public EventJobClasses(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventJobClassesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.EventJobClasses.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventJobClassesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.EventJobClasses.Search(orgCode, $"{nameof(EventJobClassesModel.Description)} eq '{searchValue}'");
    }

  }
}
