using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class UserDefinedFields : Base
  {
    public UserDefinedFields(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public UserDefinedFieldsModel Get(string orgCode, string issueOpportunityClass, string issueOpportunityType, int sequenceNumber)
    {
      return apiClient.Endpoints.UserDefinedFields.Get( orgCode, issueOpportunityClass, issueOpportunityType, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<UserDefinedFieldsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.UserDefinedFields.Search(orgCode, $"{nameof(UserDefinedFieldsModel.IssueOpportunityClass)} eq '{searchValue}'");
    }
  }
}
