using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class POContracts : Base
  {
    public POContracts(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public POContractsModel Get(string orgCode,int POContractId)
    {
      return apiClient.Endpoints.POContracts.Get( orgCode, POContractId);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<POContractsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.POContracts.Search(orgCode, $"{nameof(POContractsModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <returns>List of POContractsModel</returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<POContractsModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.
      //Table PO255

      //This is searching for user fields of Issue Class = I, Issue Type code = 98, organization code = 10, and User Text 01 (TXT_01).  It will return record where the UserText01 is 00039412
      return apiClient.Endpoints.POContracts.Search(orgCode, "I|98|10|UserText01 eq '00039412'");
    }


  }
}
