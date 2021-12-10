using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class InventoryItems : Base
  {
    public InventoryItems(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public InventoryItemsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.InventoryItems.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<InventoryItemsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.InventoryItems.Search(orgCode, $"{nameof(InventoryItemsModel.ItemDescription)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public InventoryItemsModel Add()
    {
      var inventoryItems = new InventoryItemsModel()
      {
      Organization = "10",
      Code = "CONVERGENCE",
      ItemDescription = "Easel",
      ProductGroup = "300",
      LotSerialControl = "A",
      PhysicalCount = "M",
      Taxed = "N",
      Department = "ART",
      Minor = "DAIRY",
      Major = "DAIRY",
      Class = "Consumable",
      PurchasingUM = "Each",
      SellingUM = "Each",
      StockToSell = 1.0005M,
      PurchaseToStock = 3.05M,
      StockingUM = "Each",
    };

      return apiClient.Endpoints.InventoryItems.Add( inventoryItems);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="orgCode">orgCode of object to update</param>
    /// <param name="code">Inventory code of object to Update</param>
    /// <returns></returns>
    public InventoryItemsModel Edit(string orgCode, string code, InventoryItemsModel inventoryItemsNew)
    {
      var inventoryItems = apiClient.Endpoints.InventoryItems.Get( orgCode, code);

      if (inventoryItems != null)
      {
        inventoryItems.Organization = inventoryItemsNew.Organization;
        inventoryItems.Code = inventoryItemsNew.Code;
        inventoryItems.ItemDescription = inventoryItemsNew.ItemDescription;
        inventoryItems.ProductGroup = inventoryItemsNew.ProductGroup;
        inventoryItems.LotSerialControl = inventoryItemsNew.LotSerialControl;
        inventoryItems.PhysicalCount = inventoryItemsNew.PhysicalCount;
        inventoryItems.Taxed = inventoryItemsNew.Taxed;
        inventoryItems.Department = inventoryItemsNew.Department;
        inventoryItems.Minor = inventoryItemsNew.Minor;
        inventoryItems.Class = inventoryItemsNew.Class;
        inventoryItems.PurchasingUM = inventoryItemsNew.PurchasingUM;
        inventoryItems.SellingUM = inventoryItemsNew.SellingUM;
        inventoryItems.StockToSell = inventoryItemsNew.StockToSell;
        inventoryItems.PurchaseToStock = inventoryItemsNew.PurchaseToStock;
        inventoryItems.StockingUM = inventoryItemsNew.StockingUM;
      }

      return apiClient.Endpoints.InventoryItems.Update(inventoryItemsNew);
    }

    public void Delete()
    {
      string orgCode = "10";
      string code = "CONVERGENCE";
      apiClient.Endpoints.InventoryItems.Delete( orgCode, code);  
    }

  }
}
