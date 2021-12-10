using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class PriceList : Base
  {
    public PriceList(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PriceListModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.PriceList.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PriceListModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PriceList.Search(orgCode, $"{nameof(PriceListModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="code">The price list code</param>   
    public PriceListModel Add(string orgCode, string code)
    {
      string strAccountCode = "FAKEACCT"; //Use an account code

      var value = new PriceListModel
      {
        OrganizationCode = orgCode,
        Code = code,
        Description = $"{code} Price List",
        Currency = "***",
        StartDate = new DateTime(2020, 1, 1),
        EndDate = new DateTime(2020, 1, 31),
        AdvancePrice = "Y",
        LatePrice = "Y",
        OrgDefault = "N",
        Retire = "N",
        PriceClass = "PC",
        TaxInclusive = "Y",
        EnteredBy = strAccountCode
      };

      return apiClient.Endpoints.PriceList.Add( value);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <returns></returns>
    public PriceListModel Edit(string orgCode, string code, string newDescription)
    {
      var value = apiClient.Endpoints.PriceList.Get( orgCode, code);

      value.Description = newDescription;

      return apiClient.Endpoints.PriceList.Update( value);
    }

    public PriceListModel EditAdvanced(string orgCode, string code)
    {
      var value = apiClient.Endpoints.PriceList.Get( orgCode, code);

      string strAccountCode = "FAKEACCT"; //Use an account code

      value.Description = $"{code} Price List";
      value.Currency = "***";
      value.StartDate = new DateTime(2020, 1, 1);
      value.EndDate = new DateTime(2020, 1, 31);
      value.AdvancePrice = "Y";
      value.LatePrice = "Y";
      value.OrgDefault = "N";
      value.Retire = "N";
      value.PriceClass = "PC";
      value.TaxInclusive = "Y";
      value.ChangedBy = strAccountCode;     

      // Please check the v30 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.

      return apiClient.Endpoints.PriceList.Update( value);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, string code)
    {
      apiClient.Endpoints.PriceList.Delete( orgCode, code);
    }
  }
}
