using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class BankAccounts: Base
  {
    public BankAccounts(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public BankAccountsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.BankAccounts.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BankAccountsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.BankAccounts.Search(orgCode, $"{nameof(BankAccountsModel.GLAccount)} eq '{searchValue}'");
    }
  }
}
