using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;


namespace Examples.Operations
{
  public class ExpenseReportDetails: Base
  {
    public ExpenseReportDetails(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public ExpenseReportDetailsModel Get(int sequence)
    {
      return apiClient.Endpoints.ExpenseReportDetails.Get( sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExpenseReportDetailsModel> Search(string searchValue)
    {
      return apiClient.Endpoints.ExpenseReportDetails.Search($"{nameof(ExpenseReportDetailsModel.Description)} eq '{searchValue}'");
    }
  }
}
