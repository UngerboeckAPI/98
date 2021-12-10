using System.Net.Http;
using Ungerboeck.Api.Sdk;
using Ungerboeck.Api.Models;
using Ungerboeck.Api.Models.Subjects;
using Ungerboeck.Api.Models.Search;
using System.Collections.Generic;

namespace Examples.Operations
{
  public class Users : Base
  {
    public Users(ApiClient apiClient) : base(apiClient)
    {
    }

    /// <summary>
    /// A basic retrieve example
    /// </summary>
    public UsersModel Get(string ID)
    {
      return apiClient.Endpoints.Users.Get(ID);
    }

    /// <summary>
    /// A search example.  Check out the 'Search using the API' knowledge base article for more info.
    /// </summary>   
    public SearchResponse<UsersModel> Search(string searchValue)
    {
      return apiClient.Endpoints.Users.Search($"{nameof(UsersModel.DisplayName)} eq '{searchValue}'"); //Note that this endpoint does not use OrgCode
    }

    /// <summary>
    /// A basic add example
    /// </summary>    
    /// <param name="organizationCode">This will be used as the initial organization for the user.</param>
    /// <param name="ID">This will be the User ID the user can use to login.  It will be permanent.</param>
    /// <param name="displayName">This will be the name of the new user</param>
    /// <param name="email">This will be the address in which the Activate User email will be sent</param>
    /// <returns></returns>
    public UsersModel Add(string organizationCode, string ID, string displayName, string email)
    {
      var myUser = new UsersModel
      {         
        Organization = organizationCode,
        ID = ID,
        DisplayName = displayName,
        Email = email 
      };

      //Note that the user won't be activated until they set their password.  You should send the activation email when ready.  See the SendActivateUserEmail() example.

      return apiClient.Endpoints.Users.Add(myUser);
    }

    /// <summary>
    /// A basic edit example
    /// </summary>
    /// <param name="ID">This is the user ID</param>
    /// <param name="email">You can edit the user's email.  This example shows how.</param>
    /// <returns></returns>
    public UsersModel Edit(string ID, string email)
    {
      var myUser = apiClient.Endpoints.Users.Get(ID);

      myUser.Email = email;

      return apiClient.Endpoints.Users.Update(myUser);
    }

    public UsersModel EditAdvanced(string ID)
    {      
      var myUser = apiClient.Endpoints.Users.Get(ID);

      //All these fields are editable.  See existing users for example values and codes.
      myUser.Retire = "N";    //Y or N
      myUser.ReportCacheQuantity = 5;
      myUser.CustomReportDictionary = 999;
      myUser.EmailNotification = "N";
      myUser.Dictionary = 1;
      myUser.WorkingDirectory = "c:\\work\\";      
      myUser.SpellCheck = "N";
      myUser.DisplayName = "New Name";
      myUser.InitialMenu = "EBMS-MAIN";
      myUser.Organization = "10";
      myUser.Group = "NSORT";
      myUser.Initials = "JW";
      myUser.Printer = "TEST";
      myUser.EmailSendProcess = "N";
      myUser.ReplyToEmail = "reply@company.com";
      myUser.Hold = "N";
      myUser.LoginID = "NEWLOGIN";
      myUser.Theme = 108;
      myUser.RemoteAccess = "Y";
      myUser.ActivationStatus = "A";
      myUser.Email = "new.email@company.com";
      myUser.Locked = "N";
      myUser.Dashboard = 986;      
      myUser.MobileAccess = "N";
      myUser.MobileTheme = 84;
      myUser.AccessLevel = 4;
      myUser.StartupFavorite = 684;
      myUser.DefaultZoomAmount = 110;
      myUser.AuthConfiguration = "USI";
      myUser.AlwaysUseDefaultView = "N";
      myUser.Locale = 29;
       
      return apiClient.Endpoints.Users.Update(myUser);
    }

    /// <summary>
    /// This will send out an email to the user.  The user information will not be modified.
    /// </summary>
    /// <param name="orgCode">This is the organization code in which you will create the user</param>
    /// <param name="ID">This will be the User ID the user can use to login.  It will be permanent.</param>    
    /// <returns></returns>
    public HttpResponseMessage SendActivateUserEmail(string ID)
    {      
      return apiClient.Endpoints.Users.SendActivateUserEmail(ID);
    }

    /// <summary>
    /// This is how you copy a user
    /// </summary>    
    /// <param name="SourceID">The User ID of the original User.</param>
    /// <param name="NewID">The chosen User ID of the new user.</param>    
    /// <returns>A newly created Ungerboeck.Api.Models.UsersModel</returns>
    public UsersModel CopyUser(string SourceID, string NewID)
    {
      var myUser = new Ungerboeck.Api.Models.Subjects.Copy.Users
      {
        ID = NewID, //Needs to be unique
        DisplayName = "New User", //The name of the new user
        LoginID = NewID, //This does not need to be the same as the User ID above, but it needs to be a unique login ID
        Email = "newUser@company.com", //Required
        CopyRoles = "Y", //Y or N
        CopyAccessPrivileges = "Y",
        CopyMenus = "Y",
        CopyOrganizations = "Y",
        CopySettings = "N"
      };

      //Note that the user won't be activated until they set their password.  You should send the activation email when ready.  See the SendActivateUserEmail() example.

      return apiClient.Endpoints.Users.Copy(SourceID, myUser);
    }
  }
}
