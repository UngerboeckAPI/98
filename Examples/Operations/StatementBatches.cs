using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class StatementBatches : Base
  {
    public StatementBatches(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public StatementBatchesModel Get(string orgCode, int batch)
    {
      return apiClient.Endpoints.StatementBatches.Get( orgCode, batch);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<StatementBatchesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.StatementBatches.Search(orgCode, $"{nameof(StatementBatchesModel.Description)} eq '{searchValue}'");
    }
  }
}


