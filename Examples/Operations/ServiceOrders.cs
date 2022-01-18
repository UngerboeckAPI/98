using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Operations
{
  public class ServiceOrders : Base
  {
    public ServiceOrders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public ServiceOrdersModel Get(string orgCode, int orderNumber)
    {
      return apiClient.Endpoints.ServiceOrders.Get( orgCode, orderNumber);
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public async Task<ServiceOrdersModel> GetAsync(string orgCode, int orderNumber)
    {
      var getTask = apiClient.Endpoints.ServiceOrders.GetAsync(orgCode, orderNumber);

      //Put any other tasks here that don't have to wait for the accounts to retrieve

      return await getTask;
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ServiceOrdersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.ServiceOrders.Search(orgCode, $"{nameof(ServiceOrdersModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// A search async example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public async Task<SearchResponse<ServiceOrdersModel>> SearchAsync(string orgCode, string searchValue)
    {
      var searchTask = apiClient.Endpoints.ServiceOrders.SearchAsync(orgCode, $"{nameof(ServiceOrdersModel.Account)} eq '{searchValue}'");

      //Put any other tasks here that don't have to wait for the api call

      return await searchTask;
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<ServiceOrdersModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Order user fields of Issue Class = C (event sales), Issue Type code = CK, organization code = 10, and User Number 03 (AMT_03).  It will return orders where the value is 3
      return apiClient.Endpoints.ServiceOrders.Search(orgCode, "C|CK|10|UserNumber03 eq 3");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="function">The event ID of the event attached to the order</param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    public ServiceOrdersModel Add(string orgCode, int @event, string orderStatus, string accountCode, int function, string billToAccount, string priceList)
    {
      var myServiceOrder = new ServiceOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        OrderStatus = orderStatus,
        Account = accountCode,
        Function = function,
        BillToAccount = billToAccount,
        PriceList = priceList,
      };

      return apiClient.Endpoints.ServiceOrders.Add( myServiceOrder);
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="function">The event ID of the event attached to the order</param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    public async Task<ServiceOrdersModel> AddAsync(string orgCode, int @event, string orderStatus, string accountCode, int function, string billToAccount, string priceList)
    {
      var myServiceOrder = new ServiceOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        OrderStatus = orderStatus,
        Account = accountCode,
        Function = function,
        BillToAccount = billToAccount,
        PriceList = priceList,
      };

      var task = apiClient.Endpoints.ServiceOrders.AddAsync(myServiceOrder);

      return await task;
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="function">The event ID of the event attached to the order</param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    /// <param name="issueType">This is the Issue Type code of the registration user field set.  Example string value "CK"</param>
    /// <param name="userText05Value">This is just an example of the user fields you can set</param>
    public ServiceOrdersModel AddWithUserFields(string orgCode, int @event, string orderStatus, string accountCode, int function, string billToAccount, string priceList, string issueType, int userNumber03Value)
    {
      var myServiceOrder = new ServiceOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        OrderStatus = orderStatus,
        Account = accountCode,
        Function = function,
        BillToAccount = billToAccount,
        PriceList = priceList
      };

      myServiceOrder.ServiceOrderUserFieldSets = new List<UserFields>();
      var myUserField = new UserFields
      {
        Type = issueType, //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
        UserNumber03 = userNumber03Value //Set the value in the user field property
      };
      myServiceOrder.ServiceOrderUserFieldSets.Add(myUserField); //Then add it back into the RegistrationOrdersModel object.  You can add multiple user field sets to the same registration order object before saving.
      
      return apiClient.Endpoints.ServiceOrders.Add( myServiceOrder);
    }


    public ServiceOrdersModel Edit(string orgCode, int orderNumber, string orderStatus)
    {
      var myServiceOrder = apiClient.Endpoints.ServiceOrders.Get( orgCode, orderNumber);

      myServiceOrder.OrderStatus = orderStatus;

      return apiClient.Endpoints.ServiceOrders.Update( myServiceOrder);
    }


    public async Task<ServiceOrdersModel> EditAsync(string orgCode, int orderNumber, string orderStatus)
    {
      var myServiceOrderTask = apiClient.Endpoints.ServiceOrders.GetAsync(orgCode, orderNumber);

      //Place code here that's not dependent on the retrieved order

      var myServiceOrder = await myServiceOrderTask;

      myServiceOrder.OrderStatus = orderStatus;

      myServiceOrderTask = apiClient.Endpoints.ServiceOrders.UpdateAsync(myServiceOrder);

      //This area can also be used for other independent code

      return await myServiceOrderTask;
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public ServiceOrdersModel EditAdvanced(string orgCode, int orderNbr)
    {

      var myServiceOrder = apiClient.Endpoints.ServiceOrders.Get( orgCode, orderNbr);

      const string myAccount = "EZIO";  //This represents an account code in Ungerboeck
      const string myContact = "00026260"; //This represents an account code for a contact of the above account in Ungerboeck
      const string myInternalUserAccountCode = "00014106"; //This represents a personnel designated account code in Ungerboeck


      myServiceOrder.Account = myAccount; //This is on the example web layout
      myServiceOrder.Contact = myContact;

      myServiceOrder.BillToContact = myContact;

      myServiceOrder.RequesterAccount = myAccount;
      myServiceOrder.RequesterContact = myContact;

      myServiceOrder.ShipToAccount = myAccount;
      myServiceOrder.ShiptoContact = myContact;

      myServiceOrder.Exhibitor = 15910;  //The code of the Exhibitor.  This is matching the "Exhibitor" order field in Ungerboeck.

      myServiceOrder.OrderAccountRep = myInternalUserAccountCode;

      myServiceOrder.Category = 11; //This is the Order Categories sequence.  You can find this on the Order Categories window in Ungerboeck
      myServiceOrder.OrderDate = System.DateTime.Now;
      myServiceOrder.GLAccount = "TEST";
      myServiceOrder.PONumber = "123456";
      myServiceOrder.Promotion = "MSP"; //This correlates with the code of the Promotion (ER098_PROMOTIONS -> ER098_PROMO_CODE)
      myServiceOrder.ShippingMethod = "1ST"; //This is the Shipping Method code
      myServiceOrder.Department = "AUDIO"; //The department code
      myServiceOrder.PaymentPlan = 22133;  //In v20, this field is represented as a hyperlink that allows you to create a new plan or add to a selected plan.  Here, you are allowed to attach the Service Order to a valid pre-existing payment plan ID.  This is the ER200_PAY_PLAN_ID column on table ER200_PAYMENT_PLAN.

      //Y or N
      myServiceOrder.Taxable = "Y";
      myServiceOrder.FixedOrder = "Y";
      myServiceOrder.Printed = "Y";

      return apiClient.Endpoints.ServiceOrders.Update( myServiceOrder);
    }

    /// <summary>
    /// Move order example
    /// </summary>
    /// <param name="orderNumber">Set OrderNumber as an integers of the order number to move</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionId">This is the destination function ID on the destination event. This is required for service orders</param>
    public void MoveOrder(string orgCode, int orderNumber, int newEventID, int functionId)
    {
      var myserviceOrder = new MoveOrderModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionId,
        KeepDateTimes = "N" //If "Y", the original order item start/end date will be preserved.  If "N", the moved order will adapt to the function start/end date.
      };

      apiClient.Endpoints.ServiceOrders.MoveOrder(myserviceOrder);
    }

    /// <summary>
    /// Move order example
    /// </summary>
    /// <param name="orderNumber">Set OrderNumber as an integers of the order number to move</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionId">This is the destination function ID on the destination event. This is required for service orders</param>
    public async Task<HttpResponseMessage> MoveOrderAsync(string orgCode, int orderNumber, int newEventID, int functionId)
    {
      var myserviceOrder = new MoveOrderModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionId,
        KeepDateTimes = "N" //If "Y", the original order item start/end date will be preserved.  If "N", the moved order will adapt to the function start/end date.
      };

      var task = apiClient.Endpoints.ServiceOrders.MoveOrderAsync(myserviceOrder);

      return await task;
    }

    /// <summary>
    /// Move order example
    /// </summary>
    /// <param name="orderNumber">Set OrderNumber as an array of integers</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionId">This is the destination function ID on the destination event. This is required for service orders</param>
    public IEnumerable<MoveOrdersBulkErrorsModel> MoveOrderBulk(string orgCode, int[] orderNumber, int newEventID, int functionId)
    {
      var mymoveBulkOrder = new MoveOrdersBulkModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionId,
        KeepDateTimes = "N" //If "Y", the original order item start/end date will be preserved.  If "N", the moved order will adapt to the function start/end date.
      };

      //For bulk operations, 200 only signifies that the process successfully ran.  Individual items might have had issues saving.  Check the response object for bulk errors.
      //One or more errors with saving the items if an error object was returned.        
      return apiClient.Endpoints.ServiceOrders.MoveOrdersBulk( mymoveBulkOrder);
    }

    /// <summary>
    /// Move order example
    /// </summary>
    /// <param name="orderNumber">Set OrderNumber as an array of integers</param>
    /// <param name="newEventID">This is the destination event ID.  You can find this attached this to the Events window in Ungerboeck</param>
    /// <param name="functionId">This is the destination function ID on the destination event. This is required for service orders</param>
    public async Task<IEnumerable<MoveOrdersBulkErrorsModel>> MoveOrderBulkAsync(string orgCode, int[] orderNumber, int newEventID, int functionId)
    {
      var mymoveBulkOrder = new MoveOrdersBulkModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        DestinationEventID = newEventID,
        Function = functionId,
        KeepDateTimes = "N" //If "Y", the original order item start/end date will be preserved.  If "N", the moved order will adapt to the function start/end date.
      };

      //For bulk operations, 200 only signifies that the process successfully ran.  Individual items might have had issues saving.  Check the response object for bulk errors.
      //One or more errors with saving the items if an error object was returned.        
      var task = apiClient.Endpoints.ServiceOrders.MoveOrdersBulkAsync(mymoveBulkOrder);

      //independent code here

      return await task;

    }

    public void CompleteWorkOrder(string orgCode, int orderNumber)
    {
      apiClient.Endpoints.ServiceOrders.CompleteWorkOrders( orgCode, orderNumber);
    }

    public async Task<HttpResponseMessage> CompleteWorkOrderAsync(string orgCode, int orderNumber)
    {
      var task = apiClient.Endpoints.ServiceOrders.CompleteWorkOrdersAsync(orgCode, orderNumber);
      
      //independent code here

      return await task;
    }

    #region "Booth Orders"

    /// <summary>
    /// This method will retrieve the booth order for the specified exhibitor, if one exists
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="exhibitor">This is the exhibitorID of the exhibitor attached to the order</param>
    public ServiceOrdersModel GetExhibitorBoothOrder(string orgCode, int @event, int exhibitor)
    {
      return apiClient.Endpoints.ServiceOrders.Search(orgCode, $"Event eq {@event} and Exhibitor eq {exhibitor} and BoothOrder eq 'Y'").Results.FirstOrDefault();
    }

    /// <summary>
    /// Adds a booth order to the specified exhibitor. Optionally takes a paramater for booth to assign the exhibitor at the same time.
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="exhibitor">The exhibitorID to add this order to</param>
    /// <param name="function">The event ID of the event attached to the order. Must be of type </param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    /// <param name="booth">This is a comma seperated list of booths to assign to this order</param>
    public ServiceOrdersModel AddBoothOrderToExhibitor(string orgCode, int @event, string orderStatus, string accountCode, int exhibitor, int function, string billToAccount, string priceList, string booth = "")
    {
      var exhibitorBoothOrder = new ServiceOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        OrderStatus = orderStatus,
        Account = accountCode,
        Function = function,
        BillToAccount = billToAccount,
        PriceList = priceList,
        Exhibitor = exhibitor,
        BoothOrder = "Y",
        BoothNumber = booth
      };

      return apiClient.Endpoints.ServiceOrders.Add( exhibitorBoothOrder);
    }

    /// <summary>
    /// This method is used to place an exhibitor in a booth. It will attempt to retrieve the exhibitors booth order first. If that exists, than it will add the booth to the 
    /// existing order and return the order. If it does not find a booth order, it will return null.
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="exhibitor">The exhibitorID to add this order to</param>
    /// <param name="booth">This is a comma seperated list of booths to assign to this order</param>
    public ServiceOrdersModel PlaceExhibitorInBooth(string orgCode, int @event, int exhibitor, string booth)
    {
      ServiceOrdersModel exhibitorBoothOrder;

      //Retrieve the existing booth order, an exhibitor will only have 1
      exhibitorBoothOrder = GetExhibitorBoothOrder(orgCode, @event, exhibitor);

      if(exhibitorBoothOrder != null)
      {
        // A booth order can have multiple booths, this example just appends the new booth to the existing list if needed 
        if(exhibitorBoothOrder.BoothNumber != null && exhibitorBoothOrder.BoothNumber.Length > 0)
        {
          exhibitorBoothOrder.BoothNumber = exhibitorBoothOrder.BoothNumber + "," + booth;
        }
        else
        {
          exhibitorBoothOrder.BoothNumber = booth;
        }

        exhibitorBoothOrder = apiClient.Endpoints.ServiceOrders.Update( exhibitorBoothOrder);
      }
      else
      {
        // Here we could create a new booth order, defaulting in values if desired. This example will simply fail to assign the exhibitor if no booth order exists
        // exhibitorBoothOrder = apiClient.Endpoints.ServiceOrders.Add( orgCode, Event, orderStatus, accountCode, exhibitor, function, billToAccount, priceList, booth);
      }

      return exhibitorBoothOrder;
    }

    /// <summary>
    /// This method is used to create an order, exhibitor, and assign a booth at the same time. This a process used for venues and is similar to the process ESC does. It does not rely on the exhibitor 
    /// record explicitly. It will create an Exhibitor record if one is not provided, as well as create a booth record if it does not match an existing one.
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="event">The event ID of the event attached to the order</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="function">The event ID of the event attached to the order. Must be of type </param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    /// <param name="booth">This is a comma seperated list of booths to assign to this order</param>
    /// <param name="exhibitor">The exhibitorID to add this order to. This is optional and will be used if specified, otherwise we will find an existing exhibitor on the event if they exist,
    ///   or add a new one otherwise</param>
    public ServiceOrdersModel AddOrderWithBooth(string orgCode, int @event, string orderStatus, string accountCode, int function, string billToAccount, string priceList, string booth, int exhibitor = 0)
    {
      var myServiceOrder = new ServiceOrdersModel
      {
        OrganizationCode = orgCode,
        Event = @event,
        OrderStatus = orderStatus,
        Account = accountCode,
        Function = function,
        BillToAccount = billToAccount,
        PriceList = priceList,
        BoothNumber = booth,
        Exhibitor = exhibitor,
      };

      if (!string.IsNullOrEmpty(booth))
      {
        // Adding a booth will flag the order as a booth order automatically, but we will be explicit
        myServiceOrder.BoothOrder = "Y";
      }

      return apiClient.Endpoints.ServiceOrders.Add( myServiceOrder);
    }

    #endregion

  }
}
