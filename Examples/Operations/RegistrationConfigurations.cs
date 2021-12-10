using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Examples.Operations
{
  public class RegistrationConfigurations : Base
  {
    public RegistrationConfigurations(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary> 
    public RegistrationConfigurationsModel Get(string orgCode, string configurationCode)
    {
      return apiClient.Endpoints.RegistrationConfigurations.Get( orgCode, configurationCode);
    }

    /// <summary>
    /// You can retrieve registration configuration attached to public languages by utilizing the Select ability of the odata string.
    /// Be sure to include the [], as this denotes it's a nested model.
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<RegistrationConfigurationsModel> GetWithPublicLanguages(string orgCode, string configurationCode)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[PublicLanguages]" } };
      return apiClient.Endpoints.RegistrationConfigurations.Search(orgCode, $"ConfigurationCode eq '{configurationCode}'", options);
    }

    /// <summary>
    /// You can retrieve registration configuration attached to public languages by utilizing the Select ability of the odata string.
    /// Be sure to include the [], as this denotes it's a nested model.
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<RegistrationConfigurationsModel> GetWithPublicLanguagesAndPreferenceTypes(string orgCode, string configurationCode)
    {
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = new List<string> { "[PublicLanguages],[RegistrationPreferenceTypes]" } };
      return apiClient.Endpoints.RegistrationConfigurations.Search(orgCode, $"ConfigurationCode eq '{configurationCode}'", options);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary> 
    public SearchResponse<RegistrationConfigurationsModel> Search(string orgCode, int searchValue)
    {
      return apiClient.Endpoints.RegistrationConfigurations.Search(orgCode, $"{nameof(RegistrationConfigurationsModel.Event)} eq {searchValue}");
    }

    /// <summary>
    /// A retrieve by odata query.  We recommend using a specific query when searching, shown in the General class.
    /// </summary> 
    public Ungerboeck.Api.Models.Search.SearchResponse<RegistrationConfigurationsModel> RetrieveByOData(string orgCode, string oData)
    {
      return apiClient.Endpoints.RegistrationConfigurations.Search(orgCode, oData);
    }


    /// <summary>
    /// A basic add example. Not all fields are included in this example as there are almost 60 fields including header and details.
    /// You can add fields as on requirements
    /// </summary>
    /// <param name="orgCode">Organization code</param>
    /// <param name="configDescription">Description of the configuration header</param>
    /// <param name="configType">Type of the configuration</param>
    /// <param name="eventId">The event id of the event this configuration is associated with</param>
    /// <param name="registrationStartDate">Registration start date, should not be grater than end date. Configuration details table field associated with MM472_PARM_CODE = ER015</param>
    /// <param name="registrationEndDate">Registration start date, should not be less than start date. Configuration details table field associated with MM472_PARM_CODE = ER016</param>
    /// <param name="priceList">The price list code.  You can find this on the Price List window in Ungerboeck under the "Code" field (Database column CC715_PRICE_LIST). Configuration details table field associated with MM472_PARM_CODE = ER073</param>
    /// <param name="registrantType">This is the registrant type code, configured by the event's registration setup. Configuration details table field associated with MM472_PARM_CODE = ER043</param>
    /// <param name="orderStatus">Configuration details table field associated with MM472_PARM_CODE = ER006</param>
    /// <param name="allowNewAccountForAdditionalRegistrant">Set 'Y' if user can add new account for registrant.Configuration details table field associated with MM472_PARM_CODE = ER038</param>
    /// <param name="allowAddingNewAccountForGuest">Set 'Y' if user can add new guest account.Configuration details table field associated with MM472_PARM_CODE = ER182</param>
    /// <param name="allowSearchingAccountsContactsForRegistrant">Set 'Y' if you are allowing user registrant search functionality. Configuration details table field associated with MM472_PARM_CODE = ER170</param>
    /// <param name="searchAcross">Registrant searching criteria if allowing accounts/contacts search. Configuration details table field associated with MM472_PARM_CODE = ER194</param>
    /// <param name="enableHousing">Set 'Y' is you want to set Housing related configuration. Configuration details table field associated with MM472_PARM_CODE = ER027</param>
    /// <param name="showPropertyDetails">You can set only when housing is enable. Configuration details table field associated with MM472_PARM_CODE = ER031</param>
    /// <param name="propertyNoteClasses">You can set only when show property details in 'Y'. Configuration details table field associated with MM472_PARM_CODE = ER032</param>
    /// <param name="formTemplate">Form template id. Configuration details table field associated with MM472_PARM_CODE = ER112</param>
    /// <param name="exhibitorFormTemplate">Exhibitor form template id.</param>
    /// <returns></returns>
    public RegistrationConfigurationsModel Add(string orgCode, 
                                               string configDescription,
                                               string configType,
                                               int eventId, 
                                               DateTime registrationStartDate, 
                                               DateTime registrationEndDate, 
                                               string priceList, 
                                               string registrantType,
                                               string orderStatus,
                                               string allowNewAccountForAdditionalRegistrant,
                                               string allowAddingNewAccountForGuest,
                                               string allowSearchingAccountsContactsForRegistrant,
                                               string searchAcross,
                                               string enableHousing,
                                               string showPropertyDetails,
                                               string propertyNoteClasses,
                                               int formTemplate,
                                               string exhibitorFormTemplate)
    {     

      RegistrationConfigurationsModel regConfig = new RegistrationConfigurationsModel()
      {
        OrganizationCode = orgCode,
        ConfigurationType = configType,
        Description = configDescription,
        Event = eventId,
        RegistrationStarts = registrationStartDate,
        RegistrationEnds = registrationEndDate,
        PriceList = priceList,
        RegistrantType = registrantType,
        OrderStatus = orderStatus,
        AllowNewAccountForAdditionalRegistrant = allowNewAccountForAdditionalRegistrant,
        AllowAddingNewAccountForGuest = allowAddingNewAccountForGuest,
        AllowSearchingAccountsContactsForRegistrant = allowSearchingAccountsContactsForRegistrant,
        SearchAcross = searchAcross,
        EnableHousing = enableHousing,
        ShowPropertyDetails = showPropertyDetails,
        PropertyNoteClasses = propertyNoteClasses,
        FormTemplate = formTemplate,
        ExhibitorFormTemplate = exhibitorFormTemplate
      };

      return apiClient.Endpoints.RegistrationConfigurations.Add( regConfig);
    }

    /// <summary>
    /// A basic edit example
    /// </summary> 
    public RegistrationConfigurationsModel Edit(string orgCode, string configurationCode, string newDescription)
    {
      RegistrationConfigurationsModel regConfig = apiClient.Endpoints.RegistrationConfigurations.Get( orgCode, configurationCode);
      regConfig.Description = newDescription;

      return apiClient.Endpoints.RegistrationConfigurations.Update( regConfig);
    }

    public RegistrationConfigurationsModel EditAdvanced(string orgCode, string configurationCode)
    {
      RegistrationConfigurationsModel regConfig = apiClient.Endpoints.RegistrationConfigurations.Get( orgCode, configurationCode);

      regConfig.Description = "Conference Registration - EU";
      regConfig.RegistrationStarts = new DateTime(2020, 2, 15, 8, 55, 0); // must passed time with date
      regConfig.RegistrationEnds = new DateTime(2021, 2, 15, 20, 5, 0); // must passed time with date
      regConfig.PriceList = "FLD";
      regConfig.RegistrantType = "VIPMEMBERS"; // Members only
      regConfig.OrderStatus = "RF";
      regConfig.MaximumRegistrantsPerOrderAccount = 20;
      regConfig.RequireSignIn = "0";

      regConfig.AllowNewAccountForAdditionalRegistrant = "Y";
      regConfig.AllowSelectingRegistrantFromAListOfRelated = "Y";
      regConfig.AllowSearchingAccountsContactsForRegistrant = "Y";
      regConfig.SearchAcross = "ALLACCTSINREG"; // All active registrant accounts

      regConfig.AllowNewAccountForRegistrant = "N";
      regConfig.AllowSearchingAccountsForRegistrant = "N";
      regConfig.AllowSelectingRegistrantFromAList = "N";
      regConfig.RegistrantResultsFields = "3,6"; // Company, Email
      regConfig.RegistrantSearchFields = "3,6"; // Company, Email

      regConfig.AllowAddingNewAccountForGuest = "Y";
      regConfig.AllowSelectingGuestFromAListOfRelated = "N";
      regConfig.AllowSearchingAccountsContactsForGuest = "Y";
      regConfig.SearchAcrossGuest = "ALLACCTSINREG"; // All active registrant accounts

      regConfig.FormTemplate = 1162;
      regConfig.ExhibitorFormTemplate = "1490";
      regConfig.WebSkin = 1716;
      regConfig.ShowShoppingCart = "Y";

      regConfig.HideEventDescription = "N";
      regConfig.HideEventDates = "N";
      regConfig.HideAnchorVenue = "N";
      regConfig.ShowEventLocation = "Y";
      regConfig.Location = "BBBBBB";

      regConfig.EnableHousing = "Y";
      regConfig.ShowPropertyDetails = "Y";
      regConfig.PropertyNoteClasses = "BENM10,DAN";
      regConfig.HousingStartDate = new DateTime(2020, 2, 15, 8, 55, 0);
      regConfig.HousingEndDate = new DateTime(2021, 2, 15, 20, 5, 0);
      regConfig.SuppressRates = "N";
      regConfig.HousingRequired = "N";
      regConfig.SuppressHousingForGuests = "N";
      regConfig.SetHousingDatesToBlank = "N";
      regConfig.ConfirmationNoteClass = "RCHNC";
      regConfig.ShowQuantitiesForHousingItems = "Y";
      regConfig.ProductsAndServices = "";
      regConfig.AvailableProperties = "";

      return apiClient.Endpoints.RegistrationConfigurations.Update( regConfig);
    }

    /// <summary>
    /// A basic delete example
    /// </summary>    
    public void Delete(string orgCode, string configurationCode)
    {
      apiClient.Endpoints.RegistrationConfigurations.Delete( orgCode, configurationCode);  
    }

  }
}
