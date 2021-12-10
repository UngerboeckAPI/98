using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Models.Bulk;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Examples.Operations
{
  public class FulfillmentOrderItems : Base
  {
    public FulfillmentOrderItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public FulfillmentOrderItemsModel Get(string orgCode, int orderNumber, int orderLineNumber)
    {
      return apiClient.Endpoints.FulfillmentOrderItems.Get( orgCode, orderNumber, orderLineNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<FulfillmentOrderItemsModel> Search(string orgCode, int searchValue)
    {      
      return apiClient.Endpoints.FulfillmentOrderItems.Search( orgCode, $"{nameof(FulfillmentOrderItemsModel.OrderNumber)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="units">The amount of items you want on the order</param>
    /// <param name="priceListDetailSeqNbr">This should be filled in as the Price List Sequence number (CC716_SEQ) of the item you wish to add.  It should belong to the Order's price list items (Check CC716_PRICE_LIST_DTL).  You can see this value by going to v20->main menu->price lists-> edit price list-> price list item grid -> show column "Sequence"</param>    
    public FulfillmentOrderItemsModel Add(string orgCode, int orderNumber, int units, int priceListDetailSeqNbr)
    {
      var myFulfillmentOrderItem = new FulfillmentOrderItemsModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        Units = units,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now,
        StartTime = System.DateTime.Now,
        EndTime = System.DateTime.Now,
        PriceListDetailSeqNbr = priceListDetailSeqNbr
      };

      return apiClient.Endpoints.FulfillmentOrderItems.Add( myFulfillmentOrderItem);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="itemStatus">The order item status is set to the code found in the Order Item Status Master window of v20</param>
    /// <returns></returns>
    public FulfillmentOrderItemsModel Edit(string orgCode, int orderNumber, int orderLineNumber, string itemStatus)
    {
      var myFulfillmentOrderItem = apiClient.Endpoints.FulfillmentOrderItems.Get( orgCode, orderNumber, orderLineNumber);

      myFulfillmentOrderItem.ItemStatus = itemStatus;

      return apiClient.Endpoints.FulfillmentOrderItems.Update( myFulfillmentOrderItem);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int orderNumber, int orderLineNumber)
    {
      apiClient.Endpoints.FulfillmentOrderItems.Delete( orgCode, orderNumber, orderLineNumber);
    }

    public FulfillmentOrderItemsModel EditAdvanced(string orgCode, int orderNbr, int orderLineNbr)
    {

      var myFulfillmentOrderItem = apiClient.Endpoints.FulfillmentOrderItems.Get( orgCode, orderNbr, orderLineNbr);

      string strAccountCode = "FAKEACCT"; //Use an account code


      myFulfillmentOrderItem.AltDesc = "AltDesc1";
      myFulfillmentOrderItem.AltDesc2 = "AltDesc2";
      myFulfillmentOrderItem.AltDesc3 = "AltDesc3";
      myFulfillmentOrderItem.AltDesc4 = "AltDesc4";
      myFulfillmentOrderItem.AltDesc5 = "AltDesc5";
      myFulfillmentOrderItem.Billable = "N";
      myFulfillmentOrderItem.Note = "Note Text";
      myFulfillmentOrderItem.EndDate = System.DateTime.Now.AddDays(1);
      myFulfillmentOrderItem.EndTime = System.DateTime.Now;
      myFulfillmentOrderItem.Internal = "Y"; //Y or N
      myFulfillmentOrderItem.EstimateTBD = "N";
      myFulfillmentOrderItem.Fixed = "Y";
      myFulfillmentOrderItem.UserNumber1 = 5;
      myFulfillmentOrderItem.UserNumber2 = 5;
      myFulfillmentOrderItem.UserNumber3 = 5;
      myFulfillmentOrderItem.Supplier = strAccountCode;
      myFulfillmentOrderItem.UserText = "User Text";
      myFulfillmentOrderItem.LeadHours = 5;
      myFulfillmentOrderItem.MaximumUnits = 5;
      myFulfillmentOrderItem.ManagementReport = "FLIGHT";  //This should be the code for the Management Report.
      myFulfillmentOrderItem.MinimumUnits = 5;
      myFulfillmentOrderItem.OrderForm = "BK"; //This should be the code of the Order Form, which comes from the order form window in Ungerboeck.
      myFulfillmentOrderItem.OriginalRate = 5;
      myFulfillmentOrderItem.BaseRate = 5;
      myFulfillmentOrderItem.PrintSequence = "5";
      myFulfillmentOrderItem.SecondaryPrintSequence = "5";
      myFulfillmentOrderItem.Reference = "Reference"; //This is just a text field
      myFulfillmentOrderItem.SerialNbr = "5";
      myFulfillmentOrderItem.ShowEndDate = "Y";
      myFulfillmentOrderItem.ShowEndTime = "Y";
      myFulfillmentOrderItem.ShowExtendedCharge = "Y";
      myFulfillmentOrderItem.ShowRate = "Y";
      myFulfillmentOrderItem.ShowStartDate = "Y";
      myFulfillmentOrderItem.ShowStartTime = "Y";
      myFulfillmentOrderItem.ShowUnits = "Y";
      myFulfillmentOrderItem.StartDate = System.DateTime.Now;
      myFulfillmentOrderItem.StartTime = System.DateTime.Now;
      myFulfillmentOrderItem.StrikeHours = 5;
      myFulfillmentOrderItem.UnitCharge = 25; //You should use UnitCharge to change the price when adding an item.  Leave this blank if you want the default price and don't want the price overriden.
      myFulfillmentOrderItem.SurchargePercent = 5;


      //''Please check the v20 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.
      //'.Daily = "N"
      //'.Per = 0
      //'.MaximumCharge = 5.00
      //'.MinimumCharge = 5.00
      //'.ExtendedCharge = ""
      //'.UseSeasonal = "Y"
      //'.ExtendedCost = 250.00
      //'.Multiplier = 5.00

      return apiClient.Endpoints.FulfillmentOrderItems.Update( myFulfillmentOrderItem);
    }

  }
}
