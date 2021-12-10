using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class RegistrationPreferenceTypes : Base
  {
    public RegistrationPreferenceTypes(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public RegistrationPreferenceTypesModel Get(int registrationPreferenceID)
    {
      return apiClient.Endpoints.RegistrationPreferenceTypes.Get( registrationPreferenceID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<RegistrationPreferenceTypesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.RegistrationPreferenceTypes.Search($"{nameof(RegistrationPreferenceTypesModel.ConfigurationCode)} eq '{searchValue}'");
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="preferenceType">Preference Type</param>
    /// <param name="active">True if active</param>
    /// <param name="mandatory">"Y" or "N".</param>
    /// <param name="configurationCode">Application configuration code</param>
    /// <param name="defaultLanguage">"Y" or "N". Default language to be used when usersland on the site for the first time, using the base link that has no language information predefined.</param>
    /// <returns></returns>
    public RegistrationPreferenceTypesModel Add(string orgCode,
                                                int preferenceType,
                                                string active,
                                                string mandatory,
                                                string configurationCode)
    {
      RegistrationPreferenceTypesModel registrationPreferenceType = new RegistrationPreferenceTypesModel()
      {
        OrgCode = orgCode,
        PreferenceType = preferenceType,
        Active = active,
        Mandatory = mandatory,
        ConfigurationCode = configurationCode
      };

      return apiClient.Endpoints.RegistrationPreferenceTypes.Add( registrationPreferenceType);
    }

    public RegistrationPreferenceTypesModel Edit(int registrationPreferenceID, string active, string mandatory)
    {
      RegistrationPreferenceTypesModel registrationPreferenceType = apiClient.Endpoints.RegistrationPreferenceTypes.Get( registrationPreferenceID);

      registrationPreferenceType.Active = active;
      registrationPreferenceType.Mandatory = mandatory;

      return apiClient.Endpoints.RegistrationPreferenceTypes.Update( registrationPreferenceType);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int registrationPreferenceID)
    {
      apiClient.Endpoints.RegistrationPreferenceTypes.Delete( registrationPreferenceID);  
    }
  }
}
