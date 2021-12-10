using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RequisitionApproval : Base
  {
    public RequisitionApproval(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RequisitionApprovalModel Get(string orgCode, int number, int line, int sequence)
    {
      return apiClient.Endpoints.RequisitionApproval.Get( orgCode, number, line, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<RequisitionApprovalModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.RequisitionApproval.Search(orgCode, $"{nameof(RequisitionApprovalModel.Number)} eq {searchValue}");
    }
  }
}
