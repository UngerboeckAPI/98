using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class FiscalPeriods : Base
  {
    public FiscalPeriods(ApiClient apiClient) : base(apiClient)
    { 
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public FiscalPeriodsModel Get(string orgCode, string module, int fiscalYear, int fiscalPeriod)
    {
      return apiClient.Endpoints.FiscalPeriods.Get( orgCode, module, fiscalYear, fiscalPeriod);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<FiscalPeriodsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.FiscalPeriods.Search(orgCode, $"{nameof(FiscalPeriodsModel.Module)} eq '{searchValue}'");
    }
  }
}
