using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PurchaseOrders : Base
  {
    public PurchaseOrders(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrdersModel Get(string orgCode, int number)
    {
      return apiClient.Endpoints.PurchaseOrders.Get( orgCode, number);
    }

    /// <summary>
    /// You can retrieve orders attached to order items by utilizing the Select ability of the odata string.  Be sure to include the [], as this denotes it's a nested model.
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<PurchaseOrdersModel> GetWithOrderItems(string orgCode, int number)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[PurchaseOrderItems]" } };
      return apiClient.Endpoints.PurchaseOrders.Search(orgCode, $"Number eq {number}", options);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PurchaseOrdersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PurchaseOrders.Search(orgCode, $"{nameof(PurchaseOrdersModel.Description)} eq '{searchValue}'");
    }

    public PurchaseOrdersModel Add(string orgCode, string department, string supplier, string description)
    {
      var myPurchaseOrderModel = new PurchaseOrdersModel
      {
        Organization = orgCode,
        Department = department,
        Supplier = supplier,
        Description = description,
        Date = System.DateTime.Now
      };
      return apiClient.Endpoints.PurchaseOrders.Add( myPurchaseOrderModel);
    }


    public PurchaseOrdersModel Edit(string code, int orderNbr, string orderDesc)
    {
      var purchaseOrder = apiClient.Endpoints.PurchaseOrders.Get( code, orderNbr);

      if (purchaseOrder != null)
      {
        purchaseOrder.Description = orderDesc;
      }

      return apiClient.Endpoints.PurchaseOrders.Update(purchaseOrder);
    }

  }
}
