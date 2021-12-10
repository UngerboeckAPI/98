using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Bulletins : Base
  {
    public Bulletins(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public BulletinsModel Get(string orgCode, string bulletinApplication, int meeting, int bulletin)
    {
      return apiClient.Endpoints.Bulletins.Get( orgCode, bulletinApplication, meeting, bulletin);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<BulletinsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Bulletins.Search(orgCode, $"{nameof(BulletinsModel.BulletinApplication)} eq '{searchValue}'");
    }

  }
}
