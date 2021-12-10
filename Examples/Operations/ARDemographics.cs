using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class ARDemographics : Base
  {
    public ARDemographics(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public ARDemographicsModel Get(string orgCode, string account)
    {
      return apiClient.Endpoints.ARDemographics.Get( orgCode, account);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ARDemographicsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.ARDemographics.Search(orgCode, $"{nameof(ARDemographicsModel.PriceClass)} eq '{searchValue}'");
    }

    /// <summary>
    /// Add new ARDemographic
    /// </summary>
    /// <param name="aRDemographicsModel"></param>
    /// <returns></returns>
    public ARDemographicsModel Add(string orgCode, string account)
    {
      var aRDemographicModel = new ARDemographicsModel()
      {
        Organization = orgCode,
        Account = account,
        Terms = "30",
        CreditLimit = 100,
        HoldOrders = "W",
        EnteredBy = "JEFFK",
        ChangedBy = "JEFFK",
      };

      return apiClient.Endpoints.ARDemographics.Add( aRDemographicModel);
    }

    /// <summary>
    /// A basic edit ARDemographic example
    /// </summary> 
    public ARDemographicsModel EditWithPartialMode(string orgeCode, string account, decimal newCreditLimit)
    {
      ARDemographicsModel aRDemographicsModel = apiClient.Endpoints.ARDemographics.Get( orgeCode, account);
      if (aRDemographicsModel != null)
      {
        aRDemographicsModel.CreditLimit = newCreditLimit;
      }

      return apiClient.Endpoints.ARDemographics.Update( aRDemographicsModel);
    }

    /// <summary>
    /// A basic delete ARDemographic example
    /// </summary>    
    public void Delete(string orgCode, string account)
    {
      apiClient.Endpoints.ARDemographics.Delete( orgCode, account);  
    }
  }
}
