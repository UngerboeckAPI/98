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
  public class ServiceOrderItems : Base
  {
    public ServiceOrderItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ServiceOrderItemsModel Get(string orgCode, int orderNumber, int orderLineNumber)
    {
      return apiClient.Endpoints.ServiceOrderItems.Get( orgCode, orderNumber, orderLineNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ServiceOrderItemsModel> Search(string orgCode, int searchValue)
    {      
      return apiClient.Endpoints.ServiceOrderItems.Search( orgCode, $"{nameof(ServiceOrderItemsModel.OrderNumber)} eq {searchValue}");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="units">The amount of items you want on the order</param>
    /// <param name="priceListDetailSeqNbr">This should be filled in as the Price List Sequence number (CC716_SEQ) of the item you wish to add.  It should belong to the Order's price list items (Check CC716_PRICE_LIST_DTL).  You can see this value by going to v20->main menu->price lists-> edit price list-> price list item grid -> show column "Sequence"</param>    
    public ServiceOrderItemsModel Add(string orgCode, int orderNumber, int units, int priceListDetailSeqNbr)
    {
      var myServiceOrderItem = new ServiceOrderItemsModel
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

      return apiClient.Endpoints.ServiceOrderItems.Add( myServiceOrderItem);
    }

    /// <summary>
    /// A basic add async example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="units">The amount of items you want on the order</param>
    /// <param name="priceListDetailSeqNbr">This should be filled in as the Price List Sequence number (CC716_SEQ) of the item you wish to add.  It should belong to the Order's price list items (Check CC716_PRICE_LIST_DTL).  You can see this value by going to v20->main menu->price lists-> edit price list-> price list item grid -> show column "Sequence"</param>    
    public Task<ServiceOrderItemsModel> AddAsync(string orgCode, int orderNumber, int units, int priceListDetailSeqNbr)
    {
      var myServiceOrderItem = new ServiceOrderItemsModel
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

      return apiClient.Endpoints.ServiceOrderItems.AddAsync(myServiceOrderItem);
    }

    /// <summary>
    /// Adding Price List Item to existing package
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="units">The amount of items you want on the order</param>
    /// <param name="priceListDetailSeqNbr">This should be filled in as the Price List Sequence number (CC716_SEQ) of the item you wish to add.  It should belong to the Order's price list items (Check CC716_PRICE_LIST_DTL).  You can see this value by going to v20->main menu->price lists-> edit price list-> price list item grid -> show column "Sequence"</param>    
    /// <param name="orderLineNumber">This should be filled in as the package header Order Line Nbr</param>
    public ServiceOrderItemsModel AddPackageItemFromPriceList(string orgCode, int orderNumber, int units, int priceListDetailSeqNbr, int orderLineNumber)
    {
      var myPackageItem = new SaveNewItemToExistingPackageModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        Units = units,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now,
        StartTime = System.DateTime.Now,
        EndTime = System.DateTime.Now,
        PriceListDetailSeqNbr = priceListDetailSeqNbr,
        PackageHeaderOrderLineNumber = orderLineNumber,
      };

      return apiClient.Endpoints.ServiceOrderItems.SaveNewItemToExistingPackage( myPackageItem);
    }

    /// <summary>
    /// Async adding Price List Item to existing package
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="orderNumber">The order number of the item's parent order</param>
    /// <param name="units">The amount of items you want on the order</param>
    /// <param name="priceListDetailSeqNbr">This should be filled in as the Price List Sequence number (CC716_SEQ) of the item you wish to add.  It should belong to the Order's price list items (Check CC716_PRICE_LIST_DTL).  You can see this value by going to v20->main menu->price lists-> edit price list-> price list item grid -> show column "Sequence"</param>    
    /// <param name="orderLineNumber">This should be filled in as the package header Order Line Nbr</param>
    public Task<ServiceOrderItemsModel> AddPackageItemFromPriceListAsync(string orgCode, int orderNumber, int units, int priceListDetailSeqNbr, int orderLineNumber)
    {
      var myPackageItem = new SaveNewItemToExistingPackageModel
      {
        OrganizationCode = orgCode,
        OrderNumber = orderNumber,
        Units = units,
        StartDate = System.DateTime.Now,
        EndDate = System.DateTime.Now,
        StartTime = System.DateTime.Now,
        EndTime = System.DateTime.Now,
        PriceListDetailSeqNbr = priceListDetailSeqNbr,
        PackageHeaderOrderLineNumber = orderLineNumber,
      };

      return apiClient.Endpoints.ServiceOrderItems.SaveNewItemToExistingPackageAsync(myPackageItem);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="itemStatus">The order item status is set to the code found in the Order Item Status Master window of v20</param>
    /// <returns></returns>
    public ServiceOrderItemsModel Edit(string orgCode, int orderNumber, int orderLineNumber, string itemStatus)
    {
      var myServiceOrderItem = apiClient.Endpoints.ServiceOrderItems.Get( orgCode, orderNumber, orderLineNumber);

      myServiceOrderItem.ItemStatus = itemStatus;

      return apiClient.Endpoints.ServiceOrderItems.Update( myServiceOrderItem);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int orderNumber, int orderLineNumber)
    {
      apiClient.Endpoints.ServiceOrderItems.Delete( orgCode, orderNumber, orderLineNumber);
    }

    /// <summary>
    /// A delete async example
    /// </summary>  
    public Task DeleteAsync(string orgCode, int orderNumber, int orderLineNumber)
    {
      return apiClient.Endpoints.ServiceOrderItems.DeleteAsync(orgCode, orderNumber, orderLineNumber);
    }

    public ServiceOrderItemsModel EditAdvanced(string orgCode, int orderNbr, int orderLineNbr)
    {

      var myServiceOrderItem = apiClient.Endpoints.ServiceOrderItems.Get( orgCode, orderNbr, orderLineNbr);

      string strAccountCode = "FAKEACCT"; //Use an account code


      myServiceOrderItem.AltDesc = "AltDesc1";
      myServiceOrderItem.AltDesc2 = "AltDesc2";
      myServiceOrderItem.AltDesc3 = "AltDesc3";
      myServiceOrderItem.AltDesc4 = "AltDesc4";
      myServiceOrderItem.AltDesc5 = "AltDesc5";
      myServiceOrderItem.Billable = "N";
      myServiceOrderItem.Note = "Note Text";
      myServiceOrderItem.EndDate = System.DateTime.Now.AddDays(1);
      myServiceOrderItem.EndTime = System.DateTime.Now;
      myServiceOrderItem.Internal = "Y"; //Y or N
      myServiceOrderItem.EstimateTBD = "N";
      myServiceOrderItem.Fixed = "Y";
      myServiceOrderItem.UserNumber1 = 5;
      myServiceOrderItem.UserNumber2 = 5;
      myServiceOrderItem.UserNumber3 = 5;
      myServiceOrderItem.Supplier = strAccountCode;
      myServiceOrderItem.UserText = "User Text";
      myServiceOrderItem.LeadHours = 5;
      myServiceOrderItem.MaximumUnits = 5;
      myServiceOrderItem.ManagementReport = "FLIGHT";  //This should be the code for the Management Report.
      myServiceOrderItem.MinimumUnits = 5;
      myServiceOrderItem.OrderForm = "BK"; //This should be the code of the Order Form, which comes from the order form window in Ungerboeck.
      myServiceOrderItem.OriginalRate = 5;
      myServiceOrderItem.BaseRate = 5;
      myServiceOrderItem.PrintSequence = "5";
      myServiceOrderItem.SecondaryPrintSequence = "5";
      myServiceOrderItem.Reference = "Reference"; //This is just a text field
      myServiceOrderItem.SerialNbr = "5";
      myServiceOrderItem.ShowEndDate = "Y";
      myServiceOrderItem.ShowEndTime = "Y";
      myServiceOrderItem.ShowExtendedCharge = "Y";
      myServiceOrderItem.ShowRate = "Y";
      myServiceOrderItem.ShowStartDate = "Y";
      myServiceOrderItem.ShowStartTime = "Y";
      myServiceOrderItem.ShowUnits = "Y";
      myServiceOrderItem.StartDate = System.DateTime.Now;
      myServiceOrderItem.StartTime = System.DateTime.Now;
      myServiceOrderItem.StrikeHours = 5;
      myServiceOrderItem.UnitCharge = 25; //You should use UnitCharge to change the price when adding an item.  Leave this blank if you want the default price and don't want the price overriden.
      myServiceOrderItem.UnitsSchemeCode = "TEST1";  //Use the code from the Unit Scheme window
      myServiceOrderItem.DiscountPercent = 5;
      myServiceOrderItem.SurchargePercent = 5;


      //''Please check the v20 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.
      //'.Daily = "N"
      //'.Per = 0
      //'.MaximumCharge = 5.00
      //'.MinimumCharge = 5.00
      //'.ExtendedCharge = ""
      //'.UseSeasonal = "Y"
      //'.ExtendedCost = 250.00
      //'.Multiplier = 5.00

      return apiClient.Endpoints.ServiceOrderItems.Update( myServiceOrderItem);
    }

    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="serviceOrderItemsModel1">This contains a standard ServiceOrderItemsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="serviceOrderItemsModel2">This contains a standard ServiceOrderItemsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  If you are submitting a list of unrelated items to save, set this as false and the bulk save process will attempt to continue saving if an item fails to save.  Note that certain errors will always result in the bulk operation halting.</param>
    /// <returns></returns>
    public BulkResponseModel Bulk(ServiceOrderItemsModel serviceOrderItemsModel1, string bulkOperation1, ServiceOrderItemsModel serviceOrderItemsModel2, string bulkOperation2, bool continueOnError)
    {
      BulkRequestModel myBulkRequest = GetServiceOrderItemBulkRequest(serviceOrderItemsModel1, bulkOperation1, serviceOrderItemsModel2, bulkOperation2, continueOnError);

      return apiClient.Endpoints.ServiceOrderItems.Bulk(myBulkRequest);
    }


    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="serviceOrderItemsModel1">This contains a standard ServiceOrderItemsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="serviceOrderItemsModel2">This contains a standard ServiceOrderItemsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  If you are submitting a list of unrelated items to save, set this as false and the bulk save process will attempt to continue saving if an item fails to save.  Note that certain errors will always result in the bulk operation halting.</param>
    /// <returns></returns>
    public Task<BulkResponseModel> BulkAsync(ServiceOrderItemsModel serviceOrderItemsModel1, string bulkOperation1, ServiceOrderItemsModel serviceOrderItemsModel2, string bulkOperation2, bool continueOnError)
    {
      BulkRequestModel myBulkRequest = GetServiceOrderItemBulkRequest(serviceOrderItemsModel1, bulkOperation1, serviceOrderItemsModel2, bulkOperation2, continueOnError);

      return apiClient.Endpoints.ServiceOrderItems.BulkAsync(myBulkRequest);
    }

    private static BulkRequestModel GetServiceOrderItemBulkRequest(ServiceOrderItemsModel serviceOrderItemsModel1, string bulkOperation1, ServiceOrderItemsModel serviceOrderItemsModel2, string bulkOperation2, bool continueOnError)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  Use this for large updates of unrelated items.
                -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = serviceOrderItemsModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = serviceOrderItemsModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);
      return myBulkRequest;
    }
  }
}
