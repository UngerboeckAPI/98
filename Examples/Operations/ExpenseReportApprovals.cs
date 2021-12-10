using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ExpenseReportApprovals : Base
  {
    public ExpenseReportApprovals(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExpenseReportApprovalsModel Get(int logSequence)
    {
      return apiClient.Endpoints.ExpenseReportApprovals.Get( logSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExpenseReportApprovalsModel> Search(int searchValue)
    {
      return apiClient.Endpoints.ExpenseReportApprovals.Search($"{nameof(ExpenseReportApprovalsModel.ExpenseReportID)} eq {searchValue}");
    }
  }
}





