using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Exhibitors : Base
  {
    public Exhibitors(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ExhibitorsModel Get(string orgCode, int exhibitorID) 
    {
      return apiClient.Endpoints.Exhibitors.Get( orgCode, exhibitorID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ExhibitorsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Exhibitors.Search(orgCode, $"{nameof(ExhibitorsModel.AccountCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<ExhibitorsModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Exhibitors user fields of Issue Class = C (event sales), Issue Type code = 42, organization code = 10, and User Text 01 (TXT_01).  It will return exhibitors where the value is '8'      
      return apiClient.Endpoints.Exhibitors.Search(orgCode, "C|42|10|UserText01 eq '8'");
    }

    /// <summary>
    /// How to retrieve all exhibitors per event. 
    /// </summary> 
    public IEnumerable<ExhibitorsModel> GetByEvent(string orgCode, int eventID)
    {
      return apiClient.Endpoints.Exhibitors.Search(orgCode, $"Event eq {eventID}").Results;
    }

    /// <summary>
    /// A basic add example for event and account
    /// </summary>  
    public ExhibitorsModel Add(string orgCode, int eventID, string accountCode)
    {
      var myExhibitor = new ExhibitorsModel
      {
        OrganizationCode = orgCode,
        Event = eventID,
        AccountCode = accountCode
      };

      return apiClient.Endpoints.Exhibitors.Add( myExhibitor);
    }

    /// <summary>
    /// A basic add example with a constructed Exhibitors Model object
    /// </summary>  
    public ExhibitorsModel Add(ExhibitorsModel myExhibitor)
    {
      return apiClient.Endpoints.Exhibitors.Add( myExhibitor);
    }

    /// <summary>
    /// A basic edit example for comments
    /// </summary> 
    public ExhibitorsModel Edit(string orgCode, int exhibitorID, string newComments)
    {
      var myExhibitor = apiClient.Endpoints.Exhibitors.Get( orgCode, exhibitorID);

      myExhibitor.Comments = newComments;

      return apiClient.Endpoints.Exhibitors.Update( myExhibitor);
    }

    /// <summary>
    /// A basic edit example with a constructed Exhibitors Model object
    /// </summary> 
    public ExhibitorsModel Edit(ExhibitorsModel myExhibitor)
    {
      return apiClient.Endpoints.Exhibitors.Update( myExhibitor);
    }

  }
}
