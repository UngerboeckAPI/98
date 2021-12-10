using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;

namespace Examples.Operations
{
  public class General : Base
  {
    public General(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// This method demonstrates searching in the API and navigation abilities.
    /// </summary>
    public SearchResponse<EventsModel> Search(string orgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API
            
      List<string> orderBy = new List<string> { "EnteredBy" }; //The results will bring back the list sorted on this property
      const int pageSize = 10; //This will be the amount of items brought back by the search.  Further results will be accessible through paging.


      //Here's a search that gets all events after this date
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { OrderBy = orderBy, PageSize = pageSize };
      var response = apiClient.Endpoints.Events.Search( orgCode, "ChangedOn gt DateTime'2017-09-28'", options);
      Trace.Write(response.Results.Count());

      //eventsList now contains the first 10 entries in this query.  
      //searchMetadata is now populated with paging information            

      //This will get the next 10 entries
      response = apiClient.Endpoints.Events.NavigateSearchList( response.SearchMetadata.Links.Next);
      Trace.Write(response.Results.Count());

      //eventsList now contains entries 11-20 of the query.

      //This will get the last page
      response = apiClient.Endpoints.Events.NavigateSearchList(response.SearchMetadata.Links.Last);
      
      //Notice that searchMetadata.Links.Next is null, since it's the last page.

      return response;
    }

    /// <summary>
    /// This method demonstrates async searching in the API and navigation abilities.
    /// </summary>
    public async Task<SearchResponse<EventsModel>> SearchAsync(string orgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API

      List<string> orderBy = new List<string> { "EnteredBy" }; //The results will bring back the list sorted on this property
      const int pageSize = 10; //This will be the amount of items brought back by the search.  Further results will be accessible through paging.

      //Here's an asynchronous search that gets all events after this date
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { OrderBy = orderBy, PageSize = pageSize };
      var responseTask = apiClient.Endpoints.Events.SearchAsync(orgCode, "ChangedOn gt DateTime'2017-09-28'", options);

      //[Do other stuff here that doesn't need the results]

      var response = await responseTask;

      //eventsList now contains the first 10 entries in this query.  
      //searchMetadata is now populated with paging information            

      //This will do an asynchronous call to get the next 10 entries
      var responseNextTask = apiClient.Endpoints.Events.NavigateSearchListAsync(response.SearchMetadata.Links.Next);

      //This will do an asynchronous call to get the last page
      var responseLastTask = apiClient.Endpoints.Events.NavigateSearchListAsync(response.SearchMetadata.Links.Last);

      //[Do other stuff here that doesn't need the results]

      var responseNext = await responseNextTask;
      var responseLast = await responseLastTask;

      Trace.Write(responseNext.Results.Count());
      Trace.Write(responseLast.Results.Count());

      //ResponseNext now contains entries 11-20 of the query, and responseLast has the final 10 entries.     
      //Notice that responseLast.SearchMetadata.Links.Next is null, since it's the last page.

      return response;
    }

    /// <summary>
    /// This method demonstrates searching in the API using OData.
    /// </summary>
    public SearchResponse<EventsModel> SearchingWithOData(string orgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API

      SearchResponse<EventsModel> eventsList;

      //Here's examples of searches using OData.

      //Get all events with a description equal to a string
      eventsList = apiClient.Endpoints.Events.Search(orgCode, "Description eq 'Convention Name'");
      Trace.Write(eventsList.Results.Count());

      //Get all events with a description containing a substring
      eventsList = apiClient.Endpoints.Events.Search(orgCode, "substringof('Convention', Description)");
      Trace.Write(eventsList.Results.Count());

      //Get all events with a description starting with a substring
      eventsList = apiClient.Endpoints.Events.Search(orgCode, "startswith('Convention', Description)");
      Trace.Write(eventsList.Results.Count());

      //Get all events with a description ending with a substring
      eventsList = apiClient.Endpoints.Events.Search(orgCode, "endswith('Convention', Description)");
      Trace.Write(eventsList.Results.Count());

      //Get all events with a description equal to either of two strings
      eventsList = apiClient.Endpoints.Events.Search(orgCode, "Description eq 'Convention Name' or Description eq 'Conference Name'");
      Trace.Write(eventsList.Results.Count());

      //Get all events changed in 2010
      eventsList = apiClient.Endpoints.Events.Search(orgCode, "ChangedOn gt DateTime'2010-01-01' AND ChangedOn lt DateTime'2011-01-01'");
          
      return eventsList;
    }

    /// <summary>
    /// This method demonstrates searching for empty values or finding all entries that aren't empty
    /// </summary>
    public SearchResponse<AllAccountsModel> SearchingForNull(string orgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API
      
      //Here's examples of searches using OData.

      //Get all accounts with certain first name and has an empty SynchronizedOrganization property
      var accountsList = apiClient.Endpoints.Accounts.Search( orgCode, "startswith('Jones', FirstName) and SynchronizedOrganization eq null");

      return accountsList;
    }

    /// <summary>
    /// This method demonstrates searching for empty values or finding all entries that aren't empty
    /// </summary>
    public SearchResponse<AllAccountsModel> SearchingForNotNull(string orgCode)
    {
      //For more info on searching in the Ungerboeck API, see this article:
      //https://supportcenter.ungerboeck.com/hc/en-us/articles/115010610608-Searching-Using-the-API

      //Get all accounts with certain first name and has a filled SynchronizedOrganization property
      var accountsList = apiClient.Endpoints.Accounts.Search( orgCode, "startswith('Jones', FirstName) and TaxRegistrationStatus ne null");

      return accountsList;
    }

    /// <summary>
    /// This method demonstrates searching in the API and retrieving specific properties using the Select parameter.
    /// </summary>
    public JObject SearchingForSpecificPropertiesWithSelect(string orgCode)
    {      
      JObject eventsList; //Represents a custom object.
      List<string> modelProperties = new List<string> { "Description", "StartDate" };
      //Get all events and only return specific properties in the model
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = modelProperties };
      var events = apiClient.Endpoints.Events.Search(orgCode, "ChangedOn gt DateTime'2017-01-01'", options);
      eventsList = JObject.FromObject(events, new Newtonsoft.Json.JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore }); //Remove the excess properties from the stock model object.  Those properties are never filled in this process.

      return eventsList;
    }

    /// <summary>
    /// This method demonstrates searching in the API and retrieving specific properties using the Select parameter with a sort on the retrieved entries.
    /// </summary>
    public JObject SearchingForSpecificPropertiesWithSelectWithSort(string orgCode)
    {
      JObject bookingsList; //Represents a custom object.
      List<string> modelProperties = new List<string> { "Event" };
      //Get all bookings and only return specific properties in the model
      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = modelProperties };
            
      var bookings = apiClient.Endpoints.Bookings.Search(orgCode, "Space eq '343'", options);
      
      //You can keep the normal Ungerboeck.Api.Models model, or, if a particular structure is needed, you can serialize the model in a custom JArray or JObject like below
      bookingsList = JObject.FromObject(bookings, new Newtonsoft.Json.JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore }); //Remove the excess properties from the stock model object.  Those properties are never filled in this process.

      return bookingsList;
    }


    /// <summary>
    /// This method demonstrates searching and pulling back User Fields using the Select parameter.
    /// </summary>
    public IEnumerable<object> RetrieveUserFieldsDuringSearchWithSelect(string orgCode)
    {
      //This uses Functions as an example, but all non-account user fields work the same.  See the Accounts example code for an account example.

      JObject functionsList; //Represents a custom object.      
      List<string> modelProperties = new List<string> { "BU|UserDateTime02" }; //For non-account user fields, the format is [User field Type]|[User field property name]

      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = modelProperties };
      var functions = apiClient.Endpoints.Functions.Search(orgCode, "EventID eq 13082", options);      
      functionsList = JObject.FromObject(functions, new Newtonsoft.Json.JsonSerializer { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore }); //Remove the excess properties from the stock model object.  Those properties are never filled in this process.

      return functionsList;
    }

    /// <summary>
    /// If you would like to check authentication of another Ungerboeck user, this is an example of this.  
    /// </summary>
    /// <param name="userIDToCheckValue">The Ungerboeck user ID of the user being checked</param>
    /// <param name="passwordToCheckValue">The Ungerboeck password of the user being checked</param>    
    public UngerboeckAuthenticationCheck CheckUngerboeckUserAuthentication(string userIDToCheckValue, string passwordToCheckValue)
    {
      return apiClient.Endpoints.ApiUtility.CheckUngerboeckUserAuthentication(userIDToCheckValue, passwordToCheckValue);
    }


    /// <summary>
    /// This method demonstrates of getting errors using Normal ThrownErrorIntensity
    /// </summary>
    public AllAccountsModel RetrieveWithNormalThrownErrorIntensity()
    {
      //This uses Accounts as an example, but this is universal across all API calls

      //ThrowErrorIntensity.Normal - Sdk will throw exceptions on any error, including 404 not found exceptions.
      apiClient.GlobalOptions.ThrowErrorIntensity = Ungerboeck.Api.Models.Options.ThrowErrorIntensity.Normal;
                 
      var account = apiClient.Endpoints.Accounts.Get("10", "FAKEACCT"); //Assuming FAKEACCT is not a real account code, this will throw an error      

      return account;
    }

    /// <summary>
    /// This method demonstrates getting errors using UnexpectedClientOrServerErrors ThrownErrorIntensity
    /// </summary>
    public AllAccountsModel RetrieveWithUnexpectedClientOrServerErrorsThrownErrorIntensity(ref AllAccountsModel account)
    {
      //This uses Accounts as an example, but this is universal across all API calls

      //ThrowErrorIntensity.UnexpectedClientOrServerErrors - Sdk should throw exceptions on any user error, but not including 404 GET resource errors.  Not found resources will return as null.
      apiClient.GlobalOptions.ThrowErrorIntensity = Ungerboeck.Api.Models.Options.ThrowErrorIntensity.UnexpectedClientOrServerErrors;

      account = apiClient.Endpoints.Accounts.Get("10", "FAKEACCT"); //Assuming FAKEACCT is not a real account code, this will retrieve as null without a thrown error since it's a Not Found (404)

      //But an invalid Add will throw an error
      var invalidAccount = new AllAccountsModel { Organization="10", Class = Ungerboeck.Api.Models.USISDKConstants.AccountClass.Contact }; //Missing LastName.  This will throw an error since it's a Bad Request (400)

      apiClient.Endpoints.Accounts.Add(invalidAccount);

      return account;
    }

    /// <summary>
    /// This method demonstrates getting errors using UnexpectedServerErrorsOnly ThrownErrorIntensity
    /// </summary>
    public Ungerboeck.Api.Models.Errors.ApiErrors RetrieveWithUnexpectedServerErrorsOnlyThrownErrorIntensity()
    {
      //This uses Accounts as an example, but this is universal across all API calls

      //ThrowErrorIntensity.UnexpectedClientOrServerErrors - No errors are thrown.  Errors are only logged to the Api Client object (ApiClient.LastResponseError).
      apiClient.GlobalOptions.ThrowErrorIntensity = Ungerboeck.Api.Models.Options.ThrowErrorIntensity.UnexpectedServerErrorsOnly;

      var account = apiClient.Endpoints.Accounts.Get("10", "FAKEACCT"); //Assuming FAKEACCT is not a real account code, this will retrieve as null without a thrown error since it's a Not Found (404)

      //An invalid Add will not throw an error
      var invalidAccount = new AllAccountsModel { Organization = "10", Class = Ungerboeck.Api.Models.USISDKConstants.AccountClass.Contact }; //Missing LastName.  This will throw an error since it's a Bad Request (400)

      apiClient.Endpoints.Accounts.Add(invalidAccount);

      //Nothing will throw errors aside from internal server errors (500).  You can still see errors programmatically using LastResponseError
      return apiClient.LastResponseError;

    }

    /// <summary>
    /// This method demonstrates getting errors using DoNotThrowErrors ThrownErrorIntensity
    /// </summary>
    public Ungerboeck.Api.Models.Errors.ApiErrors RetrieveWithDoNotThrowErrorsThrownErrorIntensity()
    {
      //This uses Accounts as an example, but this is universal across all API calls

      //ThrowErrorIntensity.UnexpectedClientOrServerErrors - No errors are thrown.  Errors are only logged to the Api Client object (ApiClient.LastResponseError).
      apiClient.GlobalOptions.ThrowErrorIntensity = Ungerboeck.Api.Models.Options.ThrowErrorIntensity.DoNotThrowErrors;

      var account = apiClient.Endpoints.Accounts.Get("10", "FAKEACCT"); //Assuming FAKEACCT is not a real account code, this will retrieve as null without a thrown error since it's a Not Found (404)

      //An invalid Add will not throw an error
      var invalidAccount = new AllAccountsModel { Organization = "10", Class = Ungerboeck.Api.Models.USISDKConstants.AccountClass.Contact }; //Missing LastName.  This will throw an error since it's a Bad Request (400)

      apiClient.Endpoints.Accounts.Add(invalidAccount);

      //Nothing will throw errors.  You can still see errors programmatically using LastResponseError
      return apiClient.LastResponseError;

    }

    /// <summary>
    /// A basic async retrieve example, with timings demonstrating the time difference
    /// </summary>   
    public async Task<Tuple<decimal, decimal>> GetAsyncWithComparison(string orgCode, string accountCode1, string accountCode2, string accountCode3)
    {
      AllAccountsModel accountStarter = apiClient.Endpoints.Accounts.Get(orgCode, accountCode1); //Do an initial retrieve to startup any processes for more accurate results

      var syncTimer = Stopwatch.StartNew();

      AllAccountsModel account1 = apiClient.Endpoints.Accounts.Get(orgCode, accountCode1);
      AllAccountsModel account2 = apiClient.Endpoints.Accounts.Get(orgCode, accountCode2);
      AllAccountsModel account3 = apiClient.Endpoints.Accounts.Get(orgCode, accountCode3);

      syncTimer.Stop();


      var asyncTimer = Stopwatch.StartNew();
      Task<AllAccountsModel> accountTask4 = apiClient.Endpoints.Accounts.GetAsync(orgCode, accountCode1);
      Task<AllAccountsModel> accountTask5 = apiClient.Endpoints.Accounts.GetAsync(orgCode, accountCode2);
      Task<AllAccountsModel> accountTask6 = apiClient.Endpoints.Accounts.GetAsync(orgCode, accountCode3);

      //Put any other tasks here that don't have to wait for the accounts to retrieve

      AllAccountsModel account4 = await accountTask4;
      AllAccountsModel account5 = await accountTask5;
      AllAccountsModel account6 = await accountTask6;

      asyncTimer.Stop();

      decimal syncTime = (decimal)syncTimer.ElapsedMilliseconds / 1000;
      decimal asyncTime = (decimal)asyncTimer.ElapsedMilliseconds / 1000;

      Trace.Write($"Synchronous call time: {syncTime} seconds, asynchonous call time: {asyncTime} seconds");

      return new Tuple<decimal, decimal>(syncTime, asyncTime);
    }

    /// <summary>
    /// A basic async search example, with timings demonstrating the time difference
    /// </summary>   
    public async Task<Tuple<decimal, decimal>> SearchAsyncWithComparison(string orgCode, string lastName1, string lastName2, string lastName3)
    {

      SearchResponse<AllAccountsModel> accountStarter = apiClient.Endpoints.Accounts.Search(orgCode, GetLastNameOData(lastName1)); //Do an initial retrieve to startup any processes for more accurate results

      var syncTimer = Stopwatch.StartNew();

      SearchResponse<AllAccountsModel> account1 = apiClient.Endpoints.Accounts.Search(orgCode, GetLastNameOData(lastName1));
      SearchResponse<AllAccountsModel> account2 = apiClient.Endpoints.Accounts.Search(orgCode, GetLastNameOData(lastName2));
      SearchResponse<AllAccountsModel> account3 = apiClient.Endpoints.Accounts.Search(orgCode, GetLastNameOData(lastName3));

      syncTimer.Stop();


      var asyncTimer = Stopwatch.StartNew();
      Task<SearchResponse<AllAccountsModel>> accountTask4 = apiClient.Endpoints.Accounts.SearchAsync(orgCode, GetLastNameOData(lastName1));
      Task<SearchResponse<AllAccountsModel>> accountTask5 = apiClient.Endpoints.Accounts.SearchAsync(orgCode, GetLastNameOData(lastName2));
      Task<SearchResponse<AllAccountsModel>> accountTask6 = apiClient.Endpoints.Accounts.SearchAsync(orgCode, GetLastNameOData(lastName3));

      //Put any other tasks here that don't have to wait for the accounts to retrieve

      SearchResponse<AllAccountsModel> account4 = await accountTask4;
      SearchResponse<AllAccountsModel> account5 = await accountTask5;
      SearchResponse<AllAccountsModel> account6 = await accountTask6;

      asyncTimer.Stop();

      decimal syncTime = (decimal)syncTimer.ElapsedMilliseconds / 1000;
      decimal asyncTime = (decimal)asyncTimer.ElapsedMilliseconds / 1000;

      Trace.Write($"Synchronous call time: {syncTime} seconds, asynchonous call time: {asyncTime} seconds");

      return new Tuple<decimal, decimal>(syncTime, asyncTime);

      string GetLastNameOData(string lastName)
      {
        return $"LastName eq '{lastName}'";
      }
    }

  }
}
