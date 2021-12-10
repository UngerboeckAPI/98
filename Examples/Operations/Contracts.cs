using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Contracts : Base
  {
    public Contracts(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public ContractsModel Get(string orgCode, int sequence)
    {
      return apiClient.Endpoints.Contracts.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ContractsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Contracts.Search(orgCode, $"{nameof(ContractsModel.Account)} eq '{searchValue}'");
    }
  }
}
