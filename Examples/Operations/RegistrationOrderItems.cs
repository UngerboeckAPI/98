using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RegistrationOrderItems : Base
  {
    public RegistrationOrderItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public RegistrationOrderItemsModel Get(string orgCode, int orderNumber, int orderLineNumber)
    {
      return apiClient.Endpoints.RegistrationOrderItems.Get( orgCode, orderNumber, orderLineNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<RegistrationOrderItemsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.RegistrationOrderItems.Search(orgCode, $"{nameof(RegistrationOrderItemsModel.OrderNumber)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="function">Specify the function ID this order item is from (ex: the merchandising function)</param>
    /// <param name="resourceType">The resource type of the item you want from the Resource master table (ER370_RES_MASTER)</param>
    /// <param name="resourceCode">The resource code of the item you want from the Resource master table (ER370_RES_MASTER)</param>
    /// <param name="units">The amount of items you want on the order</param>
    /// <param name="unitCharge">The price per unit</param>
    /// <param name="registrant">Specify the registrant account code on the order this will attach to</param>
    /// <param name="itemStatus">The status code for the new item.  The order item status is set to the code found in the Order Item Status Master window of v20</param>
    /// <param name="registrantType">This is the Registrant Type code of the order item.  Find this on the "Registrant Type" field on the Order.</param>
    /// <returns></returns>
    public RegistrationOrderItemsModel Add(string orgCode, int orderNumber, int function, string resourceType, string resourceCode, int units, int unitCharge, string registrant, string itemStatus, string registrantType)
    {
      //Note that OrderLineNumber shouldn't be set for POST operations.  Ungerboeck will assign the order line number automatically

      var myRegistrationOrderItem = new RegistrationOrderItemsModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,        
        Function = function,
        ResourceType = resourceType,
        ResourceCode = resourceCode,
        Units = units,
        UnitCharge = unitCharge,
        Registrant = registrant,
        ItemStatus = itemStatus,
        RegistrantType = registrantType,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now.AddDays(1)
      };

      return apiClient.Endpoints.RegistrationOrderItems.Add( myRegistrationOrderItem);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public RegistrationOrderItemsModel Edit(string orgCode, int orderNumber, int orderLineNumber, string itemStatus)
    {
      var myRegistrationOrderItem = apiClient.Endpoints.RegistrationOrderItems.Get( orgCode, orderNumber, orderLineNumber);

      myRegistrationOrderItem.ItemStatus = itemStatus; //The order item status is set to the code found in the Order Item Status Master window of v20

      return apiClient.Endpoints.RegistrationOrderItems.Update( myRegistrationOrderItem);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int orderNumber, int orderLineNumber)
    {
      apiClient.Endpoints.RegistrationOrderItems.Delete( orgCode, orderNumber, orderLineNumber);
    }

    public RegistrationOrderItemsModel EditAdvanced(string orgCode, int orderNumber, int orderLineNumber)
    {

      var myRegistrationOrderItem = apiClient.Endpoints.RegistrationOrderItems.Get( orgCode, orderNumber, orderLineNumber);

      string strAccountCode = "FAKEACCT"; //Use an account code

      myRegistrationOrderItem.AltDesc = "AltDesc1";
      myRegistrationOrderItem.AltDesc2 = "AltDesc2";
      myRegistrationOrderItem.AltDesc3 = "AltDesc3";
      myRegistrationOrderItem.AltDesc4 = "AltDesc4";
      myRegistrationOrderItem.AltDesc5 = "AltDesc5";
      myRegistrationOrderItem.BaseRate = 5;
      myRegistrationOrderItem.Billable = "Y"; //Y or N
      myRegistrationOrderItem.Description = "New Item Description"; //This will override the default description on a order item
      myRegistrationOrderItem.EndDate = System.DateTime.Now.AddDays(1);
      myRegistrationOrderItem.EstimateTBD = "N";
      myRegistrationOrderItem.Fixed = "N";
      myRegistrationOrderItem.Internal = "N";
      myRegistrationOrderItem.LeadHours = 5;
      myRegistrationOrderItem.Note = "Note Text";
      myRegistrationOrderItem.OrderForm = "AT"; //This should be the code of the Order Form, which comes from the order form window in Ungerboeck.
      myRegistrationOrderItem.OriginalRate = 5;
      myRegistrationOrderItem.PrintSequence = "5";
      myRegistrationOrderItem.Reference = "Reference";  //This is just a text field
      myRegistrationOrderItem.SecondaryPrintSequence = "5";
      myRegistrationOrderItem.SerialNbr = "5";
      myRegistrationOrderItem.ShowEndDate = "Y";
      myRegistrationOrderItem.ShowEndTime = "Y";
      myRegistrationOrderItem.ShowExtendedCharge = "Y";
      myRegistrationOrderItem.ShowRate = "Y";
      myRegistrationOrderItem.ShowStartDate = "Y";
      myRegistrationOrderItem.ShowStartTime = "Y";
      myRegistrationOrderItem.ShowUnits = "Y";
      myRegistrationOrderItem.StartDate = System.DateTime.Now;
      myRegistrationOrderItem.StrikeHours = 5;
      myRegistrationOrderItem.Supplier = strAccountCode;
      myRegistrationOrderItem.UnitCharge = 5; //Use UnitCharge to update the cost of an item
      myRegistrationOrderItem.Units = 5;  //Change the number of units of the item on the order
      myRegistrationOrderItem.UnitsSchemeCode = "TEST1";  //Use the code from the Unit Scheme window
      myRegistrationOrderItem.UserNumber1 = 5;
      myRegistrationOrderItem.UserNumber2 = 5;
      myRegistrationOrderItem.UserNumber3 = 5;
      myRegistrationOrderItem.UserText = "User Text";

      //'Please check the v20 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.
      //.OverrideTimeUnits = "Y"
      //.TimeUnits = 1.000
      //.Daily = "N"
      //.DiscountPercent = 5
      //.MaximumCharge = 5.0
      //.MaximumUnits = 5
      //.MinimumCharge = 5.0
      //.MinimumUnits = 5

      return apiClient.Endpoints.RegistrationOrderItems.Update( myRegistrationOrderItem);
    }
  }
}
