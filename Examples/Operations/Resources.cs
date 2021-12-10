using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Resources : Base
  {
    public Resources(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public ResourcesModel Get(string orgCode, int sequence)
    {
      return apiClient.Endpoints.Resources.Get( orgCode, sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ResourcesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Resources.Search(orgCode, $"{nameof(ResourcesModel.Department)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization Code</param>
    /// <param name="code">The resource code</param>
    /// <param name="type">The resource type</param>
    public ResourcesModel Add(string orgCode, string code, string type)
    {
      const string accountCode = "ANA";

      var value = new ResourcesModel
      {
        Organization = orgCode,
        EnteredByCode = accountCode,
        ResourceCode = code,
        ResourceCodeDescription = $"{code} Resource",
        Type = type,
        ResourceTypeDescription = $"{type} Resource",
        Class = "3",
        UM = "EA",
        Per = 1,
        UT = "DAY",
        Attributes = "",
        Minor = "",
        ShowDeliveryMessageBasedonRelativeDates = "N"
      };

      return apiClient.Endpoints.Resources.Add( value);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <returns></returns>
    public ResourcesModel Edit(string orgCode, int sequence, string newDescription)
    {
      var resourcesModel = apiClient.Endpoints.Resources.Get( orgCode, sequence);

      // Changes
      resourcesModel.ResourceCodeDescription = newDescription;

      return apiClient.Endpoints.Resources.Update(resourcesModel);
    }

    public ResourcesModel EditAdvanced(string orgCode, int sequence)
    {
      var resourceModel = apiClient.Endpoints.Resources.Get( orgCode, sequence);

      resourceModel.UM = "EA";
      resourceModel.Per = 1;
      resourceModel.UT = "EA";
      resourceModel.Billable = "Y";
      resourceModel.Internal = "N";
      resourceModel.Status = "A";
      resourceModel.Daily = "Y";

      // Please check the v30 windows for what you can change for your configurations.  Certain fields cannot be changed under conditions.

      return apiClient.Endpoints.Resources.Update( resourceModel);
    }

    /// <summary>
    /// A delete example
    /// </summary>  
    public void Delete(string orgCode, int sequence)
    {
      apiClient.Endpoints.Resources.Delete( orgCode, sequence);
    }
  }
}
