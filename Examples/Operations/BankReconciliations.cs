using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class BankReconciliations : Base
  {
    public BankReconciliations(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public BankReconciliationsModel Get(string orgCode, int sequenceNumber)
    {
      return apiClient.Endpoints.BankReconciliations.Get( orgCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BankReconciliationsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.BankReconciliations.Search(orgCode, $"{nameof(BankReconciliationsModel.Description)} eq '{searchValue}'");
    }
  }
}



