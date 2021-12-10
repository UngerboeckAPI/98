using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using System.Collections.Generic;
using Ungerboeck.Api.Models.Options;
using System.Net.Http;

namespace Ungerboeck.Api.Sdk.Endpoints
{
  /// <summary>
  /// Find endpoint calls for this subject here.
  /// </summary>
  public class UserRoles : Base<UserRolesModel>
  {
    protected internal UserRoles(ApiClient api) : base(api) { }

    /// <summary>
    /// Use this endpoint to search for a list of this subject.
    /// </summary>
    /// <param name="searchMetadata">After searching, this will contain search info, such as ResultsTotal.  If your search resulted in more than one page, this will also be filled with API links to navigate pages.</param>
    /// <param name="searchOData">Fill this with OData to query for what you are looking for.  We highly suggest reading our 'Search Using the API' knowledge base article or Ungerboeck API Github examples to learn how to do this. </param>
    /// <param name="options">This contains optional configurations used for searching.</param>
    /// <returns>A list of this subject's model.</returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<UserRolesModel> Search(string searchOData, Search options = null)
    {
      return base.Search(null, searchOData, options);
    }

    /// <summary>
    /// Use this endpoint to get a single entry of this subject with parameters.
    /// </summary>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A single model for this subject.</returns>
    public UserRolesModel Get(string user, string role, Ungerboeck.Api.Models.Options.Subjects.UserRoles options = null)
    {
      return base.Get(new { user, role }, options);
    }

    /// <summary>
    /// Add a user to a role.  You can do more than one.  You can include a comma delimited list of User ID's or Role ID's, but not both.
    /// </summary>
    /// <param name="model">This should contain a filled model of this subject.  Note that any null model properties will be ignored for the save.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>A newly added, single model for this subject.</returns>
    public string Add(UserRolesModel userRole, Ungerboeck.Api.Models.Options.Subjects.UserRoles options = null)
    {
      System.Threading.Tasks.Task<string> userRoleTask = PostAsync<UserRolesModel, string>(Client, "UserRoles", userRole, options);
      return CustomSync(userRoleTask);
    }

    /// <summary>
    /// Remove a User from a Role.  Multiple are allowed
    /// </summary>
    /// <param name="user">The User ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <param name="role">The Role ID.  You can include a comma delimited list of User ID's or Role ID's, but not both.</param>
    /// <param name="options">This contains optional configurations.</param>
    /// <returns>Nothing if successful.</returns>
    public string Delete(string user, string role, Ungerboeck.Api.Models.Options.Subjects.UserRoles options = null)
    {
      System.Threading.Tasks.Task<HttpResponseMessage> userRoleTask = DeleteAsync(Client, $"UserRoles/{user}/{role}", options);

      var updatedModel = DeleteAsync<string>(userRoleTask.Result);
      return CustomSync(updatedModel);
    }
    
    private static async System.Threading.Tasks.Task<T> DeleteAsync<T>(HttpResponseMessage response)
    {
      var updatedModel = await response.Content.ReadAsAsync<T>();
      return updatedModel;
    }
  }
}
