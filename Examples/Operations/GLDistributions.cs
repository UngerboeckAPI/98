using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLDistributions : Base
  {
    public GLDistributions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public GLDistributionsModel Get(string orgCode,string recordType, int sequenceNumber)
    {
      return apiClient.Endpoints.GLDistributions.Get( orgCode, recordType, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GLDistributionsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.GLDistributions.Search(orgCode, $"{nameof(GLDistributionsModel.RecordType)} eq '{searchValue}'");
    }
  }
}




