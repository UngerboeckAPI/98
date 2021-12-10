using System;

namespace StartHere
{
  class Program
  {
    static void Main(string[] args)
    {
      string ungerboeckURI;
      string apiUserId;
      string secret;
      string key;

      ungerboeckURI = "https://YourUngerboeckSite.ungerboeck.com";      
      apiUserId = "SOMEAPIID"; //This is the API User ID value found on the API User details window.
      secret = "4YYhf4ea-1b2c-4ecf-DS45-44ba766d6b89"; //This is the Secret value found on the API User details window.  It is a GUID.
      key = "648dfF62-2724-4098-82b9-7457b89c7247e"; //This is any one of the Key values found on the API User details window in the Keys section.  It is a GUID.

      if (ungerboeckURI == "https://YourUngerboeckSite.ungerboeck.com") throw new Exception("Please start by modifying the API User info in StartHere/Program.cs");

      var auth = new Ungerboeck.Api.Models.Authorization.Jwt
      {
        APIUserID = apiUserId,
        Secret = secret,
        Key = key,
        UngerboeckURI = ungerboeckURI,
        AutoRefresh = new Ungerboeck.Api.Models.Authorization.AutoRefresh()
      };

      var client = new Ungerboeck.Api.Sdk.ApiClient(auth);

      var examples = new Examples.Operations.Accounts(client); //You can and should call the sdk directly in your app, but this is just showing how to use our example demos      

      var account = examples.Get("10", "ACCTCODE");

      Console.WriteLine($"The account name is {account.Name}");
    }
  }
}
