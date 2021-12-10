using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class GLMainAccounts : Base
  {

    public GLMainAccounts(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public GLMainAccountsModel Get(string orgCode, string GLMainAccount)
    {
      return apiClient.Endpoints.GLMainAccounts.Get( orgCode, GLMainAccount);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<GLMainAccountsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.GLMainAccounts.Search(orgCode, $"{nameof(GLMainAccountsModel.Description)} eq '{searchValue}'");
    }
  }
}
