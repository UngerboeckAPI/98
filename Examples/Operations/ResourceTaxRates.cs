using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ResourceTaxRates : Base
  {

    public ResourceTaxRates(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public ResourceTaxRatesModel Get(string orgCode, int sequence)
    {
      return apiClient.Endpoints.ResourceTaxRates.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ResourceTaxRatesModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.ResourceTaxRates.Search(orgCode, $"{nameof(ResourceTaxRatesModel.Event)} eq {searchValue}");
    }
  }
}
