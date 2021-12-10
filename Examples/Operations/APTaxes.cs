using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class APTaxes: Base
  {
    public APTaxes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public APTaxesModel Get(string orgCode, string supplierAccountCode, int sequence)
    {
      return apiClient.Endpoints.APTaxes.Get( orgCode, supplierAccountCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<APTaxesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.APTaxes.Search(orgCode, $"{nameof(APTaxesModel.SupplierAccountCode)} eq '{searchValue}'");
    }
  }
}
