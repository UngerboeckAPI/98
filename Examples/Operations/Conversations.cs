using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;


namespace Examples.Operations
{
  public class Conversations : Base
  {
    public Conversations(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ConversationsModel Get(int id)
    {
      return apiClient.Endpoints.Conversations.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ConversationsModel> Search(string searchValue)
    {
      return apiClient.Endpoints.Conversations.Search($"{nameof(ConversationsModel.Subject)} eq '{searchValue}'");
    }

  }
}
