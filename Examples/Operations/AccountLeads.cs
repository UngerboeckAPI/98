using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class AccountLeads : Base
  {
    public AccountLeads(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AccountLeadsModel Get(string strOrgCode, int intLeadsID)
    {
      return apiClient.Endpoints.AccountLeads.Get(strOrgCode, intLeadsID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AccountLeadsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AccountLeads.Search(orgCode, $"{nameof(AccountLeadsModel.ContactFirstName)} eq '{searchValue}'");
    }

    /// <summary>
    /// Add new Account leads.
    /// </summary>
    /// <param name="orgCode">Organization code of Account lead</param>
    /// <param name="contactFirstName">contact First Name of Account lead</param>
    /// <param name="contactLastName">contact First Name of Account lead</param>
    /// <returns></returns>
    public AccountLeadsModel Add(string orgCode, string contactFirstName, string contactLastName)
    {
      var accountLeadsModel = new AccountLeadsModel()
      {
        OrganizationCode = orgCode,
        ContactFirstName = contactFirstName,
        ContactLastName = contactLastName
      };

      return apiClient.Endpoints.AccountLeads.Add(accountLeadsModel);
    }

    /// <summary>
    /// Basic edit example
    /// </summary>
    /// <param name="leadID">lead id to update</param>
    /// <param name="newContactFirstName">new first name of Account lead</param>
    /// <param name="newContactLastName">new last name of Account lead</param>
    /// <returns></returns>
    public AccountLeadsModel Edit(string orgCode, int leadID, string newContactFirstName, string newContactLastName)
    {
      AccountLeadsModel accountLeadsModel = apiClient.Endpoints.AccountLeads.Get(orgCode, leadID);
      if (accountLeadsModel != null)
      {
        accountLeadsModel.ContactFirstName = newContactFirstName;
        accountLeadsModel.ContactLastName = newContactLastName;
      }

      return apiClient.Endpoints.AccountLeads.Update(accountLeadsModel);
    }
    /// <summary>
    /// Bsic delete example
    /// </summary>
    /// <param name="leadID">Lead Id to delete</param>
    public void Delete(string orgCode, int leadID)
    {
      apiClient.Endpoints.AccountLeads.Delete(orgCode, leadID);
    }
  }
}
