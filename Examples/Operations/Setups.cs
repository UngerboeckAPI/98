using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Setups : Base
  {
    public Setups(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SetupsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.Setups.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SetupsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Setups.Search(orgCode, $"{nameof(SetupsModel.Description)} eq '{searchValue}'");
    }
  }
}
