using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PriceListItems : Base
  {
    public PriceListItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PriceListItemsModel Get(string orgCode, string priceList, int sequence)
    {
      return apiClient.Endpoints.PriceListItems.Get( orgCode, priceList, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PriceListItemsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PriceListItems.Search(orgCode, $"{nameof(PriceListItemsModel.PriceList)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="priceList">The price list code</param>
    /// <param name="form">The Code of the associated Order Form.  These can be found on the System Menu -> Order Forms.</param>
    /// <param name="type">The Code of the associated Resource.  These can be found on the System Menu -> Resources.</param>    
    public PriceListItemsModel Add(string orgCode, string priceList, string form, string type)
    {
      var value = new PriceListItemsModel
      {
        OrganizationCode = orgCode,
        PriceList = priceList,
        Form = form,
        Type = type
      };

      return apiClient.Endpoints.PriceListItems.Add( value);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <returns></returns>
    public PriceListItemsModel Edit(string orgCode, string priceList, int sequence, string newDescription)
    {
      var value = apiClient.Endpoints.PriceListItems.Get( orgCode, priceList, sequence);

      value.Description = newDescription;

      return apiClient.Endpoints.PriceListItems.Update( value);
    }

    public PriceListItemsModel EditAdvanced(string orgCode, string priceList, int sequence)
    {
      var value = apiClient.Endpoints.PriceListItems.Get( orgCode, priceList, sequence);

      string strAccountCode = "FAKEACCT"; //Use an account code

      value.ChangedBy = strAccountCode;
      value.AlternateDescription1 = "AltDesc1";
      value.UnitofMeasure = "EA";
      value.ShowEndDate = "Y";
      value.ShowEndTime = "Y";
      value.ShowExtendedCharge = "Y";
      value.ShowRate = "Y";
      value.ShowStartDate = "Y";
      value.ShowStartTime = "Y";
      value.ShowUnits = "Y";
      value.UseTieredCosts = "N";
      value.UseTieredPricing = "N";
      value.SetupPriceListDetailSeqNbr = 0; // this value must be null or 0 (it is used by packages)
      value.CostTier1Type = "T";
      value.PricingTier1Type = "U";

      // Please check the v30 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.

      return apiClient.Endpoints.PriceListItems.Update( value);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string priceList, int sequence)
    {
      apiClient.Endpoints.PriceListItems.Delete( orgCode, priceList, sequence);
    }
  }
}
