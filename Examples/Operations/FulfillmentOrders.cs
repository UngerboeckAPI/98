using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Operations
{
  public class FulfillmentOrders : Base
  {
    public FulfillmentOrders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public FulfillmentOrdersModel Get(string orgCode, int orderNumber)
    {
      return apiClient.Endpoints.FulfillmentOrders.Get( orgCode, orderNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<FulfillmentOrdersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.FulfillmentOrders.Search(orgCode, $"{nameof(FulfillmentOrdersModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<FulfillmentOrdersModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Order user fields of Issue Class = C (event sales), Issue Type code = RY, organization code = 10, and User Text 01 (TXT_01).  It will return orders where the value is 6
      return apiClient.Endpoints.FulfillmentOrders.Search(orgCode, "C|RY|10|UserText01 eq '6'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    public FulfillmentOrdersModel Add(string orgCode, string orderStatus, string accountCode, string billToAccount, string priceList, string designation)
    {
      var myFulfillmentOrder = new FulfillmentOrdersModel
      {
        OrganizationCode = orgCode,
        OrderStatus = orderStatus,
        Account = accountCode,
        BillToAccount = billToAccount,
        PriceList = priceList,
        Designation = designation
      };

      return apiClient.Endpoints.FulfillmentOrders.Add( myFulfillmentOrder);
    }
    
    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="orderStatus">This is the user-configurable status code on the order</param>
    /// <param name="accountCode">This should be a single account code</param>
    /// <param name="billToAccount"></param>
    /// <param name="priceList">The price list code. You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST).</param>    
    /// <param name="issueType">This is the Issue Type code of the registration user field set.  Example string value "CK"</param>
    /// <param name="userText05Value">This is just an example of the user fields you can set</param>
    public FulfillmentOrdersModel AddWithUserFields(string orgCode, string orderStatus, string accountCode, string billToAccount, string priceList, string issueType, string designation, string userText01Value)
    {
      var myFulfillmentOrder = new FulfillmentOrdersModel
      {
        OrganizationCode = orgCode,
        OrderStatus = orderStatus,
        Account = accountCode,
        BillToAccount = billToAccount,
        PriceList = priceList,
        Designation = designation
      };

      myFulfillmentOrder.FulfillmentOrderUserFieldSets = new List<UserFields>();
      var myUserField = new UserFields
      {
        Class = "C",
        Type = issueType, //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
        UserText01 = userText01Value //Set the value in the user field property
      };
      myFulfillmentOrder.FulfillmentOrderUserFieldSets.Add(myUserField); //Then add it back into the RegistrationOrdersModel object.  You can add multiple user field sets to the same registration order object before saving.
      
      return apiClient.Endpoints.FulfillmentOrders.Add( myFulfillmentOrder);
    }


    public FulfillmentOrdersModel Edit(string orgCode, int orderNumber, string orderStatus)
    {
      var myFulfillmentOrder = apiClient.Endpoints.FulfillmentOrders.Get( orgCode, orderNumber);

      myFulfillmentOrder.OrderStatus = orderStatus;

      return apiClient.Endpoints.FulfillmentOrders.Update( myFulfillmentOrder);
    }

    /// <summary>
    /// This example is designed to show sample values to use in other editable properties.  For more information, see the model property info in the /api/help sandbox.
    /// </summary>
    public FulfillmentOrdersModel EditAdvanced(string orgCode, int orderNbr)
    {

      var myFulfillmentOrder = apiClient.Endpoints.FulfillmentOrders.Get( orgCode, orderNbr);

      const string myAccount = "EZIO";  //This represents an account code in Ungerboeck
      const string myContact = "00026260"; //This represents an account code for a contact of the above account in Ungerboeck


      myFulfillmentOrder.Account = myAccount; //This is on the example web layout
      myFulfillmentOrder.Contact = myContact;

      myFulfillmentOrder.BillToContact = myContact;

      myFulfillmentOrder.RequesterAccount = myAccount;
      myFulfillmentOrder.RequesterContact = myContact;

      myFulfillmentOrder.ShipToAccount = myAccount;
      myFulfillmentOrder.ShiptoContact = myContact;

      myFulfillmentOrder.OrderDate = System.DateTime.Now;
      myFulfillmentOrder.GLAccount = "TEST";
      myFulfillmentOrder.PONumber = "123456";
      myFulfillmentOrder.ShippingMethod = "1ST"; //This is the Shipping Method code
      myFulfillmentOrder.Department = "AUDIO"; //The department code
      myFulfillmentOrder.PaymentPlan = 22133;  //In v20, this field is represented as a hyperlink that allows you to create a new plan or add to a selected plan.  Here, you are allowed to attach the Fulfillment Order to a valid pre-existing payment plan ID.  This is the ER200_PAY_PLAN_ID column on table ER200_PAYMENT_PLAN.

      //Y or N
      myFulfillmentOrder.Taxable = "Y";
      myFulfillmentOrder.Printed = "Y";

      return apiClient.Endpoints.FulfillmentOrders.Update( myFulfillmentOrder);
    }

  }
}
