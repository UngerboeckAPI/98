using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class FixedAssetsRegisters : Base
  {
    public FixedAssetsRegisters(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public FixedAssetsRegistersModel Get(string orgCode, string assetCode)
    {
      return apiClient.Endpoints.FixedAssetsRegisters.Get( orgCode, assetCode);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<FixedAssetsRegistersModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.FixedAssetsRegisters.Search(orgCode, $"{nameof(FixedAssetsRegistersModel.Class)} eq '{searchValue}'");
    }


    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<FixedAssetsRegistersModel> SearchForUserFields(string orgCode)
    {
      
      //For non-account user fields, the format is [User field Class]|[User field Type]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for ASSET user fields of Issue Class = X, Issue Type code = XX, organization code = 10, and User Txt 01.  It will return record where the value is QWQW
      return apiClient.Endpoints.FixedAssetsRegisters.Search(orgCode, "X|XX|10|UserText01 eq 'QWQW'");
    }


  }
}
