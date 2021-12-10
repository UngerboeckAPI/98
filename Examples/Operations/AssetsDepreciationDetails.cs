using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class AssetsDepreciationDetails : Base
  {

    public AssetsDepreciationDetails(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public AssetsDepreciationDetailsModel Get(string orgCode, int sequence, string asset, int revision, string book)
    {
      return apiClient.Endpoints.AssetsDepreciationDetails.Get( orgCode, sequence, asset, revision, book);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<AssetsDepreciationDetailsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.AssetsDepreciationDetails.Search(orgCode, $"{nameof(AssetsDepreciationDetailsModel.Sequence)} eq {searchValue}");
    }
  }
}
