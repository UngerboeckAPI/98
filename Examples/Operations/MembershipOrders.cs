using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class MembershipOrders : Base
  {
    public MembershipOrders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public MembershipOrdersModel Get(string orgCode, int orderNumber)
    {
      return apiClient.Endpoints.MembershipOrders.Get( orgCode, orderNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<MembershipOrdersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.MembershipOrders.Search(orgCode, $"{nameof(MembershipOrdersModel.Account)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<MembershipOrdersModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Order user fields of Issue Class = M (membership), Issue Type code = OR, organization code = 10, and User Number 01 (AMT_01).  It will return orders where the value is 300000
      return apiClient.Endpoints.MembershipOrders.Search(orgCode, "M|OR|10|UserNumber01 eq 300000");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="account">This should be a single account code</param>
    /// <param name="priceList">The price list code</param>
    /// <param name="billingCycle">This is the user-configurable Billing cycle code on the order, which is pulled from Order Cycle v20 window</param>
    /// <param name="periodCycle">This is the user-configurable Period cycle code on the order, which is pulled from Order Cycle v20 window</param>
    public MembershipOrdersModel Add(string orgCode, string account, string priceList, string billingCycle, string periodCycle)
    {

      var myMembershipOrder = new MembershipOrdersModel
      {
        OrganizationCode = orgCode,
        OrderStatus = "A", //This is the user-configurable status code on the order
        Account = account,
        MembershipStart = System.DateTime.Now,
        MembershipEnd = System.DateTime.Now,
        PriceList = priceList,
        BillToAccount = account,  //This can be a different account code
        BillingDate = System.DateTime.Now,
        BillingCycle = billingCycle,
        PeriodCycle = periodCycle,
      };

      return apiClient.Endpoints.MembershipOrders.Add( myMembershipOrder);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public MembershipOrdersModel Edit(string orgCode, int orderNumber, string orderStatus)
    {
      var myMembershipOrder = apiClient.Endpoints.MembershipOrders.Get( orgCode, orderNumber);

      myMembershipOrder.OrderStatus = orderStatus;

      return apiClient.Endpoints.MembershipOrders.Update( myMembershipOrder);
    }

    public MembershipOrdersModel EditAdvanced(string orgCode, int orderNumber)
    {

      var myMembershipOrder = apiClient.Endpoints.MembershipOrders.Get( orgCode, orderNumber);

      string myAccount = "12345678"; //This represents an account code in Ungerboeck

      myMembershipOrder.BillToContact = myAccount;
      myMembershipOrder.Contact = myAccount;
      myMembershipOrder.RequesterAccount = myAccount;
      myMembershipOrder.RequesterContact = myAccount;
      myMembershipOrder.AccountRep = myAccount;
      myMembershipOrder.OrderDate = System.DateTime.Now;
      myMembershipOrder.Description = "Test Description";
      myMembershipOrder.GLAccount = myAccount;
      myMembershipOrder.Terms = "TT"; //Code for Customer Terms
      myMembershipOrder.PONumber = "Test";
      myMembershipOrder.Printed = "Y";
      myMembershipOrder.Taxable = "Y";

      return apiClient.Endpoints.MembershipOrders.Update( myMembershipOrder);
    }

    /// <summary>
    /// This is an example of how to prepare a membership order for invoicing
    /// </summary>
    /// <param name="orgCode">Organization Code attached to the Membership Order you want to prepare</param>
    /// <param name="orderNumber">The order number of the Membership order you want to prepare</param>
    /// returns>The new Order Number</returns>
    public string PrepareMembershipOrderForInvoicing(string orgCode, int orderNumber)
    {      
      return apiClient.Endpoints.MembershipOrders.PrepareMembershipOrderForInvoicing( orgCode, orderNumber);
    }

    /// <summary>
    /// An example for how to close an order
    /// </summary>
    public MembershipOrdersModel CloseOrder(string orgCode, int orderNumber)
    {
      var myMembershipOrder = apiClient.Endpoints.MembershipOrders.Get( orgCode, orderNumber);

      myMembershipOrder.OrderStatus = "C"; //Ensure this is a status code with a class of Closed on the v20 Order Status Master window
      myMembershipOrder.CloseDate = System.DateTime.Now;

      return apiClient.Endpoints.MembershipOrders.Update( myMembershipOrder);
    }

    /// <summary>
    /// An example for how to open an order
    /// </summary>
    public MembershipOrdersModel OpenOrder(string orgCode, int orderNumber)
    {
      var myMembershipOrder = apiClient.Endpoints.MembershipOrders.Get( orgCode, orderNumber);

      myMembershipOrder.OrderStatus = "A"; //Ensure this is a status code with a class of either Active or Hold on the v20 Order Status Master window
      //Note that clearing the CloseDate is not necessary.

      return apiClient.Endpoints.MembershipOrders.Update( myMembershipOrder);
    }
  }
}
