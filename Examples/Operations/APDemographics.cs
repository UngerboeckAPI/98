using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class APDemographics : Base
  {
    public APDemographics(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public APDemographicsModel Get(string orgCode, string supplier)
    {
      return apiClient.Endpoints.APDemographics.Get( orgCode, supplier);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<APDemographicsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.APDemographics.Search(orgCode, $"{nameof(APDemographicsModel.Name)} eq '{searchValue}'");
    }

  }
}
