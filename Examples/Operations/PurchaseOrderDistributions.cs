using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PurchaseOrderDistributions : Base
  {
    public PurchaseOrderDistributions(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrderDistributionsModel Get(string orgCode, int number, int sequence, int line)
    {
      return apiClient.Endpoints.PurchaseOrderDistributions.Get( orgCode, number, sequence, line);
    }


    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<PurchaseOrderDistributionsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.PurchaseOrderDistributions.Search(orgCode, $"{nameof(PurchaseOrderDistributionsModel.Number)} eq {searchValue}");
    }
  }
}
