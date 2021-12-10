using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MailingLists : Base
  {
    public MailingLists(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MailingListsModel Get(string orgCode, int ID)
    {
      return apiClient.Endpoints.MailingLists.Get( orgCode, ID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MailingListsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.MailingLists.Search(orgCode, $"{nameof(MailingListsModel.Description)} eq '{searchValue}'");
    }
  }
}
