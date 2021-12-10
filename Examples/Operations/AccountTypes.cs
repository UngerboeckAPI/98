using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountTypes : Base
  {
    public AccountTypes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public AccountTypesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.AccountTypes.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AccountTypesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AccountTypes.Search(orgCode, $"{nameof(AccountTypesModel.Description)} eq '{searchValue}'");
    }

  }
}
