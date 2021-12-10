using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class StatementHeaders : Base
  {
    public StatementHeaders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public StatementHeadersModel Get(string orgCode, int batchSequence,int sequence)
    {
      return apiClient.Endpoints.StatementHeaders.Get( orgCode, batchSequence, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<StatementHeadersModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.StatementHeaders.Search(orgCode, $"{nameof(StatementHeadersModel.BatchSequence)} eq {searchValue}");
    }
  }
}



