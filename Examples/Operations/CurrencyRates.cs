using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class CurrencyRates : Base
  {
    public CurrencyRates(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public CurrencyRatesModel Get(string code, int sequenceNumber)
    {
      return apiClient.Endpoints.CurrencyRates.Get( code, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<CurrencyRatesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.CurrencyRates.Search($"{nameof(CurrencyRatesModel.CurrencyCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public CurrencyRatesModel Add()
    {
      var currencyRates = new CurrencyRatesModel
      {
        CurrencyCode = "EUR",
        EffectiveDate = DateTime.UtcNow,
        LocalCurrencyRate = 1,
        ForeignCurrencyRate = 1,
        TriangulationCurrencyRate = 1,
        ExchangeRateCurrencyCode = "USD",
        ExchangeRateOrganizationCode = "10",
        FCGainMainAccount = "",
        FCLossMainAccount = ""
      };

      return apiClient.Endpoints.CurrencyRates.Add( currencyRates);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="code">Currency code of object to Update</param>
    /// <param name="sequenceNumber">Sequence Number of object to update</param>
    /// <returns></returns>
    public CurrencyRatesModel Edit(string code, int sequenceNumber, CurrencyRatesModel currencyRatesModelNew)
    {
      var currencyRates = apiClient.Endpoints.CurrencyRates.Get( code, sequenceNumber);

      if (currencyRates != null)
      {
        currencyRates.EffectiveDate = currencyRatesModelNew.EffectiveDate;
        currencyRates.LocalCurrencyRate = currencyRatesModelNew.LocalCurrencyRate;
        currencyRates.ForeignCurrencyRate = currencyRatesModelNew.ForeignCurrencyRate;
        currencyRates.TriangulationCurrencyRate = currencyRatesModelNew.TriangulationCurrencyRate;
        currencyRates.ExchangeRateCurrencyCode = currencyRatesModelNew.ExchangeRateCurrencyCode;
        currencyRates.ExchangeRateOrganizationCode = currencyRatesModelNew.ExchangeRateOrganizationCode;
      }

      return apiClient.Endpoints.CurrencyRates.Update(currencyRates);
    }
  }
}
