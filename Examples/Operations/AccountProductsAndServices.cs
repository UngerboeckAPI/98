using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AccountProductsAndServices : Base
  {
    public AccountProductsAndServices(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>   
    public AccountsProductsAndServicesModel Get(string orgCode, string accountCode, string productServiceCode)
    {
      return apiClient.Endpoints.AccountProductsAndServices.Get( orgCode, accountCode, productServiceCode);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>  
    public SearchResponse<AccountsProductsAndServicesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AccountProductsAndServices.Search(orgCode, $"{nameof(AccountsProductsAndServicesModel.AccountCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary> 
    public AccountsProductsAndServicesModel Add(string orgCode, string accountCode, string productServiceCode)
    {
      var myProductService = new AccountsProductsAndServicesModel
      {
        OrganizationCode = orgCode,
        AccountCode = accountCode,
        ProductServiceCode = productServiceCode
      };

      return apiClient.Endpoints.AccountProductsAndServices.Add( myProductService);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>  
    public void Delete(string orgCode, string accountCode, string productServiceCode)
    {
      apiClient.Endpoints.AccountProductsAndServices.Delete( orgCode, accountCode, productServiceCode);
    }

  }
}
