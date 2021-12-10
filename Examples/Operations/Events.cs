using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

namespace Examples.Operations
{
  public class Events:Base
  {
    public Events(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public EventsModel Get(string orgCode, int eventID)
    {
      return apiClient.Endpoints.Events.Get( orgCode, eventID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<EventsModel> Search(string orgCode, string searchValue)
    {      
      return apiClient.Endpoints.Events.Search( orgCode, $"{nameof(EventsModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public SearchResponse<EventsModel> SearchForUserFields(string orgCode)
    {            
      //For non-account user fields, the format is [User field Class]|[User field Type]|[Organization Code]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Event user fields of Issue Class = C (event sales), Issue Type code = 01, organization code = 10, and User Text 07 (TXT_07).  It will return events where the value is "pop"
      return apiClient.Endpoints.Events.Search(orgCode, "C|01|10|UserText07 eq 'pop'");      
    }

    /// <summary>
    /// A basic add example
    /// </summary>  
    public EventsModel Add(string orgCode, string eventName, string accountCode)
    {
      var myEvent = new EventsModel
      {
        Organization = orgCode,
        Description = eventName,
        Account = accountCode,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
      };

      return apiClient.Endpoints.Events.Add( myEvent);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public EventsModel Edit(string orgCode, int eventID, string newEventName)
    {
      var myEvent = apiClient.Endpoints.Events.Get( orgCode, eventID);

      myEvent.Description = newEventName;

      return apiClient.Endpoints.Events.Update( myEvent);
    }

    public EventsModel CancelEvent(string orgCode, int eventID)
    {
      const string myCancelReasonCode = "sd";

      var myEvent = apiClient.Endpoints.Events.Get( orgCode, eventID);

      myEvent.Status = "80"; //'Setting to a status greater than or equal to 80 and less than or equal to 89 is sign for cancelling (80 <= x <= 89)
      myEvent.Reason = myCancelReasonCode + "|EC";  //You need to supply a Reason code when cancelling an event.  It's represented by the a pipe delimited code, namely (Reason code | Cancel Reason Application code).  The Cancel Reason Application code is always EC for events.You can find the Reason Code in the Ungerboeck window "Event Cancellation Reasons" from the main menu.The code is located under the 'code' column in the grid.You can also find it in the database under MM210_REASON_CODE
      
      myEvent.FunctionStatus = "82"; //When cancelling an event, the system needs to know what to status code to set on the event's functions.  Set it to a cancelled status of functions.
      //Note that FunctionStatus is never filled in the EventModel on a GET.  It's just a place to set Function Status when cancelling an event.
      
      return apiClient.Endpoints.Events.Update( myEvent);
    }

    public EventsModel AddWithUserFields(string orgCode, string eventName, string accountCode, string issueType, string newTxt12Value)
    {
      var myEvent = new EventsModel
      {
        Organization = orgCode,
        Description = eventName,
        Account = accountCode,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
        EventUserFieldSets = new List<UserFields>(),
      };

      //Here's how to add a user field set with values to a new event
      UserFields myUserField = new UserFields
      {
        //Note that class is always EventSales (C) and is automatically set in Ungerboeck.
        Type = issueType, //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
        UserText12 = newTxt12Value //Set the value in the user field property
      };
      myEvent.EventUserFieldSets.Add(myUserField); //Then add it back into the EventModel object.  You can add multiple user field sets to the same event object before saving.

      return apiClient.Endpoints.Events.Add( myEvent);
    }

    public EventsModel EditWithUserFields(string orgCode, int eventID, string issueType, string newText02Value, DateTime newDate02Value)
    {
      var myEvent = apiClient.Endpoints.Events.Get( orgCode, eventID);

      //Here's how to edit a user field set with values on an existing event
      var myEventUDFSet = (from o in myEvent.EventUserFieldSets where o.Type == issueType select o).FirstOrDefault();
      myEventUDFSet.UserText02 = newText02Value; //Set the value in the user field property
      myEventUDFSet.UserDateTime02 = newDate02Value; //Set the value in the user field property

      return apiClient.Endpoints.Events.Update( myEvent);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public EventsModel EditAdvanced(string orgCode, int eventID)
    {
        const string myAccount = "RAYNOR";
        const string myParentAccount = "COMBINE";
        const string myContactAccount = "LSTRIDER";
        const int otherEventID = 11111;

        var myEvent = apiClient.Endpoints.Events.Get( orgCode, eventID);

        myEvent.Description = "Modified Description";
        myEvent.SecondCoordinator = myAccount;
        myEvent.ThirdCoordinator = myAccount;
        myEvent.FourthCoordinator = myAccount;
        myEvent.Abbreviation = "MD";
        myEvent.Account = "COMBINE"; //Just like in Ungerboeck, you may change the account even after an event is created.                                                                                                            
        myEvent.ActualAttendance = 5;
        myEvent.ActualCost = 5;
        myEvent.ActualRevenue = 5;
        myEvent.AlternateEvent = otherEventID;
        myEvent.AnchorVenue = "HALL-A"; //Code value for anchor venue                                                                                                                                                       
        myEvent.Attendance = 5;
        myEvent.BillTo = myParentAccount; //Account code of bill to account                                                                                                                                                 
        myEvent.BillToContact = myContactAccount;  //Account code of bill-to contact                                                                                                                                        
        myEvent.BoxOffice = "Y"; //Y or N                                                                                                                                                                                   
        myEvent.Category = "CO"; //Category code for event categories                                                                                                                                                       
        myEvent.Class = "EDU"; //Class code for event classes                                                                                                                                                               
        myEvent.Contact = myContactAccount;
        myEvent.ContractRequired = "Y";
        myEvent.Coordinator = myContactAccount;
        myEvent.Decision = DateTime.Now;
        myEvent.Description1 = "Event Description 1";
        myEvent.Description2 = "Event Description 2";
        myEvent.Description3 = "Event Description 3";
        myEvent.Description4 = "Event Description 4";
        myEvent.Description5 = "Event Description 5";
        myEvent.EarlyDeadline = DateTime.Now;
        myEvent.EconomicImpact = 5;
        myEvent.ForecastAttendance = 5;
        myEvent.ForecastCost = 5;
        myEvent.ForecastRevenue = 5;
        myEvent.FunctionUserFieldsType = "BU|C"; //Code of Function User fields. It consists of [Issue Type]|[Issue Class].  This is populated from [CR158_ISSUE_TYPE]|[CR158_ISSUE_CLASS].                                 
        myEvent.GLDistribution = "test";
        myEvent.GLSubAccount = myContactAccount;
        myEvent.Indicator = "JB";
        myEvent.Insurance = "Y";
        myEvent.InventoryChain = "CHAINB";
        myEvent.LegalName = "Legal Name";
        myEvent.LegalName1 = "Legal Name 1";
        myEvent.LegalName2 = "Legal Name 2";
        myEvent.LegalName3 = "Legal Name 3";
        myEvent.LegalName4 = "Legal Name 4";
        myEvent.LegalName5 = "Legal Name 5";
        myEvent.MajorGroup = "PRG";
        myEvent.MinorGroup = ".NET";
        myEvent.Note1 = "Test";
        myEvent.Note2 = "Test";
        myEvent.OnSiteOffice = "HALL-A";
        myEvent.OnSitePhone = "555-555-5555";
        myEvent.OrderUserFieldsType = "CK|C"; //This is the code of Order User fields.  It consists of [Issue Type]|[Issue Class].  This is populated from [CR158_ISSUE_TYPE]|[CR158_ISSUE_CLASS].                          
        myEvent.OrderedCost = 5;
        myEvent.OrderedRevenue = 5;
        myEvent.OtherActual = 5;
        myEvent.OtherForecast = 5;
        myEvent.OtherOrdered = 5;
        myEvent.OtherRevised = 5;
        myEvent.ParentEvent = otherEventID;
        myEvent.PaymentPlan = "50";
        myEvent.PreviousEvent = otherEventID;
        myEvent.PriceList = "2001-STD";
        myEvent.Public = "Y";
        myEvent.Rank = "T";
        myEvent.Release = DateTime.Now;
        myEvent.Requester = myParentAccount;
        myEvent.RequesterContact = myContactAccount;
        myEvent.RevisedAttendance = 5;
        myEvent.RevisedCost = 5;
        myEvent.RevisedRevenue = 5;
        myEvent.Salesperson = myAccount;
        myEvent.Search = "APISRCH";
        myEvent.Sensitivity = "1";
        myEvent.StandardDeadline = DateTime.Now;
        myEvent.Status = "30";  //This is the code for statuses.  Filling this in may affect other fields based on the value.  Greater than 29 is firm, greater than 79 is considered cancelled.                            
        myEvent.TaxScheme = "DEFAULT";
        myEvent.Type = "EDU";
        myEvent.WebAddress = "www.ungerboeck.com";

        //Various date values                                                                                                                                                                                              
        myEvent.StartDate = DateTime.Now.Date;
        myEvent.StartTime = DateTime.Now;
        myEvent.InDate = DateTime.Now.Date;
        myEvent.InTime = DateTime.Now;
        myEvent.OutDate = DateTime.Now.Date.AddDays(1);
        myEvent.OutTime = DateTime.Now;
        myEvent.EndDate = DateTime.Now.Date.AddDays(1);
        myEvent.EndTime = DateTime.Now;

         return apiClient.Endpoints.Events.Update( myEvent);
        }

    /// <summary>
    /// A basic example of adding an event from a profile.
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="profileId"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    public EventsModel AddFromProfileBasic(string orgCode, int profileId, DateTime date)
    {
      var model = new AddFromEventProfileModel()
      {
        OrganizationCode = orgCode, //Required
        ProfileID = profileId, //Event Profile ID to use. Required
        CopyToDate = date // This is the only required option. Everything else can be defaulted from the profile
      };

      return apiClient.Endpoints.Events.AddFromProfile( model);
    }

    /// <summary>
    /// An example of adding an event from a profile with options included.
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="profileId"></param>
    /// <param name="date"></param>
    /// <param name="accountId"></param>
    /// <returns></returns>
    public EventsModel AddFromEventProfileAdvanced(string orgCode, int profileId, DateTime date, string accountId)
    {
      var model = new AddFromEventProfileModel()
      {
        OrganizationCode = orgCode, 
        ProfileID = profileId, //Event Profile ID to use. Required
        CopyToDate = date, //Only the date portion is used.
        Account = accountId,
        Description = "World Conference of Events",
        CopyiEBMSWebRegistrationConfiguration = "N",
        CopyV20WebRegistrationSetup = "N",

        CopyBookings = "Y", //Y or N 
        CopyDocuments = "Y", //Y or N 
        CopyServices = "Y", //Y or N 
        CopyEventNoteClasses = "*ALL", // *ALL copies all notes, no notes will be copied if not used
        CopyEventUDFs = "Y",

        IncludeFunctions = "Y", // Needed if including orders. Y or N 
        CopyFunctionNoteClasses = "SITE,INSTAL,DCLAUS", // A list of note classes to copy. 
        CopyFunctionUDFs = "Y", //Y or N 
        CopyRequirements = "N", //Y or N 
        CopyFunctionDocuments = "Y", //Y or N 

        IncludeOrders = "Y", // Need to include functions to include orders
        CopyOrderCustomers = "1", //All Customers = 1 or Event Customers Only = 2
        NewOrderStatus = "A",
        CopyOrdePhaseFrom = "1", //Ordered (1) or Actual (5)
        CopyOrderPhaseTo = "F", //Ordered (1) or Forecast (F)
        CopyOrderDocuments = "Y", //Y or N 
        CopyOrderUDFs = "N", //Y or N 
        CopyOrderNoteClasses = "*ALL",
        RepriceOrders = "EVENT", //Include to reprice orders. Use Order = ORDER, Use Destination Event = EVENT. 
      };

      var options = new Ungerboeck.Api.Models.Options.Subjects.Events() { BypassBookingConflictCheck = true };

      return apiClient.Endpoints.Events.AddFromProfile(model, options);
    }
  }
}
