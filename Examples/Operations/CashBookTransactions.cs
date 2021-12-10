using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CashBookTransactions : Base
  {
    public CashBookTransactions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public CashBookTransactionsModel Get(string orgCode, int sequence)
    {
      return apiClient.Endpoints.CashBookTransactions.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CashBookTransactionsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.CashBookTransactions.Search(orgCode, $"{nameof(CashBookTransactionsModel.Description)} eq '{searchValue}'");
    }
  }
}


