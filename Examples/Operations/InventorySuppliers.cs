using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
public	class InventorySuppliers : Base
			{
		public InventorySuppliers(ApiClient apiClient) : base(apiClient)
		{
		}

		/// <summary>
		/// A basic retrieve example
		/// </summary>
		public InventorySuppliersModel Get(string orgCode, string priceList, string supplier)
		{
			return apiClient.Endpoints.InventorySuppliers.Get( orgCode, priceList, supplier);
		}

		/// <summary>
		/// A search example.  Check out the 'Search using the API' knowledge base article for more info.
		/// </summary>   
		public SearchResponse<InventorySuppliersModel> Search(string orgCode, string searchValue)
		{
			return apiClient.Endpoints.InventorySuppliers.Search(orgCode, $"{nameof(InventorySuppliersModel.InventoryItem)} eq '{searchValue}'");
		}

	}
}
