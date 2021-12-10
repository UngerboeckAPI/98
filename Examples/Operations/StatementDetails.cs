using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class StatementDetails : Base
  {
    public StatementDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public StatementDetailsModel Get(string orgCode, int batchSequence,int headerSequence, int sequence)
    {
      return apiClient.Endpoints.StatementDetails.Get( orgCode, batchSequence, headerSequence, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<StatementDetailsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.StatementDetails.Search(orgCode, $"{nameof(StatementDetailsModel.BatchSequence)} eq {searchValue}");
    }
  }
}
