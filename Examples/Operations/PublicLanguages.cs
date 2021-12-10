using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class PublicLanguages : Base
  {
    public PublicLanguages(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public PublicLanguagesModel Get(int sequence)
    {
      return apiClient.Endpoints.PublicLanguages.Get( sequence);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<PublicLanguagesModel> Search(string searchValue)
    {
      return apiClient.Endpoints.PublicLanguages.Search($"{nameof(PublicLanguagesModel.ApplicationCode)} eq '{searchValue}'");
    }
    
    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="languageCode">Language code</param>
    /// <param name="dictionarySequence">Dictionary to be used for system phrases</param>
    /// <param name="descriptionToUse">Description</param>
    /// <param name="region">Enter the region the site will use for times, dates and formatting</param>
    /// <param name="applicationCode">Application code of the application the configuration was built with: SPA=Speaker Management, REG=Registration</param>
    /// <param name="configurationCode">Application sequence</param>
    /// <param name="defaultLanguage">"Y" or "N". Default language to be used when usersland on the site for the first time, using the base link that has no language information predefined.</param>
    /// <returns></returns>
    public PublicLanguagesModel Add(string orgCode,
                                    string languageCode, 
                                    int dictionarySequence, 
                                    string descriptionToUse, 
                                    string region, 
                                    string applicationCode,
                                    string configurationCode,
                                    string defaultLanguage)
    {
      PublicLanguagesModel language = new PublicLanguagesModel()
      {
        Organization = orgCode,
        ApplicationCode = applicationCode,
        ConfigurationCode = configurationCode,
        Language = languageCode,
        Dictionary = dictionarySequence,
        Region = region,
        DescriptionToUse = descriptionToUse,
        DefaultLanguage = defaultLanguage
      };

      return apiClient.Endpoints.PublicLanguages.Add( language);
    }

    public PublicLanguagesModel Edit(int sequence, string languageCode)
    {
      PublicLanguagesModel language = apiClient.Endpoints.PublicLanguages.Get( sequence);

      language.Language = languageCode;

      return apiClient.Endpoints.PublicLanguages.Update( language);
    }

    /// <summary>
    /// Edit example
    /// </summary> 
    public PublicLanguagesModel EditAdvanced(int sequence)
    {

      PublicLanguagesModel language = apiClient.Endpoints.PublicLanguages.Get( sequence);

      language.DescriptionToUse = "03"; // Alternate description 2
      language.DefaultLanguage = "N";
      language.WebSkin = 1346;
      language.Dictionary = 121; // Dictionary sequence number
      language.Region = "en-AU";

      return apiClient.Endpoints.PublicLanguages.Update( language);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(int sequence)
    {
      apiClient.Endpoints.PublicLanguages.Delete( sequence);  
    }
  }
}
