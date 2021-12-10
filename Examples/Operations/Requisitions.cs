using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Requisitions : Base
  {
    public Requisitions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RequisitionsModel Get(string orgCode, int number)
    {
      return apiClient.Endpoints.Requisitions.Get( orgCode, number);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<RequisitionsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Requisitions.Search(orgCode, $"{nameof(RequisitionsModel.Description)} eq '{searchValue}'");
    }
  }
}
