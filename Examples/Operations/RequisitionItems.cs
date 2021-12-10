using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RequisitionItems : Base
  {
    public RequisitionItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RequisitionItemsModel Get(string orgCode, int number, int sequence)
    {
      return apiClient.Endpoints.RequisitionItems.Get( orgCode, number, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<RequisitionItemsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.RequisitionItems.Search(orgCode, $"{nameof(RequisitionItemsModel.Number)} eq {searchValue}");
    }
  }
}
