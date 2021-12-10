using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class ValidationEntries : Base
  {
    public ValidationEntries(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public ValidationEntriesModel Get(string orgCode, int validationTableID, int sequenceNumber)
    {
      return apiClient.Endpoints.ValidationEntries.Get( orgCode, validationTableID, sequenceNumber);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<ValidationEntriesModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.ValidationEntries.Search(orgCode, $"{nameof(ValidationEntriesModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <returns></returns>
    public ValidationEntriesModel Add()
    {
      var validationEntries = new ValidationEntriesModel
      {
        Code = "SZ",
        Description = "Size",
        OrganizationCode = "10",
        ValidationTableID = 17,
        Retire = "N",
        DisplayLine = 1
      };

      return apiClient.Endpoints.ValidationEntries.Add(validationEntries);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="orgCode">org code of object to Update</param>
    /// <param name="validationTableID">validation table id of object to update</param>
    /// <param name="sequenceNumber">sequence number of object to update</param>
    /// <returns></returns>
    public ValidationEntriesModel Edit(string orgCode, int validationTableID, int sequenceNumber, ValidationEntriesModel validationEntriesModelNew)
    {
      var validationEntries = apiClient.Endpoints.ValidationEntries.Get(orgCode, validationTableID, sequenceNumber);

      if (validationEntries != null)
      {
        validationEntries.Description = validationEntriesModelNew.Description;
        validationEntries.DisplayLine = validationEntriesModelNew.DisplayLine;
        validationEntries.OrganizationCode = validationEntriesModelNew.OrganizationCode;
        validationEntries.Default = validationEntriesModelNew.Default;
        validationEntries.Retire = validationEntriesModelNew.Retire;
      }

      return apiClient.Endpoints.ValidationEntries.Update(validationEntries);
    }


  }
}
