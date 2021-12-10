using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class OrganizationParameters : Base
  {
    public OrganizationParameters(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public OrganizationParametersModel Get(string orgCode, string applicationCode, string parameterCode)
    {
      return apiClient.Endpoints.OrganizationParameters.Get( orgCode, applicationCode, parameterCode);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<OrganizationParametersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.OrganizationParameters.Search(orgCode, $"{nameof(OrganizationParametersModel.ApplicationCode)} eq '{searchValue}'");
    }
  }
}
