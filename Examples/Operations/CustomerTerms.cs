using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CustomerTerms : Base
  {
    public CustomerTerms(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public CustomerTermsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.CustomerTerms.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CustomerTermsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.CustomerTerms.Search(orgCode, $"{nameof(CustomerTermsModel.Description)} eq '{searchValue}'");
    }
  }
}
