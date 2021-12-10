using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RelationshipTypes : Base
  {
    public RelationshipTypes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RelationshipTypesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.RelationshipTypes.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<RelationshipTypesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.RelationshipTypes.Search(orgCode, $"{nameof(RelationshipTypesModel.Class)} eq '{searchValue}'");
    }
  }
}
