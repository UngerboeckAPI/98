using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System;

namespace Examples.Operations
{
  public class Checklists : Base
  {
    public Checklists(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>  
    public ChecklistsModel Get(string orgCode, string code)
    {
      return apiClient.Endpoints.Checklists.Get( orgCode, code);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<ChecklistsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.Checklists.Search(orgCode, $"{nameof(ChecklistsModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// Add new checklist
    /// </summary>
    /// <param name="orgCode">Organization code of checklist</param>
    /// <param name="code">code of checklist</param>
    /// <param name="description">description of checklist</param>
    /// <param name="type">Set this to the type of the checklist.  You can use USISDKConstants.ChecklistTypes to help you.  Example value is Ungerboeck.Api.Models.USISDKConstants.ChecklistTypes.Event</param>
    /// <returns></returns>
    public ChecklistsModel Add(string orgCode, string code, string description, string type)
    {
      var checklistsModel = new ChecklistsModel()
      {
        OrganizationCode = orgCode,
        Code = code,
        Description = description,
        Type = type,
        Retire = "N" //Y or N
      };

      return apiClient.Endpoints.Checklists.Add( checklistsModel);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="code">code to update</param>
    /// <param name="newDescription">deescription to update</param>
    /// <returns></returns>
    public ChecklistsModel Edit(string orgCode, string code, string newDescription)
    {
      ChecklistsModel checklistsModel = apiClient.Endpoints.Checklists.Get( orgCode, code);
      if (checklistsModel != null)
      {
        checklistsModel.Description = newDescription;
      }

      return apiClient.Endpoints.Checklists.Update(checklistsModel);
    }
  }
}
