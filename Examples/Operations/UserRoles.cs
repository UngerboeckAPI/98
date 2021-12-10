using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class UserRoles : Base
  {
    public UserRoles(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>    
    /// A basic retrieve example    
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="user">User ID</param>
    /// <param name="role">Role ID</param>
    /// <returns></returns>
    public UserRolesModel Get(string user, string role)
    {
      return apiClient.Endpoints.UserRoles.Get( user, role);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<UserRolesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.UserRoles.Search($"{nameof(UserRolesModel.Role)} eq '{searchValue}'"); //Note that this endpoint does not use OrgCode
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="user">User ID.  You can include a comma delimited list of User ID's or Role ID's, but not both. Example: "BILLW,ALEXY"</param>
    /// <param name="role">Role ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <returns>A message for how many UserRole relationships were created.</returns>
    public string Add(string user, string role)
    {
      var myUserRole = new UserRolesModel
      {         
        User = user,
        Role = role
      };

      return apiClient.Endpoints.UserRoles.Add( myUserRole);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>
    /// <param name="user">User ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <param name="role">Role ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <returns>A message for how many UserRole relationships were removed.</returns>
    public string Delete(string user, string role)
    {
      return apiClient.Endpoints.UserRoles.Delete( user, role);
    }
  }
}
