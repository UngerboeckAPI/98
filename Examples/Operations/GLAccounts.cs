using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLAccounts : Base
  {
    public GLAccounts(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public GlAccountsModel Get(string orgCode, string gLAccount, string subAccount)
    {
      return apiClient.Endpoints.GLAccounts.Get( orgCode, gLAccount, subAccount);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GlAccountsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.GLAccounts.Search(orgCode, $"{nameof(GlAccountsModel.SubAccountType)} eq '{searchValue}'");
    }
  }
}
