using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class CustomFieldValidationTables : Base
  {
    public CustomFieldValidationTables(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public CustomFieldValidationTablesModel Get(string orgCode, int ID)
    {
      return apiClient.Endpoints.CustomFieldValidationTables.Get( orgCode, ID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<CustomFieldValidationTablesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.CustomFieldValidationTables.Search(orgCode, $"{nameof(CustomFieldValidationTablesModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public CustomFieldValidationTablesModel Add()
    {
      var customFieldValidationTables = new CustomFieldValidationTablesModel
      {
        Description = "Ford Brands",
        DisplayColumns = 0,
        OrganizationCode = "10",
        Length = 10,
        ControlType = "DD"
      };

      return apiClient.Endpoints.CustomFieldValidationTables.Add(customFieldValidationTables);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="organizationCode">org code of object to Update</param>
    /// <param name="id">id of object to update</param>
    /// <returns></returns>
    public CustomFieldValidationTablesModel Edit(string orgCode, int ID, CustomFieldValidationTablesModel customFieldValidationTablesModelNew)
    {
      var customFieldValidationTables = apiClient.Endpoints.CustomFieldValidationTables.Get(orgCode, ID);

      if (customFieldValidationTables != null)
      {
        customFieldValidationTables.Description = customFieldValidationTablesModelNew.Description;
        customFieldValidationTables.DisplayColumns = customFieldValidationTablesModelNew.DisplayColumns;
        customFieldValidationTables.OrganizationCode = customFieldValidationTablesModelNew.OrganizationCode;
        customFieldValidationTables.Length = customFieldValidationTablesModelNew.Length;
        customFieldValidationTables.ControlType = customFieldValidationTablesModelNew.ControlType;
      }

      return apiClient.Endpoints.CustomFieldValidationTables.Update(customFieldValidationTables);
    }
  }
}
