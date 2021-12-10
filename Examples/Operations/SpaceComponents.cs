using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Ungerboeck.Api.Sdk;

namespace Examples.Operations
{
  
  public class SpaceComponents : Base
  {
    public SpaceComponents(ApiClient apiClient) : base(apiClient)
    {

    }
    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public SpaceComponentsModel Get(string orgCode, string space, string component)
    {
      return apiClient.Endpoints.SpaceComponents.Get( orgCode, space, component);
    }

    /// <summary>
    /// An example of retrieving all components for a single space.
    /// </summary>
    /// <param name="orgCode"></param>
    /// <param name="space"></param>
    /// <returns></returns>
    public Ungerboeck.Api.Models.Search.SearchResponse<SpaceComponentsModel> GetSpaceComponents(string orgCode, string space)
    {
      return apiClient.Endpoints.SpaceComponents.Search(orgCode, $"Space eq '{space}'");
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<SpaceComponentsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.SpaceComponents.Search(orgCode, $"{nameof(SpaceComponentsModel.Space)} eq '{searchValue}'");
    }
  }
}
