using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountsReceivableVouchers : Base
  {
    public AccountsReceivableVouchers(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AccountsReceivableVouchersModel Get(string orgCode, int voucherSequence)
    {
      return apiClient.Endpoints.AccountsReceivableVouchers.Get( orgCode, voucherSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AccountsReceivableVouchersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AccountsReceivableVouchers.Search(orgCode, $"{nameof(AccountsReceivableVouchersModel.Description)} eq '{searchValue}'");
    }

  }
}
