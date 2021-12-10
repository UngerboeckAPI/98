using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountsReceivableVoucherAllocations : Base
  {
    public AccountsReceivableVoucherAllocations(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public AccountsReceivableVoucherAllocationsModel Get(string orgCode, int voucherSequence, int voucherDetailSequence)
    {
      return apiClient.Endpoints.AccountsReceivableVoucherAllocations.Get( orgCode, voucherSequence, voucherDetailSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<AccountsReceivableVoucherAllocationsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.AccountsReceivableVoucherAllocations.Search(orgCode, $"{nameof(AccountsReceivableVoucherAllocationsModel.VoucherSequence)} eq {searchValue}");
    }

  }
}
