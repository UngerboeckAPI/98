using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AlternateAddresses : Base
  {
    public AlternateAddresses(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public AlternateAddressesModel Get(string orgCode, string account, int sequenceNumber, string recordType)
    {
      return apiClient.Endpoints.AlternateAddresses.Get( orgCode, account, sequenceNumber, recordType);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<AlternateAddressesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.AlternateAddresses.Search(orgCode, $"{nameof(AlternateAddressesModel.Account)} eq '{searchValue}'");
    }

  }
}
