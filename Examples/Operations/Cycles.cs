using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Cycles : Base
  {
    public Cycles(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public CyclesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.Cycles.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CyclesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Cycles.Search(orgCode, $"{nameof(CyclesModel.Description)} eq '{searchValue}'");
    }
  }
}
