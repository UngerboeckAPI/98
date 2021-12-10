using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Countries : Base
  {
    public Countries(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public CountriesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.Countries.Get( orgCode, code);
    }

    public CountriesModel GetWithSelect(string orgCode, string code)
    {
      var options = new Ungerboeck.Api.Models.Options.Subjects.Countries { Select = { nameof(CountriesModel.Description) } };
      return apiClient.Endpoints.Countries.Get(orgCode, code, options);
    }


    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CountriesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Countries.Search(orgCode, $"{nameof(CountriesModel.Description)} eq '{searchValue}'");
    }
  }
}
