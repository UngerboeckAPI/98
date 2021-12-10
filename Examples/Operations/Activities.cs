using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class Activities : Base
  {
    public Activities(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ActivitiesModel Get(string orgCode, string accountCode, int sequenceNumber)
    {
      return apiClient.Endpoints.Activities.Get( orgCode, accountCode, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>
    public SearchResponse<ActivitiesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Activities.Search(orgCode, $"{nameof(ActivitiesModel.Account)} eq '{searchValue}'");
    }

    public ActivitiesModel AddAccountActivity(string orgCode, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText, //This can contain HTML if desired.
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);  //After saving, you can find the text with the html stripped out in the PlainText property
    }

    /// <summary>
    /// This example shows some other properties you can set while adding an activity
    /// </summary>
    public ActivitiesModel AddActivityAdvanced(string orgCode, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText, //This can contain HTML if desired.
        Account = accountCode,

        EntryDesignation = USISDKConstants.AccountDesignations.EventSales,
        Status = "N", //You can set the activity status, or you can let it default in based on your Ungerboeck configuration
        Type = "PCF", //Add the activity entry type code

        //Recipient = "RAYNOR,FREEMAN" 'Add multiple recipients using a comma-delimited list.
        Recipient = "RAYNOR", //Otherwise, add a single account code like this

        //Here are other various examples of properties you can set
        Contact = "RAYNOR", //Add a contact of the diary account using the account code here
        ActualStartDate = DateTime.Now,
      ActualEndDate = DateTime.Now.AddDays(1),      
      Due = DateTime.Now.AddDays(1),
      DueTime = DateTime.Now.AddHours(-2),              
      Locked = "N", //"Y" or "N" to lock the diary entry
      Priority = USISDKConstants.ActivityPriority.High, //Use this to set the priority to high (defaults to normal otherwise)
      Privileged = "Y", //Y or N, Y is privileged      
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }


    public ActivitiesModel AddEventActivity(string orgCode, int eventID, string newActivityText, string accountCode, string recipient)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Event = eventID,
        Account = accountCode,
        Recipient = recipient
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }
    
    public ActivitiesModel AddNoteActivity(string orgCode, string noteCode, int noteSequenceNbr, string noteType, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        //Attach to a note using the note's identifying values
        OrganizationCode = orgCode,
        Text = newActivityText,        
        NoteCode = noteCode,
        NoteSequenceNbr = noteSequenceNbr,
        NoteType = noteType, //Use the NoteType to specify which note type it is (ex: Ungerboeck.Api.Models.USISDKConstants.NoteType.AccountNote)
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddContractActivity(string orgCode, int contractSequence, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        ContractSequenceNbr = contractSequence,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddMeetingActivity(string orgCode, int meetingSequence, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        SequenceNumber = meetingSequence,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddQuoteActivity(string orgCode, int quoteSequence, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Quote = quoteSequence,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddExhibitorActivity(string orgCode, int exhibitorID, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        ExhibitorID = exhibitorID,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddOrderActivity(string orgCode, int orderNbr, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        OrderNumber = orderNbr,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddFunctionActivity(string orgCode, int functionID, int eventID, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Function = functionID,
        Event = eventID,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddFiscalYearPeriodActivity(string orgCode, string fyp, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        FiscalYearPeriod = fyp,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddBlockActivity(string orgCode, string blockCode, int eventID, string newActivityText, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        BlockCode = blockCode,
        Event = eventID,
        Account = accountCode
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddProjectActivity(string orgCode, string newActivityText)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,

        //For project attachment, set the project ID and the project designation
        ProjectID = "5",
        Account = "RAYNOR",
        ProjectDesignation = USISDKConstants.AccountDesignations.Membership
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddChecklistActivity(string orgCode, string newActivityText)
    {
      //It's possible to add a checklist code.  Do this if adding a checklist through the API.

      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Account = "RAYNOR",
        Checklist = "CL" //The checklist code
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    public ActivitiesModel AddInventoryItemActivity(string orgCode, string newActivityText, string inventoryItemCode, string accountCode)
    {
      var myActivity = new ActivitiesModel
      {
        OrganizationCode = orgCode,
        Text = newActivityText,
        Account = accountCode,
        InventoryItemCode = inventoryItemCode //Add the inventory item code here to attach to an Inventory item
      };

      return apiClient.Endpoints.Activities.Add( myActivity);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    public ActivitiesModel Edit(string orgCode, string accountCode, int sequenceNumber, string newText)
    {
      var myActivity = apiClient.Endpoints.Activities.Get( orgCode, accountCode, sequenceNumber);

      myActivity.Text = newText; //Set the Text property with either plain text or HTML text.  

      return apiClient.Endpoints.Activities.Update( myActivity);
    }

    /// <summary>
    /// A delete example
    /// </summary> 
    public void Delete(string orgCode, string accountCode, int sequenceNumber)
    {
      apiClient.Endpoints.Activities.Delete( orgCode, accountCode, sequenceNumber);
    }

  }
}
