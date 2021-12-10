using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class APPaymentTaxes : Base
  {
    public APPaymentTaxes(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public APPaymentTaxesModel Get(string orgCode, int sequence, int voucher, int voucherTaxSeq)
    {
      return apiClient.Endpoints.APPaymentTaxes.Get( orgCode, sequence, voucher, voucherTaxSeq);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<APPaymentTaxesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.APPaymentTaxes.Search(orgCode, $"{nameof(APPaymentTaxesModel.Sequence)} eq {searchValue}");
    }

  }
}
