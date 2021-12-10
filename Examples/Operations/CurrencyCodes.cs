using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class CurrencyCodes : Base
  {
    public CurrencyCodes(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public CurrencyCodesModel Get(string Code)
    {
      return apiClient.Endpoints.CurrencyCodes.Get( Code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<CurrencyCodesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.CurrencyCodes.Search($"{nameof(CurrencyCodesModel.Description)} eq '{searchValue}'");
    }

    public CurrencyCodesModel GetWithSelect(string code)
    {
      var options = new Ungerboeck.Api.Models.Options.Subjects.CurrencyCodes { Select = { nameof(CurrencyCodesModel.Description) } };
      return apiClient.Endpoints.CurrencyCodes.Get(code, options);
    }
  }
}
