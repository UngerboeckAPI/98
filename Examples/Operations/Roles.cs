using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Roles : Base
  {
    public Roles(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RolesModel Get(string ID)
    {
      return apiClient.Endpoints.Roles.Get( ID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<RolesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.Roles.Search($"{nameof(RolesModel.DisplayName)} eq '{searchValue}'"); //Note that this endpoint does not use OrgCode
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <param name="organizationCode">This will be used as the initial organization for the Role.</param>
    /// <param name="ID">This will be the Role ID the Role can use to login.  It will be permanent.</param>
    /// <param name="displayName">This will be the name of the new Role</param>
    /// <returns></returns>
    public RolesModel Add(string ID, string displayName)
    {
      var myRole = new RolesModel
      {         
        ID = ID,
        DisplayName = displayName
      };

      return apiClient.Endpoints.Roles.Add( myRole);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="ID">This is the Role ID</param>
    /// <param name="email">You can edit the Role's email.  This example shows how.</param>
    /// <returns></returns>
    public RolesModel Edit(string ID, string displayName)
    {
      var myRole = apiClient.Endpoints.Roles.Get( ID);

      myRole.DisplayName = displayName;

      return apiClient.Endpoints.Roles.Update( myRole);
    }    
  }
}
