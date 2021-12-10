using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Spaces : Base
  {
    public Spaces(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public SpacesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.Spaces.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<SpacesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Spaces.Search(orgCode, $"{nameof(SpacesModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary> 
    public SpacesModel Add(string orgCode, string code, string Text)
    {
      var mySpace = new SpacesModel
      {
        Organization = orgCode,
        Code = code,
        SpaceDescription = Text,
      };

      return apiClient.Endpoints.Spaces.Add( mySpace);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>  
    public SpacesModel Edit(string orgCode, string code, string newText)
    {
      var mySpace = apiClient.Endpoints.Spaces.Get( orgCode, code);

      mySpace.SpaceDescription = newText;

      return apiClient.Endpoints.Spaces.Update( mySpace);
    }
  }
}
