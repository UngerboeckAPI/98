using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PreferenceSettings : Base
  {
    public PreferenceSettings(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public PreferenceSettingsModel Get(string orgCode, int ID)
    {
      return apiClient.Endpoints.PreferenceSettings.Get( orgCode, ID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<PreferenceSettingsModel> Search(string orgCode, string searchValue)
    {
      return apiClient.Endpoints.PreferenceSettings.Search(orgCode, $"{nameof(PreferenceSettingsModel.Description)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    public PreferenceSettingsModel Add(string orgCode, string contact, int consentSettingsID)
    {
      var myPreferenceSetting = new PreferenceSettingsModel
      {
        Organization = orgCode,
        Contact = contact,
        PreferenceType = consentSettingsID
      };

      return apiClient.Endpoints.PreferenceSettings.Add( myPreferenceSetting);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>    
    public PreferenceSettingsModel Edit(string orgCode, int ID, string newConsentGiven)
    {
      var myPreferenceSetting = apiClient.Endpoints.PreferenceSettings.Get( orgCode, ID);

      myPreferenceSetting.ConsentGiven = newConsentGiven;

      return apiClient.Endpoints.PreferenceSettings.Update( myPreferenceSetting);
    }

    /// <summary>
    /// A delete example
    /// </summary>    
    public void Delete(string orgCode, int ID)
    {
      apiClient.Endpoints.PreferenceSettings.Delete( orgCode, ID);
    }
  }
}
