using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;
namespace Examples.Operations
{
  public class GroupProfiles : Base
  {
    public GroupProfiles(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public GroupProfilesModel Get(string orgCode, int groupProfileId)
    {
      return apiClient.Endpoints.GroupProfiles.Get( orgCode, groupProfileId);
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<GroupProfilesModel> SearchForUserFields(string orgCode)
    {
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Group Profile User fields of Issue Class = C, Issue Type code = CK, Organization Code = 10, and User Number 01 (AMT_01).
      //It will return group profiles where the value is 10
      return apiClient.Endpoints.GroupProfiles.Search(orgCode, "C|DU|10|UserNumber01 eq 10");
      
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<GroupProfilesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.GroupProfiles.Search(orgCode, $"{nameof(GroupProfilesModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// Retrieve a group profile by Group Profile description.
    /// </summary> 
    public GroupProfilesModel GetByDescription(string orgCode, string description)
    {
      GroupProfilesModel returnGroupProfile = null;

      var groupProfilesResult = apiClient.Endpoints.GroupProfiles.Search(orgCode, $"Description eq '{description}'").Results;

      if (groupProfilesResult?.Count() == 1)
      {
        returnGroupProfile = groupProfilesResult.First();
      }

      return returnGroupProfile;
    }

    /// <summary>
    /// A basic add example with the minimal required fields
    /// </summary> 
    public GroupProfilesModel Add(string orgCode, string account, int duration)
    {
      var myGroupProfile = new GroupProfilesModel
      {
        OrganizationCode = orgCode,
        Description = "An Added Group Profile",
        Account = account,
        DurationDays = duration
      };

      return apiClient.Endpoints.GroupProfiles.Add( myGroupProfile);
    }

    /// <summary>
    /// A basic add example with a constructed Group Profile Model object
    /// </summary> 
    public GroupProfilesModel Add(GroupProfilesModel myGroupProfile)
    {
      return apiClient.Endpoints.GroupProfiles.Add( myGroupProfile);
    }

    /// <summary>
    /// A basic edit example for status
    /// </summary> 
    public GroupProfilesModel Edit(string orgCode, int id, int newDuration)
    {
      var myGroupProfile = apiClient.Endpoints.GroupProfiles.Get( orgCode, id);

      myGroupProfile.DurationDays = newDuration;

      return apiClient.Endpoints.GroupProfiles.Update( myGroupProfile);
    }

    /// <summary>
    /// A basic edit example with a constructed Group Profile Model object
    /// </summary> 
    public GroupProfilesModel Edit(GroupProfilesModel myGroupProfile)
    {
      return apiClient.Endpoints.GroupProfiles.Update( myGroupProfile);
    }

    /// <summary>
    /// A basic delete group profile example
    /// </summary>    
    public void Delete(string orgCode, int id)
    {
      apiClient.Endpoints.GroupProfiles.Delete(orgCode, id);  
    }

  }
}

