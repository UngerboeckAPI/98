using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class FixedAssetBookDetails : Base
  {
    public FixedAssetBookDetails(ApiClient apiClient) : base(apiClient)
    {
    }
    /// <summary>
		/// A basic retrieve example
		/// </summary>
		public FixedAssetBookDetailsModel Get(string orgCode, string asset, string book)
    {
      return apiClient.Endpoints.FixedAssetBookDetails.Get( orgCode, asset, book);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<FixedAssetBookDetailsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.FixedAssetBookDetails.Search(orgCode, $"{nameof(FixedAssetBookDetailsModel.Asset)} eq '{searchValue}'");
    }

  }
}
