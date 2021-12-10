using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;


namespace Examples.Operations
{
  public class BudgetTransactions : Base
  {

    public BudgetTransactions(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public BudgetTransactionsModel Get(string orgCode, string batch, int transactionNum)
    {
      return apiClient.Endpoints.BudgetTransactions.Get( orgCode, batch, transactionNum);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<BudgetTransactionsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.BudgetTransactions.Search(orgCode, $"{nameof(BudgetTransactionsModel.Batch)} eq '{searchValue}'");
    }
  }
}
