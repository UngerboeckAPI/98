using System.Collections.Generic;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System;
using System.Threading.Tasks;
using Ungerboeck.Api.Models.Bulk;

namespace Examples.Operations
{
  public class Accounts : Base
  {
    public Accounts(ApiClient apiClient) : base(apiClient) { }

    /// <summary>
    /// A basic retrieve example
    /// </summary>   
    public AllAccountsModel Get(string orgCode, string accountCode)
    {
      return apiClient.Endpoints.Accounts.Get( orgCode, accountCode);
    }

    /// <summary>
    /// A basic async retrieve example
    /// </summary>   
    public async Task<List<AllAccountsModel>> GetAsync(string orgCode, string accountCode, string accountCode2, string accountCode3)
    {
      Task<AllAccountsModel> accountTask1 = apiClient.Endpoints.Accounts.GetAsync(orgCode, accountCode);
      Task<AllAccountsModel> accountTask2 = apiClient.Endpoints.Accounts.GetAsync(orgCode, accountCode2);
      Task<AllAccountsModel> accountTask3 = apiClient.Endpoints.Accounts.GetAsync(orgCode, accountCode3);
      
      //Put any other tasks here that don't have to wait for the accounts to retrieve

      AllAccountsModel account1 = await accountTask1;
      AllAccountsModel account2 = await accountTask2;
      AllAccountsModel account3 = await accountTask3;

      return new List<AllAccountsModel> { account1, account2, account3 };     
    }    

    /// <summary>
    /// A basic edit example
    /// </summary>  
    public AllAccountsModel Edit(string orgCode, string accountCode, string newCityValue)
    {
      var myAccount = apiClient.Endpoints.Accounts.Get( orgCode, accountCode);

      myAccount.City = newCityValue;

      return apiClient.Endpoints.Accounts.Update( myAccount);
    }

    /// <summary>
    /// A basic async retrieve example
    /// </summary>   
    public async Task<List<AllAccountsModel>> UpdateAsync(AllAccountsModel account1, AllAccountsModel account2)
    {
      Task<AllAccountsModel> accountTask1 = apiClient.Endpoints.Accounts.UpdateAsync(account1);
      Task<AllAccountsModel> accountTask2 = apiClient.Endpoints.Accounts.UpdateAsync(account2);
      
      //Put any other tasks here that don't have to wait for the accounts to update

      account1 = await accountTask1;
      account2 = await accountTask2;
      
      return new List<AllAccountsModel> { account1, account2 };
    }

    public AllAccountsModel AddOrganizationAccount(string orgCode, string newAccountName)
    {
      var myAccount = new AllAccountsModel
      {
        Organization = orgCode,
        Name = newAccountName,
        EventSalesStatus = "A", //Use your configured Status codes to set the account designation status property
        Class = USISDKConstants.AccountClass.Account //The class determines if this is an Account or a Contact

        //myAccount.AccountCode = "ACCTCODE" 'You can set the Account code manually, or leave it empty if your configuration allows for it to be set automatically.
      };

      return apiClient.Endpoints.Accounts.Add( myAccount);
    }

    public AllAccountsModel AddOrganizationAccountWithAccountCode(string orgCode, string newAccountCode, string newAccountName)
    {
      var myAccount = new AllAccountsModel
      {
        Organization = orgCode,
        Name = newAccountName,
        Class = USISDKConstants.AccountClass.Account, //The class determines if this is an Account or a Contact
        AccountCode = newAccountCode //You can set the Account code manually, or leave it empty if your configuration allows for it to be set automatically.
      };

      return apiClient.Endpoints.Accounts.Add(myAccount);
    }

    public AllAccountsModel AddContact(string orgCode, string newAccountFirstName, string newAccountLastName)
    {
      var myAccount = new AllAccountsModel
      {
        Organization = orgCode,
        FirstName = newAccountFirstName,
        LastName = newAccountLastName,
        EventSalesStatus = "A", //Use your configured Status codes to set the account designation status property
        Class = USISDKConstants.AccountClass.Contact //The class determines if this is an Account or a Contact

        //myAccount.AccountCode = "ACCTCODE" 'You can set the Account code manually, or leave it empty if your configuration allows for it to be set automatically.
      };

      return apiClient.Endpoints.Accounts.Add( myAccount);
    }

    /// <summary>
    /// If you wish to have duplicate checking for newly added accounts, this is how you would do it
    /// </summary>  
    public AllAccountsModel AddAccountWithDuplicateChecking(string orgCode, string firstName, string lastName, string email)
    {
      var myAccount = new AllAccountsModel
      {
        Organization = orgCode,
        FirstName = firstName,
        LastName = lastName,
        Email = email,
        Class = USISDKConstants.AccountClass.Contact
      };

      var options = new Ungerboeck.Api.Models.Options.Subjects.Accounts() { BlockDuplicateAccounts = true };
      return apiClient.Endpoints.Accounts.Add( myAccount, options);
    }

    /// <summary>
    /// A basic async retrieve example
    /// </summary>   
    public async Task<AllAccountsModel> AddAsync(string orgCode)
    {
      var myAccount = new AllAccountsModel
      {
        Organization = orgCode,
        Name = "New Account " + DateTime.UtcNow.Ticks.ToString(),        
        Class = USISDKConstants.AccountClass.Account //The class determines if this is an Account or a Contact        
      };

      var accountTask = apiClient.Endpoints.Accounts.AddAsync(myAccount);

      //Put any other tasks here that don't have to wait for the accounts to update

      myAccount = await accountTask;

      return myAccount;
    }

    public SearchResponse<AllAccountsModel> Search(string orgCode, string searchValue)
    {      
      return apiClient.Endpoints.Accounts.Search( orgCode, $"{nameof(AllAccountsModel.LastName)} eq '{searchValue}'");
    }

    /// <summary>
    /// Examples showing how to search using UserFields
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns></returns>
    public IEnumerable<AllAccountsModel> SearchForUserFields(string orgCode)
    {
      SearchResponse<AllAccountsModel> results;
      List<AllAccountsModel> accounts = new List<AllAccountsModel>();

      //For account user fields, the format is [Account User Field Header flag (O ([organization], P [individual], M [membership])]|[User field Class]|[User field Type]|[Organization Code]|[User field property name]"
      //This will only work for active User Fields in your organization.
      //Note for multi-value UDFs, it will convert to a CONTAINS search.

      //This is searching for Individual Account User fields of Issue Class = C (event sales), Issue Type code = 85, organization code = 10, and User Number 01 (AMT_01).  It will return accounts where the value is 12
      results = apiClient.Endpoints.Accounts.Search(orgCode, "P|C|CK|10|UserNumber01 eq 11");
      accounts.AddRange(results.Results);

      //You can mix it in with other filter conditions as well.  This is searching for Postal Code = '77777' with an Organization User Field set
      results = apiClient.Endpoints.Accounts.Search(orgCode, "PostalCode eq '77777' and O|C|04|10|UserText01 eq '01'");
      accounts.AddRange(results.Results);

      //You can search for date user fields.  This is looking for a Registration class User field date of type '3T'
      results = apiClient.Endpoints.Accounts.Search( orgCode, "P|R|3T|10|UserDateTime01 eq datetime'1979-10-27'");
      accounts.AddRange(results.Results);

      ////You can search for membership user fields stored on accounts.
      //accounts.AddRange(apiClient.Endpoints.Accounts.Search(orgCode, "M|M|01|10|UserText04 eq 'CHECK'"));

      //This also works for searching for null values or non-null values      
      results = apiClient.Endpoints.Accounts.Search( orgCode, "P|C|CK|10|UserNumber01 ne null");
      accounts.AddRange(results.Results);

      return accounts;
    }

    /// <summary>
    /// You can return User Fields while searching by requesting the fields on custom objects
    /// </summary>
    /// <param name="orgCode">Organization Code where the search will take place.  User fields are organization-based.</param>
    /// <returns>Accounts with a user field</returns>
    public SearchResponse<AllAccountsModel> ReturningUserFieldsDuringSearch(string orgCode, string searchValue)
    {
      //By using the $Select ability to make a custom return object, you can retrieve user fields on searching, with
      //minimal performance cost.

      //For account user fields, the format is [User field Class]|[User field Type]|[User field property name]
      //This will only work for active User Fields in your organization.

      //This will return Account User fields of Issue Class = C (event sales), Issue Type code = 04, and User Number 01 (AMT_01).  It will return accounts where the Account Rep code is 0002410
      List<string> returnedFields = new List<string> { "C|04|UserText01" , "LastName" };

      Ungerboeck.Api.Models.Options.Search options = new Ungerboeck.Api.Models.Options.Search() { Select = returnedFields };
      return apiClient.Endpoints.Accounts.Search(orgCode, $"AccountRep eq '{searchValue}'", options);
    }

    /// <summary>
    /// This example will show you how to add a new account with custom fields attached.
    /// </summary>
    /// <param name="orgCode">The organization code of the account you wish to add.</param>
    /// <param name="newAccountName">This is the the name of the new account.</param>
    /// <param name="issueClass">This is the code that represents the Issue Class of the custom fields.</param>
    /// <param name="issueType">This is the code that represents the Issue Type of the custom fields</param>
    /// <param name="newTxt01Value">In this example, we are changing Text_01.  Enter a new value here to set this.</param>    
    public AllAccountsModel AddWithUserFields(string orgCode, string newAccountName, string issueClass, string issueType, string newTxt01Value)
    {
      var myAccount = new AllAccountsModel
      {
        Organization = orgCode,
        Name = newAccountName,
        EventSalesStatus = "A", //Use your configured Status codes to set the account designation status property
        Class = USISDKConstants.AccountClass.Account, //The class determines if this is an Account or a Contact
        AccountUserFieldSets = new List<UserFields>()
      };
      
      //Here's how to add a user field set with values to a new account
      var myUserField = new UserFields
      {
        Header = USISDKConstants.UserFieldHeaders.OrganizationAccountUserFields,  //Designate if this is an organization account user field set, an individual account user field set, or a membership user field set
        Class = issueClass, //Set the designation of the user field.  You can use the USISDKConstants.AccountDesignations class to set this.
        Type = issueType, //Use the Opportunity Type code from your user field.  This matches the value stored in Ungerboeck table column CR073_ISSUE_TYPE.
        UserText01 = newTxt01Value //Set the value in the user field property
      };

      myAccount.AccountUserFieldSets.Add(myUserField); //Then add it back into the AllAccountsModel object.  You can add multiple user field sets to the same account object before saving.

      return apiClient.Endpoints.Accounts.Add( myAccount);
    }

    /// <summary>
    /// This shows various ways you can edit Account user fields
    /// </summary>
    public AllAccountsModel EditWithUserFields(string orgCode, string accountCode)
    {
      var myAccount = apiClient.Endpoints.Accounts.Get( orgCode, accountCode);

      //To change user fields, search through the AccountUserFieldSets object on the account model.
      //Find the user field set that matches the designation and the Opportunity Type code.
      //Once it is found, you can change whatever user field you wish.
      if (myAccount.AccountUserFieldSets != null)
      {        
        foreach (UserFields accountUserFields in myAccount.AccountUserFieldSets)
        {
          if (accountUserFields.Header == USISDKConstants.UserFieldHeaders.OrganizationAccountUserFields ||
                accountUserFields.Header == USISDKConstants.UserFieldHeaders.IndividualAccountUserFields)
          {
            //These are User fields that are set under the configuration window for each account designation
            //The classes here are just examples.  All designations can be used.
            if (accountUserFields.Class == USISDKConstants.AccountDesignations.EventSales &&
                accountUserFields.Type == "CK")
            {
              //In this case, this is checking for a User Field set of code "CK" that is configured under the Event Sales Configuration window as either
              //an Individual default user field or an Organization default user field
              accountUserFields.UserNumber02 = 7777;  //Set the value for the user number 02 field (AMT_02)
            }
            else if (accountUserFields.Class == USISDKConstants.AccountDesignations.Registration &&
                  accountUserFields.Type == "04")
            {
              accountUserFields.UserDateTime01 = DateTime.Now.AddDays(1);
              accountUserFields.UserDateTime02 = DateTime.Now.AddHours(3);
              accountUserFields.UserText06 = "2332,2333"; //This is a multi-value user field.  For more than one selected value, insert commas between multiple codes.
            }
            else if (accountUserFields.Class == USISDKConstants.AccountDesignations.PublicRelations &&
                  accountUserFields.Type == "PT")
            {
              accountUserFields.UserText03 = "SDKValue";
            }
          }
        }
      }

      return apiClient.Endpoints.Accounts.Update( myAccount);

    }

    /// <summary>
    /// Example of how to update membership fields on accounts
    /// </summary>
    public AllAccountsModel EditMembershipFields(string orgCode, string accountCode, int newMemberRank)
    {
      var myAccount = apiClient.Endpoints.Accounts.Get( orgCode, accountCode);

      if (myAccount.Membership == "A")
      {
        //Based on active designation flags, you can determine if this account uses the membership fields.
        //The 'A' here represents your code for the Active designation
        myAccount.MemberCategoryDate = DateTime.Now;
        myAccount.MemberRank = newMemberRank;

        //Below are some other fields that can be set via the API
        //myAccount.MemberCategoryDate = Now
        //myAccount.MemberTypeDate = Now
        //myAccount.MemberStatusDate = Now
        //myAccount.MemberSince = Now
        //myAccount.MemberStatus = "A"
        //myAccount.MemberCategory = "WD"
        //myAccount.MemberType = "1YEAR"
        //myAccount.MemberReason = "RA"            

        return apiClient.Endpoints.Accounts.Update( myAccount);
      }
      else
      {
        throw new Exception("Membership accounts only");
      }
    }

    /// <summary>
    /// This shows various ways you can edit Account user fields
    /// </summary>
    /// <param name="issueType">This is the Issue Type code of the membership user field set.  Example string value "CK"</param>
    /// <param name="newUserText05Value">As an example, we are setting User Text 05.  Fill this with a string.</param>
    public AllAccountsModel EditWithMembershipUserFields(string orgCode, string accountCode, string issueType, string newUserText05Value)
    {
      var myAccount = apiClient.Endpoints.Accounts.Get( orgCode, accountCode);

      //To change user fields, search through the AccountUserFieldSets object on the account model.
      //Find the user field set that matches the designation and the Opportunity Type code.
      //Once it is found, you can change whatever user field you wish.
      if (myAccount.AccountUserFieldSets != null)
      {
        foreach (UserFields accountUserFields in myAccount.AccountUserFieldSets)
        {
          if (accountUserFields.Header == USISDKConstants.UserFieldHeaders.MembershipUserFields)
            //These are the Membership specific User fields that is configured for all accounts with a membership designation.
            if (accountUserFields.Type == issueType)
              accountUserFields.UserText05 = newUserText05Value;        
        }
      }

      return apiClient.Endpoints.Accounts.Update( myAccount);

    }

    /// <summary>
    /// This example shows how to make an update call and fill the response with only select properties.  This allows for faster performance as well as custom objects.
    /// </summary>
    /// <param name="body">An AllAccountsModel</param>
    /// <param name="properties">This is a list of properties, pulled from the property name on the model (ex: LastName,Class)</param>
    /// <returns></returns>
    public AllAccountsModel UpdateSelectProperties(AllAccountsModel body, List<string> properties)
    {
      var options = new Ungerboeck.Api.Models.Options.Subjects.Accounts { Select = properties };
      return apiClient.Endpoints.Accounts.Update(body, options);
    }

    public AllAccountsModel AddSelectProperties(AllAccountsModel body)
    {
      var properties = new List<string> { "Title","C|04|UserText05" };
      var options = new Ungerboeck.Api.Models.Options.Subjects.Accounts { Select = properties };
      return apiClient.Endpoints.Accounts.Add(body, options);
    }

    /// <summary>
    /// Example showing how to save multiple items of the same model at a time.  
    /// </summary>
    /// <param name="AccountsModel1">This contains a standard AllAccountsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation1">Contains "create" or "update"</param>
    /// <param name="AccountsModel2">This contains a standard AllAccountsModel object.  A partial model mith missing properties is allowed.</param>
    /// <param name="bulkOperation2">Contains "create" or "update"</param>
    /// <param name="continueOnError">The bulk process is transactional and will save nothing if an item errors.  If you are submitting a list of unrelated items to save, set this as false and the bulk save process will attempt to continue saving if an item fails to save.  Note that certain errors will always result in the bulk operation halting.</param>
    /// <returns></returns>
    public BulkResponseModel Bulk(AllAccountsModel AccountsModel1, string bulkOperation1, AllAccountsModel AccountsModel2, string bulkOperation2, bool continueOnError)
    {
      /* If one item fails, you have the option to continue without it (see BulkRequestModel.ContinueOnError).  Use this for large updates of unrelated items.
          -You can track items via the BulkItemIndex tracker.*/

      var myBulkRequest = new BulkRequestModel
      {
        ContinueOnError = continueOnError
      };

      var mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = AccountsModel1, //This is a standard Ungerboeck Model found in our SDK
        Action = bulkOperation1, //contains "create" or "update".  Every item action can be independent.
        BulkItemIndex = 1 //Use this index to track items in the response.  Whether an item succeeds or fails, it will preserve the index you assign it.
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      mybulkRequestItem = new BulkRequestItem()
      {
        UngerboeckModel = AccountsModel2,
        Action = bulkOperation2,
        BulkItemIndex = 2
      };

      myBulkRequest.BulkRequestItems.Add(mybulkRequestItem);

      return apiClient.Endpoints.Accounts.Bulk(myBulkRequest);
    }
  }

        

}

