using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Affiliations : Base
  {
    public Affiliations(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AffiliationsModel Get(string orgCode, string affiliationCode)
    {
      return apiClient.Endpoints.Affiliations.Get( orgCode, affiliationCode);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>
    public SearchResponse<AffiliationsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Affiliations.Search(orgCode, $"{nameof(AffiliationsModel.Description)} eq '{searchValue}'");
    }

  }
}
