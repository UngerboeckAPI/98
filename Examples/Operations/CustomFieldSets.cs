using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CustomFieldSets : Base
  {
    public CustomFieldSets(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public CustomFieldSetsModel Get(string orgCode, string Class, string code)
    {
      return apiClient.Endpoints.CustomFieldSets.Get( orgCode, Class, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CustomFieldSetsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.CustomFieldSets.Search(orgCode, $"{nameof(CustomFieldSetsModel.Class)} eq '{searchValue}'");
    }
  }
}
