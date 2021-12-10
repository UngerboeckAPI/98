using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class FiscalYears : Base
  {
    public FiscalYears(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public FiscalYearsModel Get(string orgCode, int fiscalYear)
    {
      return apiClient.Endpoints.FiscalYears.Get( orgCode, fiscalYear);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<FiscalYearsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.FiscalYears.Search(orgCode, $"{nameof(FiscalYearsModel.Year)} eq {searchValue}");
    }
  }
}
