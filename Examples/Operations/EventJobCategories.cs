using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class EventJobCategories : Base
  {
    public EventJobCategories(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventJobCategoriesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.EventJobCategories.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventJobCategoriesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.EventJobCategories.Search(orgCode, $"{nameof(EventJobCategoriesModel.Description)} eq '{searchValue}'");
    }

  }
}
