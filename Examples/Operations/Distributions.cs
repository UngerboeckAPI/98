using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Distributions : Base
  {
    public Distributions(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public DistributionsModel Get(string orgCode, string bulletinApplication, int meeting, int bulletin, int distributionEntrySeqNbr)
    {
      return apiClient.Endpoints.Distributions.Get( orgCode, bulletinApplication, meeting, bulletin, distributionEntrySeqNbr);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<DistributionsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Distributions.Search(orgCode, $"{nameof(DistributionsModel.BulletinApplication)} eq '{searchValue}'");
    }
  }
}
