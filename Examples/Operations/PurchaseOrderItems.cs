using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PurchaseOrderItems : Base
  {
    public PurchaseOrderItems(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public PurchaseOrderItemsModel Get(string orgCode, int number, int itemSequence)
    {
      return apiClient.Endpoints.PurchaseOrderItems.Get( orgCode, number, itemSequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<PurchaseOrderItemsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.PurchaseOrderItems.Search(orgCode, $"{nameof(PurchaseOrderItemsModel.Number)} eq {searchValue}");
    }

    public PurchaseOrderItemsModel Add(PurchaseOrderItemsModel purchaseOrderItemModel)
    {
      return apiClient.Endpoints.PurchaseOrderItems.Add( purchaseOrderItemModel);
    }

    public PurchaseOrderItemsModel Edit(string orgCode, int number, int itemSequence, string orderDesc)
    {
      var purchaseOrderItem = apiClient.Endpoints.PurchaseOrderItems.Get( orgCode, number, itemSequence);

      if (purchaseOrderItem != null)
      {
        purchaseOrderItem.Description = orderDesc;
      }

      return apiClient.Endpoints.PurchaseOrderItems.Update(purchaseOrderItem);
    }
  }
}
