using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class TransactionMethods : Base
  {
    public TransactionMethods(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public TransactionMethodsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.TransactionMethods.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<TransactionMethodsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.TransactionMethods.Search(orgCode, $"{nameof(TransactionMethodsModel.Description)} eq '{searchValue}'");
    }
  }
}
