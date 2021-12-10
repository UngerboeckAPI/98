using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountMailingLists : Base
  {
    public AccountMailingLists(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AccountMailingListsModel Get(string orgCode, int iD)
    {
      return apiClient.Endpoints.AccountMailingLists.Get( orgCode, iD);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>  
    public SearchResponse<AccountMailingListsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AccountMailingLists.Search(orgCode, $"{nameof(AccountMailingListsModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary> 
    public AccountMailingListsModel Add(string orgCode, string accountCode, int mailingListId)
    {
      var accountMailingList = new AccountMailingListsModel
      {
        OrganizationCode = orgCode,
        Account = accountCode,
        MailingList = mailingListId
      };

      return apiClient.Endpoints.AccountMailingLists.Add( accountMailingList);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>  
    public void Delete(string orgCode, int id)
    {
      apiClient.Endpoints.AccountMailingLists.Delete( orgCode, id);
    }

    /// <summary>
    /// Basic Edit example.
    /// </summary>
    /// <param name="orgCode">Organization code of account mailing list</param>
    /// <param name="id">ID of account mailing list</param>
    /// <param name="extCode">new External code of account mailing list</param>
    /// <param name="status">Set this to the type of the checklist.  You can use USISDKConstants.MailingListStatus to help you.  Example value is Ungerboeck.Api.Models.USISDKConstants.ChecklistTypes.Pending</param>
    /// <returns>Updated mailing list object</returns>
    public AccountMailingListsModel Edit(string orgCode, int id, string extCode,string status)
    {
      var acctMailingList = apiClient.Endpoints.AccountMailingLists.Get( orgCode, id);

      if (acctMailingList != null)
      {
        acctMailingList.ExternalCode = extCode;
        acctMailingList.Status = status;
      }

      return apiClient.Endpoints.AccountMailingLists.Update( acctMailingList);
    }
  }
}
