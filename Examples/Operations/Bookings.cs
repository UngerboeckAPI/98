using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Bulk;
using System.Collections.Generic;
using System;
using System.Data;

namespace Examples.Operations
{
  public class Bookings : Base
  {
    public Bookings(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public BookingsModel Get(string orgCode, int eventId, int sequenceNumber)
    {
      return apiClient.Endpoints.Bookings.Get( orgCode, eventId, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BookingsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.Bookings.Search(orgCode, $"{nameof(BookingsModel.Event)} eq {searchValue}");
    }


    /// <summary>
    /// Example of how to add a booking
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="event">The ID of the event you want to attach the booking to</param>
    /// <param name="space">This is the user-configurable space code the booking takes place in</param>
    /// <param name="startDate">This should be set to the start date of the booking </param>
    /// <param name="endDate">This should be set to the start time of the booking </param>
    /// <param name="startTime">This should be set to the end date of the booking </param>
    /// <param name="endTime">This should be set to the end time of the booking </param>    
    public BookingsModel Add(string orgCode, int @event, string space, DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime)
    {
      var myBooking = new BookingsModel
      {
        OrganizationCode = orgCode,
        Event = @event, 
        Daily = "Y", //Y or N
        Space = space,
        StartTime = startTime,
        StartDate = startDate,
        EndTime = endTime,
        EndDate = endDate
      };

      var options = new Ungerboeck.Api.Models.Options.Subjects.Bookings() { BypassBookingConflictCheck = true }; //Only turn on the booking conflict check bypass if you don't care about schedule/space conflict errors for bookings

      return apiClient.Endpoints.Bookings.Add( myBooking, options);
    }

    /// <summary>
    /// Example of how to initially set or update the rate on an existing booking
    /// This assumes the event has a price list configured, and that the space in question has a matching price list item on that pricelist for the passed in resource type
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="eventId"></param>
    /// <param name="sequenceNumber"></param>
    /// <param name="resourceType">This is a value from [EV370_RES_MASTER].EV370_NEW_RES_TYPE</param>
    /// <returns></returns>
    public BookingsModel SetRate(string orgCode, int eventId, int sequenceNumber, string resourceType)
    {
      var myBooking = apiClient.Endpoints.Bookings.Get( orgCode, eventId, sequenceNumber);

      //  this sets the value on EV802_NEW_RES_TYPE
      myBooking.UsageType = resourceType;

      return apiClient.Endpoints.Bookings.Update( myBooking);
    }

    /// <summary>
    /// Example of how to initially set or update a booking to use multiple rates
    /// Multiple rates are made possible using organization parameters BK 080 and BK 083
    /// Multiple rates only apply to Daily bookings (where [EV802_SPACE_BKD].EV802_CONTIGUOUS_FLAG = 'N')
    /// This assumes you have properly configured BK080 (set the alphanumeric value to "Y", or checked, on the booking configuration window)
    /// This assumes the event has a price list configured, and that the space in question has a matching price list item on that pricelist for the passed in resource type
    /// This assumes you have a Usage record configured properly to use additional rates, and that the additional rate is also on the pricelist
    /// Lastly, this assumes the total number of booked hours on the booking is greater than the "Maximum base rate hours" configured on the Usage
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="eventId"></param>
    /// <param name="sequenceNumber"></param>
    /// <param name="resourceType">This is a value from [EV370_RES_MASTER].EV370_NEW_RES_TYPE</param>
    /// <param name="usage">This is a value from [EV585_FUNC_TYPES].EV585_FUNC_TYPE</param>
    /// <returns></returns>
    public BookingsModel SetMultiRate(string orgCode, int eventId, int sequenceNumber, string resourceType, string usage)
    {
      var myBooking = apiClient.Endpoints.Bookings.Get( orgCode, eventId, sequenceNumber);

      //  This sets the value on [EV802_SPACE_BKD].EV802_NEW_RES_TYPE
      myBooking.UsageType = resourceType;

      // Setup the usage
      myBooking.Usage = usage;

      return apiClient.Endpoints.Bookings.Update( myBooking);
    }

    /// <summary>
    /// Example of removing a rate from an existing booking
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="eventId"></param>
    /// <param name="sequenceNumber"></param>
    /// <returns></returns>
    public BookingsModel RemoveRate(string orgCode, int eventId, int sequenceNumber)
    {
      var myBooking = apiClient.Endpoints.Bookings.Get( orgCode, eventId, sequenceNumber);

      //  This sets the value on [EV802_SPACE_BKD].EV802_NEW_RES_TYPE
      myBooking.UsageType = string.Empty;

      return apiClient.Endpoints.Bookings.Update( myBooking);
    }

    /// <summary>
    /// Example of removing the additional (multi) rate from a booking by clearing the usage
    /// This assumes the booking has multiple rates assigned currently
    /// See SetMultiRate() method above for more information
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="eventId"></param>
    /// <param name="sequenceNumber"></param>
    /// <returns></returns>
    public BookingsModel RemoveMultiRate(string orgCode, int eventId, int sequenceNumber)
    {
      var myBooking = apiClient.Endpoints.Bookings.Get( orgCode, eventId, sequenceNumber);

      myBooking.Usage = string.Empty;

      return apiClient.Endpoints.Bookings.Update( myBooking);
    }

    /// <summary>
    /// Retrieve all service order items tied to a booking on an event
    /// </summary> 
    public SearchResponse<ServiceOrderItemsModel> GetBookingOrderItems(string orgCode, int eventID, int sequenceNumber)
    {      
      return apiClient.Endpoints.ServiceOrderItems.Search( orgCode, $"OrganizationCode  eq '{orgCode}' and Event eq {eventID} and BookingSequence eq {sequenceNumber}");
    }

    /// <summary>
    /// A basic edit example
    /// </summary>  
    public BookingsModel Edit(string orgCode, int @event, int sequenceNumber, string NewBillable)
    {
      var myBooking = apiClient.Endpoints.Bookings.Get( orgCode, @event, sequenceNumber);

      myBooking.Billable = NewBillable; //Y or N
      //myBooking.Status = "25"; //You can change any non-read only properties in an add/update

      var options = new Ungerboeck.Api.Models.Options.Subjects.Bookings() { BypassBookingConflictCheck = true }; //Only turn on the booking conflict check bypass if you don't care about schedule/space conflict errors for bookings

      return apiClient.Endpoints.Bookings.Update( myBooking, options);
    }

    /// <summary>
    /// Edit with booking conflict checking
    /// </summary>
    /// <param name="booking"></param>
    /// <returns></returns>
    public BookingsModel EditWithConflicts(BookingsModel booking)
    {
      var options = new Ungerboeck.Api.Models.Options.Subjects.Bookings() { BypassBookingConflictCheck = false }; //This is false by default, but just showing you how to turn on conflict checking

      return apiClient.Endpoints.Bookings.Update(booking, options);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public BookingsModel EditAdvanced(string orgCode, int eventID, int sequenceNbr)
    {

      var myBooking = apiClient.Endpoints.Bookings.Get( orgCode, eventID, sequenceNbr);

      myBooking.Description = "modified description";

      myBooking.LeadHours = 1;    //Too long of a lead time may return an error if it crosses another booking or is invalid
      myBooking.RequestedSetup = "dub-real";     //this will automatically accept, even if the setup is not configured on the event
      myBooking.Space = "ALPHA";
      myBooking.UnitofTime = "day";
      myBooking.Units = 5;
      myBooking.Usage = "con";
      myBooking.UserNumber1 = 5;
      myBooking.UserNumber2 = 10;
      myBooking.UserNumber3 = 15;
      myBooking.UserText = "user text";
      myBooking.UsageType = "1182";     //This is used to determine the rate.  This is the resource type that appears in the Rate value description.
      myBooking.UseSeasonalDiscount = "y";
      myBooking.Daily = "y";
      myBooking.CreateFunctions = "y"; //Setting this to Y will automatically create a function for the added booking.
      myBooking.Billable = "n";

      //various date values
      myBooking.StartDate = Convert.ToDateTime("2018-04-11 00:00:00.000");
      myBooking.StartTime = Convert.ToDateTime("2000-01-01 00:00:00.000");
      myBooking.EndDate = Convert.ToDateTime("2018-04-11 00:00:00.000");
      myBooking.EndTime = Convert.ToDateTime("2000-01-01 00:00:00.000");

      var options = new Ungerboeck.Api.Models.Options.Subjects.Bookings() { BypassBookingConflictCheck = true }; //Turn off booking conflict checks if you wish to force bookings without schedule/space conflict errors

      return apiClient.Endpoints.Bookings.Update( myBooking, options);
    }

    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="bookingsModel1">This contains a standard BookingsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="bookingsModel2">This contains a standard BookingsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  If you are submitting a list of unrelated items to save, set this as false and the bulk save process will attempt to continue saving if an item fails to save.  Note that certain errors will always result in the bulk operation halting.</param>
    /// <returns></returns>
    public BulkResponseModel Bulk(BookingsModel bookingsModel1, string bulkOperation1, BookingsModel bookingsModel2, string bulkOperation2, bool continueOnError, bool skipBookingConflicts)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = bookingsModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };
      
      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = bookingsModel2, 
        Action = bulkOperation2, 
        BulkItemIndex = 2 
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      var options = new Ungerboeck.Api.Models.Options.Subjects.Bookings();
      if (skipBookingConflicts)
      {
        //Use this header to skip booking conflicts
        options.BypassBookingConflictCheck = true;
      }


      return apiClient.Endpoints.Bookings.Bulk( myBulkRequest, options);
    }
  }
}
