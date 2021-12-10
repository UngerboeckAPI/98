using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ProductsAndServices : Base
  {
    public ProductsAndServices(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public ProductsAndServicesModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.ProductsAndServices.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ProductsAndServicesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.ProductsAndServices.Search(orgCode, $"{nameof(ProductsAndServicesModel.ProductDescription)} eq '{searchValue}'");
    }
  }
}
