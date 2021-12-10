using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ConversationMessages : Base
  {
    public ConversationMessages(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ConversationMessagesModel Get(int id)
    {
      return apiClient.Endpoints.ConversationMessages.Get(id);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ConversationMessagesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.ConversationMessages.Search($"{nameof(ConversationMessagesModel.Message)} eq '{searchValue}'");
    }

    /// <summary>
    /// A search example using the conversation id.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ConversationMessagesModel> SearchByConversation(int conversationID)
    {
      return apiClient.Endpoints.ConversationMessages.Search($"{nameof(ConversationMessagesModel.ConversationID)} eq {conversationID}");
    }

  }
}
