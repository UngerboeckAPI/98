using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class SpaceSetups : Base
  {
    public SpaceSetups(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceSetupsModel Get(string orgCode, string space, string code)
    {
      return apiClient.Endpoints.SpaceSetups.Get( orgCode, space, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceSetupsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceSetups.Search(orgCode, $"{nameof(SpaceSetupsModel.Space)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example.
    /// </summary>
    public SpaceSetupsModel Add(string orgCode, string space, string code)
    {
      var spaceSetup = new SpaceSetupsModel
      {
        OrganizationCode = orgCode,
        Space = space,
        Code = code
      };

      return apiClient.Endpoints.SpaceSetups.Add( spaceSetup);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    public SpaceSetupsModel Edit(string orgCode, string space, string code, string newText)
    {
      var spaceSetup = apiClient.Endpoints.SpaceSetups.Get( orgCode, space, code);

      spaceSetup.Description = newText;

      return apiClient.Endpoints.SpaceSetups.Update( spaceSetup);
    }

    /// <summary>
    /// A delete example
    /// </summary>
    public void Delete(string orgCode, string space, string code)
    {
      apiClient.Endpoints.SpaceSetups.Delete( orgCode, space, code);
    }
  }
}
