using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class Booths : Base
  {
    public Booths(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public BoothsModel Get(string orgCode, int sequenceNumber)
    {
      return apiClient.Endpoints.Booths.Get( orgCode, sequenceNumber);
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<BoothsModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Booth User fields of Issue Class = A (booths), Issue Type code = RN, organization code = 10, and User Number 01 (AMT_01).  It will return accounts where the value is 31
      return apiClient.Endpoints.Booths.Search(orgCode, "A|RN|10|UserNumber01 eq 31");      
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BoothsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.Booths.Search(orgCode, $"{nameof(BoothsModel.Event)} eq {searchValue}");
    }

    /// <summary>
    /// A retrieve all booths on a function.
    /// </summary> 
    public IEnumerable<BoothsModel> GetByEventFunction(string orgCode, int eventID, int functionID) {
      return apiClient.Endpoints.Booths.Search(orgCode, $"Function eq {functionID} and Event eq {eventID}").Results;
    }

    /// <summary>
    /// Retrieve a booth by Booth name. Event and function are required
    /// </summary> 
    public BoothsModel GetByName(string orgCode, int eventID, int functionID, string boothName) {
      BoothsModel returnBooth = null;

      var boothsResult = apiClient.Endpoints.Booths.Search(orgCode, $"Function eq {functionID} and Event eq {eventID} and Booth eq '{boothName}'").Results;

      if (boothsResult?.Count() == 1) {
        returnBooth = boothsResult.First();
      }

      return returnBooth;
    }

    /// <summary>
    /// A basic add example with the minimal required fields
    /// </summary> 
    public BoothsModel Add(string orgCode, int eventId, int functionId, string assignCode) {
      var myBooth = new BoothsModel {
        OrganizationCode = orgCode,
        Event = eventId,
        Function = functionId,
        Booth = assignCode
      };

      return apiClient.Endpoints.Booths.Add( myBooth);
    }

    /// <summary>
    /// A basic add example with a constructed Booth Model object
    /// </summary> 
    public BoothsModel Add(BoothsModel myBooth) {
      return apiClient.Endpoints.Booths.Add( myBooth);
    }

    /// <summary>
    /// A basic edit example for status
    /// </summary> 
    public BoothsModel Edit(string orgCode, int seqNumber, string newStatus) {
      var myBooth = apiClient.Endpoints.Booths.Get( orgCode, seqNumber);

      myBooth.BoothStatus = newStatus;

      return apiClient.Endpoints.Booths.Update( myBooth);
    }

    /// <summary>
    /// A basic edit example with a constructed Exhibitors Model object
    /// </summary> 
    public BoothsModel Edit(BoothsModel myBooth) {
      return apiClient.Endpoints.Booths.Update( myBooth);
    }

    /// <summary>
    /// A basic delete booth example
    /// </summary>    
    public void Delete(string orgCode, int seqNumber) {
      apiClient.Endpoints.Booths.Delete(orgCode, seqNumber);  
    }

  }
}
