using System.Collections.Generic;
using System.Net.Http;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  public class AccountAffiliations : Base
  {
    public AccountAffiliations(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary>    
    public AccountAffiliationsModel Get(string orgCode, string accountCode, string affiliationCode)
    {
      return apiClient.Endpoints.AccountAffiliations.Get(orgCode, accountCode, affiliationCode);
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    public AccountAffiliationsModel Add(string orgCode, string accountCode, string affiliationCode)
    {
      var myAccountAffiliation = new AccountAffiliationsModel
      {
        OrganizationCode = orgCode,
        AccountCode = accountCode,
        AffiliationCode = affiliationCode
      };

      return apiClient.Endpoints.AccountAffiliations.Add(myAccountAffiliation);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(string orgCode, string accountCode, string affiliationCode)
    {
      apiClient.Endpoints.AccountAffiliations.Delete(orgCode, accountCode, affiliationCode);  
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>    
    public SearchResponse<AccountAffiliationsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AccountAffiliations.Search(orgCode, $"{nameof(AccountAffiliationsModel.AccountCode)} eq '{searchValue}'");
    }
  }
}
