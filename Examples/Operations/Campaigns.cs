using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Campaigns : Base
  {
    public Campaigns(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public CampaignsModel Get(string orgCode, string ID, string designation)
    {
      return apiClient.Endpoints.Campaigns.Get( orgCode, ID, designation);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CampaignsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Campaigns.Search(orgCode, $"{nameof(CampaignsModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// Basic Add example
    /// </summary>
    /// <param name="orgCode">organization code of campaign</param>
    /// <param name="description">description for campaign</param>
    /// <param name="Designation">Designation of campaign. You can use USISDKConstants.AccountDesignations to help you.  Example value is Ungerboeck.Api.Models.USISDKConstants.AccountDesignations.EventSales</param>
    /// <returns></returns>
    public CampaignsModel Add(string orgCode, string description, string designation)
    {
      var campaignsModel = new CampaignsModel()
      {
        Description = description,
        OrganizationCode = orgCode,
        ID = "*AUTO", //*AUTO - To Auto generate the ID field.
        Active = "A", //A-indicates status is active. I-Inactive
        Designation = designation
      };

      return apiClient.Endpoints.Campaigns.Add( campaignsModel);
    }

    /// <summary>
    /// Basic Edit Example
    /// </summary>
    /// <param name="orgCode">organization code of campaign</param>
    /// <param name="ID">ID of campaign to update</param>
    /// <param name="designation">Designation of campaign. You can use USISDKConstants.AccountDesignations to help you.  Example value is Ungerboeck.Api.Models.USISDKConstants.AccountDesignations.Membership</param>
    /// <param name="newDescription">new description to be updated</param>
    /// <returns></returns>
    public CampaignsModel Edit(string orgCode, string ID, string designation, string newDescription)
    {
      CampaignsModel campaignsModel = apiClient.Endpoints.Campaigns.Get( orgCode, ID, designation);
      if (campaignsModel != null)
      {
        campaignsModel.Description = newDescription;
      }

      return apiClient.Endpoints.Campaigns.Update(campaignsModel);
    }
  }
}
