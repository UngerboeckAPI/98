using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Functions : Base
  {
    public Functions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public FunctionsModel Get(string orgCode, int EventID, int functionID)
    {
      return apiClient.Endpoints.Functions.Get( orgCode, EventID, functionID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<FunctionsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.Functions.Search(orgCode, $"{nameof(FunctionsModel.EventID)} eq {searchValue}");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<FunctionsModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Function user fields of Issue Class = C (event sales), Issue Type code = 13, organization code = 10, and User Text 03 (TXT_03).  It will return functions where the value is 7854
      return apiClient.Endpoints.Functions.Search(orgCode, "C|13|10|UserNumber03 eq 7854");
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public FunctionsModel Edit(string orgCode, int EventID, int functionID, string newText)
    {
      var myFunction = apiClient.Endpoints.Functions.Get( orgCode, EventID, functionID);

      myFunction.Description = newText;

      return apiClient.Endpoints.Functions.Update( myFunction);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int EventID, int functionID)
    {
      apiClient.Endpoints.Functions.Delete( orgCode, EventID, functionID);
    }

    public FunctionsModel EditAdvanced(string orgCode, int EventID, int functionID)
    {

      var myFunction = apiClient.Endpoints.Functions.Get( orgCode, EventID, functionID);

      string myAccount = "00032364";  //Represents an account code
      string myContact = "ANA"; //Also represents an account code

      myFunction.Description = "New Description";
      myFunction.Class = "P";
      myFunction.EndDate = System.DateTime.Now;
      myFunction.EndTime = System.DateTime.Now;
      myFunction.StartTime = System.DateTime.Now;
      myFunction.StartDate = System.DateTime.Now;
      myFunction.Search = "NewSearch";
      myFunction.AlternateDescription = "Alt1";
      myFunction.AlternateDescription2 = "Alt2";
      myFunction.AlternateDescription3 = "Alt3";
      myFunction.AlternateDescription4 = "Alt4";
      myFunction.AlternateDescription5 = "Alt5";
      myFunction.Usage = "100";
      myFunction.Department = "ADMIN";
      myFunction.SOChecklist = "SERORDON";
      myFunction.FunctionGLCode = "GLCODE";
      myFunction.DefaultPaymentSchedule = "ONE";
      myFunction.Coordinator = myAccount;
      myFunction.Account = myAccount; //This should be a single account code
      myFunction.Contact = myContact;
      myFunction.UserText = "Text";
      myFunction.UserNumber = 15;
      myFunction.Space = "HALL-A";
      myFunction.BackgroundColor = 5287936; //This contains an OLE integer value.  You can convert from RGB.
      myFunction.TextColor = 10498160; //This contains an OLE integer value.  You can convert from RGB.
      myFunction.Statistics = "Y"; //Y or N
      myFunction.StatusCode = "25"; //This is the user-configurable status code on the function
      myFunction.ActualAttendance = 5;
      myFunction.SyncwithEventAttendance = "Y"; //Y or N.  If this is Y, the attendance figures will fill automatically.
      myFunction.ForecastAttendance = 5;
      myFunction.OrderedAttendance = 5;
      myFunction.RevisedAttendance = 5;
      myFunction.RegistrationQualification = "Y"; //Y or N
      myFunction.Location = "My Location";
      myFunction.WebAddress = "www.website.com";
      myFunction.TrackID = 17; //The integer value of the Track you wish to assign
      myFunction.SessionDetails = "Details Here";
      myFunction.EarlyDeadline = System.DateTime.Now;
      myFunction.StandardDeadline = System.DateTime.Now;

      //Check to make sure the functions are of the proper type before setting these properties
      //.BoothIssue = "TP" 'Used only used for Assignment Functions.  Set to the code value for the Assignment Issue Type
      //.CheckRegistrationConflicts = "Y" 'Used for registration functions only
      //.BookingLink = "1" 'For functions linked to bookings.Fill this in with the Booking Sequence Number.


      return apiClient.Endpoints.Functions.Update( myFunction);
    }

    public FunctionsModel InsertAfterFunction(string orgCode, int eventID, int functionID, string newText, string statusCode, string coordinator)
    {
      var myFunction = new FunctionsModel
      {
        OrganizationCode = orgCode,
        EventID = eventID,
        Description = newText,
        StatusCode = statusCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1),
        Coordinator = coordinator
      };

      return apiClient.Endpoints.Functions.InsertAfter( functionID, myFunction);
    }

    public FunctionsModel InsertIndentedFunction(string orgCode, int eventID, int functionID, string functionDescription, string statusCode, string coordinator)
    {
      var myFunction = new FunctionsModel
      {
        OrganizationCode = orgCode,
        EventID = eventID,
        Description = functionDescription,
        StatusCode = statusCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1),
        Coordinator = coordinator
      };

      return apiClient.Endpoints.Functions.InsertIndented( functionID, myFunction);
    }

    public FunctionsModel AddWithUserFields(string orgCode, int eventID, int functionID, string statusCode, string issueType, int newUserNumber03)
    {
      var myFunction = new FunctionsModel
      {
        OrganizationCode = orgCode,
        EventID = eventID,
        StatusCode = statusCode,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1)
      };

      //Here's how to add a user field set with values to a new function
      myFunction.FunctionUserFieldSets = new List<UserFields>();
      UserFields myUserField = new UserFields
      {
        //Note that class is always EventSales (C) and is automatically set in Ungerboeck.
        Type = issueType, //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
        UserNumber03 = newUserNumber03 //Set the value in the user field property
      };
      myFunction.FunctionUserFieldSets.Add(myUserField); //Then add it back into the EventModel object.  You can add multiple user field sets to the same event object before saving.

      return apiClient.Endpoints.Functions.InsertAfter( functionID, myFunction); //You can also use apiClient.Endpoints.InsertIndentedFunction()
    }
  }
}
