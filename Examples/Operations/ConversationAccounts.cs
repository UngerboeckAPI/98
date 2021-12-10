using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ConversationAccounts : Base
  {
    public ConversationAccounts(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ConversationAccountsModel Get(int id)
    {
      return apiClient.Endpoints.ConversationAccounts.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ConversationAccountsModel> Search(string searchValue)
    {
      return apiClient.Endpoints.ConversationAccounts.Search($"{nameof(ConversationAccountsModel.Account)} eq '{searchValue}'");
    }

  }
}
